using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Params
    [SerializeField] float speed = 1;

    //Declare Vars 
    Face face;

    //Cached Refrences
    Rigidbody2D rb;
    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        //Get Cached Values Of Components
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        //Set Object Vars Values
        face = FindObjectOfType<Face>();
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

    }
}
