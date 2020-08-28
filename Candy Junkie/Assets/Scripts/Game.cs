﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    //Params 
    [SerializeField] int StartingNumberOfCandies = 3;
    [SerializeField] int StartingHealth = 3;
    [SerializeField] int fps = 60;
    [SerializeField] TextMeshProUGUI CandiesText;
    [SerializeField] GameObject Candy;

    //Declare Vars
    int Candies;
    int Health;
    Player player;
    Vector3 PositionOfCandy;
    float timeSpawned;

    // Start is called before the first frame update
    void Start()
    {
        //Set Object Vars Values
        player = FindObjectOfType<Player>();

        //Get Defualts
        Candies = StartingNumberOfCandies;
        Health = StartingHealth;
        timeSpawned = 0;

        //Intilize UI
        CandiesText.SetText("X " + Candies.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > 5 + timeSpawned)
        {
            PositionOfCandy = new Vector3(Random.Range(-8f, 8f), Random.Range(-4f, 4f), 0);
            Instantiate(Candy, PositionOfCandy, Quaternion.identity);
            timeSpawned = Time.time;
        }
    }

    //Called When Player Gets A Candy
    public void GotCandy()
    {
        //Adds One To Candies
        Candies++;

        //Update UI
        CandiesText.SetText("X " + Candies.ToString());
    }
}