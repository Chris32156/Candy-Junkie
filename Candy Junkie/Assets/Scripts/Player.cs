﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Params
    [SerializeField] float speed = 1;
    [SerializeField] float MinY;
    [SerializeField] float MaxY;
    [SerializeField] float MinX;
    [SerializeField] float MaxX;
    [SerializeField] float ScreenWrapBuffer;
    [SerializeField] float MaxSpeed;
    [SerializeField] float CandySpeed;
    [SerializeField] float SizeIncrease;
    [SerializeField] Transform body;

    //Declare Vars 
    Face face;
    Game game;
    int modifier;
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

        //Call Screenwrap Function
        ScreenWrap();
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
        //TODO
    }

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
}
