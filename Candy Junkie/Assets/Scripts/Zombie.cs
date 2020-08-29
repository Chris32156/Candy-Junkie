using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    //Params
    [SerializeField] float MinSize = 0.7f;
    [SerializeField] float MaxSize = 1.5f;

    //Declare Vars
    Game game;

    // Start is called before the first frame update
    void Start()
    {
        //Set Object Vars Values
        game = FindObjectOfType<Game>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Called On Collision
    void OnCollisionEnter2D(Collision2D collision)
    {
        game.PlayerGotHit();
    }
}
