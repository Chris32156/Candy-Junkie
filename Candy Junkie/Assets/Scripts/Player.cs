using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Params
    [SerializeField] float speed = 1;
    [SerializeField] float InvincabilityTime;
    [SerializeField] float MinY;
    [SerializeField] float MaxY;
    [SerializeField] float MinX;
    [SerializeField] float MaxX;
    [SerializeField] float ScreenWrapBuffer;
    [SerializeField] float MaxSpeed;
    [SerializeField] float MaxSize;
    [SerializeField] float CandySpeed;
    [SerializeField] float SizeIncrease;
    [SerializeField] float SizeDecreasePerSecond;
    [SerializeField] float SpeedDecreasePerSecond;
    [SerializeField] Transform body;

    //Declare Vars 
    Face face;
    Game game;
    AudioManager audio;
    int modifier;
    float StartingSpeed;
    float timeHit;
    float SpeedDecrease;
    float SizeDecrease;
    bool alive = true;
    bool hasBeenHit = false;
    Vector3 startingSize;
    Vector3 CandyIncreaseSize;

    //Cached Refrences
    Rigidbody2D rb;
    SpriteRenderer sprite;
    //CapsuleCollider2D BodyColider;

    // Start is called before the first frame update
    void Start()
    {
        //Get Cached Values Of Components
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        //BodyColider = body.GetComponent<CapsuleCollider2D>();

        //Set Object Vars Values
        face = FindObjectOfType<Face>();
        game = FindObjectOfType<Game>();
        audio = FindObjectOfType<AudioManager>();

        //Set Defualts
        StartingSpeed = speed;
        startingSize = body.transform.localScale;

        CandyIncreaseSize = new Vector3(SizeIncrease, 0, 0);
        SizeDecrease = SizeDecreasePerSecond / 60;
        SpeedDecrease = SpeedDecreasePerSecond / 60;
    }

    // Update is called once per frame
    void Update()
    {
        //Makes Sure Player Is Alive
        if (alive)
        {
            //Get Movement Input
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            //Update Face
            face.flipFace(x);

            //Get Movement Values
            float moveByX = x * speed;
            float moveByY = y * speed;

            //Update Movement
            rb.velocity = new Vector2(moveByX, moveByY);

            //Eat Candy
            if (Input.GetKeyDown(KeyCode.B))
            {
                //Checks If Player Has Candy
                if (game.HasCandy())
                {
                    eatCandy();
                }
                else
                {
                    //Play Sound To Show Player Has No Candy
                    //TODO
                }
            }

            //Checks If Size Is Too Big
            if (body.localScale.x > MaxSize)
            {
                //Set Death Message
                //TODO

                //Play Sound Effect
                audio.ExplosionDeath();

                //Call Game Over Function
                game.gameOver();
            }

            //Decrease Size
            if (body.localScale != startingSize)
            {
                //Sets newX And Caps It
                float newX = Mathf.Clamp(body.localScale.x - SizeDecrease, startingSize.x, body.localScale.x);

                //Update Size
                body.localScale = new Vector3(newX, body.localScale.y, body.localScale.z);
            }

            //Decrease Speed
            if (speed != StartingSpeed)
            {
                //Gets newSpeed
                float newSpeed = speed - SpeedDecrease;

                //Updates Speed And Caps It
                speed = Mathf.Clamp(newSpeed, StartingSpeed, MaxSpeed);
            }

            //Call Screenwrap Function
            ScreenWrap();
        }
    }

    //Function To Eat Candy
    void eatCandy()
    {
        //Adds Speed
        speed += CandySpeed;

        //Caps Speed
        speed = Mathf.Clamp(speed, StartingSpeed, MaxSpeed);

        //Adds Size
        body.localScale += CandyIncreaseSize;
        //BodyColider.size += new Vector2(SizeIncrease, 0);

        //Debug 
        Debug.Log("Speed:" + speed);
    }

    //Called When Player Got Hit By Zombie But Still Has Lives
    public void GotHit()
    {
        //Set Vars
        hasBeenHit = true;
        timeHit = Time.time;

        //Hit Effect
        face.GotHit();
    }

    //Function For ScreenWraping
    public void ScreenWrap()
    {
        //Check Horizontal
        if (transform.position.x <= MinX || transform.position.x >= MaxX)
        {
            if (transform.position.x > 0)
            {
                modifier = 1;
            }
            else
            {
                modifier = -1;
            }
            //Set Position To Opposite Side
            transform.position = new Vector3(transform.position.x * -1f + (ScreenWrapBuffer * modifier), transform.position.y);
        }

        //Check Vertical
        if (transform.position.y <= MinY || transform.position.y >= MaxY)
        {
            if (transform.position.y > 0)
            {
                modifier = 1;
                transform.position = new Vector3(transform.position.x, transform.position.y * -1f + ((ScreenWrapBuffer * modifier) - 0.5f * modifier));
            }
            else
            {
                modifier = -1;

                //Set Position To Opposite Side
                transform.position = new Vector3(transform.position.x, transform.position.y * -1f + ((ScreenWrapBuffer * modifier) + 0.5f * modifier));
            }
        }
    }

    //Returns If Player Is Invincible Or Not
    public bool CanBeHit()
    {
        return (Time.time > timeHit + InvincabilityTime || !hasBeenHit) && alive;
    }

    public void gameOver()
    {
        //Update Vars
        alive = false;
    }
}
