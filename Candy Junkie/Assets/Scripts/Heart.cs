using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    //Declare Vars
    Game game;

    // Start is called before the first frame update
    void Start()
    {
        //Set Object Vars Values
        game = FindObjectOfType<Game>();
    }

    //On Collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Makes Sure Collision Is The Player
        if (collision.gameObject.tag == "Player")
        {
            //Call Game Function For When Player Gets A Candy 
            game.GotHeart();

            //Destroy Self
            Destroy(gameObject);
        }
    }
}
