﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    //Params 
    [SerializeField] int StartingNumberOfCandies = 3;
    [SerializeField] int StartingHealth = 3;
    [SerializeField] int StartingZombies;
    [SerializeField] int StartingCandies;
    [SerializeField] float MinTimeUntilCandySpawn;
    [SerializeField] float MaxTimeUntilCandySpawn;
    [SerializeField] float MinTimeUntilZombieSpawn;
    [SerializeField] float MaxTimeUntilZombieSpawn;
    [SerializeField] int fps = 60;
    [SerializeField] int MaxHealth = 99;
    [SerializeField] TextMeshProUGUI CandiesText;
    [SerializeField] TextMeshProUGUI LivesText;
    [SerializeField] GameObject Candy;
    [SerializeField] GameObject Zombie;

    //Declare Vars
    int Candies;
    int Lives;
    Player player;
    Vector3 PositionOfCandy;
    float timeCandySpawned = 0;
    float timeZombieSpawned = 0;
    float timeUntilNextZombieSpawn;
    float timeUntilNextCandySpawn;

    // Start is called before the first frame update
    void Start()
    {
        //Set Object Vars Values
        player = FindObjectOfType<Player>();

        //Get Defualts
        Candies = StartingNumberOfCandies;
        Lives = StartingHealth;

        //Spawn Starting Amounts

        //Zombies
        for (int i = 0; i < StartingZombies; i++)
        {
            Instantiate(Zombie);
        }

        //Candies
        for (int i = 0; i < StartingCandies; i++)
        {
            //Get Position of Candy
            PositionOfCandy = new Vector3(Random.Range(-8f, 8f), Random.Range(-4f, 4f), 0);

            //Spawn Candy
            Instantiate(Candy, PositionOfCandy, Quaternion.identity);
        }

        //Time Until Next Spawn
        timeUntilNextZombieSpawn = Random.Range(MinTimeUntilZombieSpawn, MaxTimeUntilZombieSpawn);
        timeUntilNextCandySpawn = Random.Range(MinTimeUntilCandySpawn, MaxTimeUntilCandySpawn);

        //Intilize UI
        CandiesText.SetText("X " + Candies.ToString());
        LivesText.SetText("X " + Lives.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        //Candy Spawn
        if (Time.time > timeUntilNextCandySpawn + timeCandySpawned)
        {
            //Get Position of Candy
            PositionOfCandy = new Vector3(Random.Range(-8f, 8f), Random.Range(-4f, 4f), 0);

            //Spawn Candy
            Instantiate(Candy, PositionOfCandy, Quaternion.identity);

            //Update Vars
            timeCandySpawned = Time.time;
            timeUntilNextCandySpawn = Random.Range(MinTimeUntilCandySpawn, MaxTimeUntilCandySpawn);
        }

        //Zombie Spawn
        if (Time.time > timeUntilNextZombieSpawn + timeZombieSpawned)
        {
            //Spawn Candy
            Instantiate(Zombie);

            //Update Vars
            timeZombieSpawned = Time.time;
            timeUntilNextZombieSpawn = Random.Range(MinTimeUntilZombieSpawn, MaxTimeUntilZombieSpawn);   
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

    //Called When Player Gets Hit BY Zombie
    public void PlayerGotHit()
    {
        Lives--;

        //Caps Lives
        Lives = Mathf.Clamp(Lives, 0, MaxHealth);

        //Update UI
        LivesText.SetText("X " + Lives.ToString());

        //Game Over
        if (Lives < 0)
        {

        }
        //If Player Has More Lives
        else
        {
            player.GotHit();
        }
    }

    //Returns True If Player Has Candy
    public bool HasCandy()
    {
        if (Candies <= 0)
        {
            return false;
        }
        else
        {
            //Removes One Candy
            Candies--;

            //Updates UI
            CandiesText.SetText("X " + Candies.ToString());

            return true;
        }
    }
}
