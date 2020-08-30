using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Params
    [SerializeField] float speed = 1;
    [SerializeField] float MaxSpeed;
    [SerializeField] float CandySpeed;
    [SerializeField] float SizeIncrease;
    [SerializeField] Transform body;

    //Declare Vars 
    Face face;
    Game game;
    float StartingSpeed;
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

        //Set Defualts
        StartingSpeed = speed;
        startingSize = transform.position;

        CandyIncreaseSize = new Vector3(SizeIncrease, 0, 0);
    }

    // Update is called once per frame
    void Update()
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

        //Check For Mouse Click
        if (Input.GetMouseButtonDown(0))
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
    }

    //Called When Player Got Hit By Zombie But Still Has Lives
    public void GotHit()
    {
        //TODO
    }
}
