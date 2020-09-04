using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    //Params 
    [SerializeField] AudioClip PickupSound;

    //Declare Vars
    Game game;
    bool hasBeenCollected = false;

    private void Awake()
    {
        //Set Object Vars Values
        game = FindObjectOfType<Game>();    
    }

    //On Collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Makes Sure Collision Is The Player
        if (collision.gameObject.tag == "Player" && !hasBeenCollected)
        {
            //Update Var
            hasBeenCollected = true;

            //Plays Sound Effect
            AudioSource.PlayClipAtPoint(PickupSound, Camera.main.transform.position);

            //Call Game Function For When Player Gets A Candy 
            game.GotCandy();

            //Destroy Self
            Destroy(gameObject);
        }
    }
}
