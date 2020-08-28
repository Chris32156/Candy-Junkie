using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    //Declare Vars
    Game game;

    private void Start()
    {
        //Set Object Vars Values
        game = FindObjectOfType<Game>();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Makes Sure Collision Is The Player
        if (collision.gameObject.tag == "Player")
        {
            //Call Game Function For When Player Gets A Candy 
            game.GotCandy();

            //Destroy Self
            Destroy(gameObject);
        }
    }
}
