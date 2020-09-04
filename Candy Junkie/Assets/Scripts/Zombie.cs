using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Zombie : MonoBehaviour
{
    //Params
    [SerializeField] float MinSize = 0.7f;
    [SerializeField] float MaxSize = 1.5f;
    [SerializeField] float XSpawnPos;
    [SerializeField] float YSpawnPos;
    [SerializeField] AIPath aiPath;
    [SerializeField] AudioClip HitSound;

    //Declare Vars
    Game game;
    Player player;
    bool isLeftOrRight;
    bool IsCollidingWithPlayer = false;
    float size;
    int xModifier = 1;
    int yModifier = 1;

    // Start is called before the first frame update
    void Start()
    {
        //Set Object Vars Values
        game = FindObjectOfType<Game>();
        player = FindObjectOfType<Player>();

        //Choose Which Border It Spawns On
        int Border = Random.Range(1, 5); // 1 is Left 2 is Right 3 Is Top 4 is Bottom

        //Sets Random Size
        size = Random.Range(MinSize, MaxSize);
        transform.localScale = new Vector3(size, size, 0);

        //Checks If It Spawns On Left Or Right
        if (Border < 3)
        {
            isLeftOrRight = true;

            //Sets It To -
            if (Border == 1)
            {
                xModifier = -1;
            }
        }
        //If It Spawns On Top Or Bottom
        else
        {
            isLeftOrRight = false;

            //Sets It To Negative if Bottom
            if (Border == 4)
            {
                yModifier = -1;
            }
        }

        //Sets Position
        RandomSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        //Flip
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f * size, transform.localScale.y, transform.localScale.z);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(size, transform.localScale.y, transform.localScale.z);
        }

        //Calls PlayerGotHit If Player Is Colliding And Can Be Hit
        if (player.CanBeHit() && IsCollidingWithPlayer)
        {
            //Plays Sound Effect If Player Has > 1 life
            if (game.GetLives() > 1)
            {
                AudioSource.PlayClipAtPoint(HitSound, Camera.main.transform.position);
            }
            //Plays Game Over Sound Effect
            else
            {
                //TODO
            }
            game.PlayerGotHit();
        }
    }

    //Called On Collision
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Sets IsCollidingWithPlayer To True On Start Of Collision
        if (collision.gameObject.tag == "Player")
        {
            IsCollidingWithPlayer = true;
        }
    }

    //Called On End Of Collision
    private void OnCollisionExit2D(Collision2D collision)
    {
        //Sets IsCollidingWithPlayer To False On End Of Collision
        if (collision.gameObject.tag == "Player")
        {
            IsCollidingWithPlayer = false;
        }
    }

    //Function To Set Position
    void RandomSpawn()
    {
        //Declare local Vars
        float x;
        float y;

        //If Left Or Right
        if (isLeftOrRight)
        {
            x = XSpawnPos * xModifier;
            y = Random.Range(YSpawnPos * -1, YSpawnPos);
        }
        //If Is Top Or Bottom
        else
        {
            y = YSpawnPos * yModifier;
            x = Random.Range(XSpawnPos * -1, XSpawnPos);
        }

        //Fix Bug With Spawning Too High If Postive
        if (y == YSpawnPos)
        {
            y -= 0.5f;
        }

        //Set position
        transform.position = new Vector3(x, y, 0);
    }
}
