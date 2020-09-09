using System.Collections;
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
    [SerializeField] float MinTimeUntilHeartSpawn;
    [SerializeField] float MaxTimeUntilHeartSpawn;
    [SerializeField] float MinTimeUntilCandySpawn;
    [SerializeField] float MaxTimeUntilCandySpawn;
    [SerializeField] float MinTimeUntilZombieSpawn;
    [SerializeField] float MaxTimeUntilZombieSpawn;
    [SerializeField] int fps = 60;
    [SerializeField] int MaxHealth = 99;
    [SerializeField] int ScorePerCandy;
    [SerializeField] int ScorePerHeart;
    [SerializeField] int ScorePerSecond;
    [SerializeField] TextMeshProUGUI CandiesText;
    [SerializeField] TextMeshProUGUI LivesText;
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] GameObject Candy;
    [SerializeField] GameObject Zombie;
    [SerializeField] GameObject Heart;

    //Declare Vars
    int Candies;
    int Lives;
    int score = 0;
    Player player;
    SceneManagement SceneManager;
    AudioManager audio;
    Vector3 PositionOfCandy;
    Vector3 PositionOfHeart;
    float timeCandySpawned;
    float timeZombieSpawned;
    float timeHeartSpawned;
    float timeUntilNextZombieSpawn;
    float timeUntilNextCandySpawn;
    float timeUntilNextHeartSpawn;
    float scoreUpTime;

    private void Awake()
    {
        //Set FPS
        Application.targetFrameRate = fps;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Set Object Vars Values
        player = FindObjectOfType<Player>();
        audio = FindObjectOfType<AudioManager>();
        SceneManager = FindObjectOfType<SceneManagement>();

        //Get Defualts
        Candies = StartingNumberOfCandies;
        Lives = StartingHealth;
        timeCandySpawned = Time.time;
        timeZombieSpawned = Time.time;
        timeHeartSpawned = Time.time;
        scoreUpTime = Time.time + 1;

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
        timeUntilNextHeartSpawn = Random.Range(MinTimeUntilHeartSpawn, MaxTimeUntilHeartSpawn);

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
            //Get Position Ff Candy
            PositionOfCandy = new Vector3(Random.Range(-8f, 8f), Random.Range(-4f, 4f), 0);

            //Spawn Candy
            Instantiate(Candy, PositionOfCandy, Quaternion.identity);

            //Update Vars
            timeCandySpawned = Time.time;
            timeUntilNextCandySpawn = Random.Range(MinTimeUntilCandySpawn, MaxTimeUntilCandySpawn);
        }

        //Heart Spawn
        if (Time.time > timeUntilNextHeartSpawn + timeHeartSpawned)
        {
            //Get Position Of Heart
            PositionOfHeart = new Vector3(Random.Range(-8f, 8f), Random.Range(-4f, 4f), 0);

            //Spawn Heart
            Instantiate(Heart, PositionOfHeart, Quaternion.identity);

            //Update Vars
            timeHeartSpawned = Time.time;
            timeUntilNextHeartSpawn = Random.Range(MinTimeUntilHeartSpawn, MaxTimeUntilHeartSpawn);
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

        //Update Score Every Second
        if (Time.time >= scoreUpTime)
        {
            UpdateScore(ScorePerSecond);

            scoreUpTime++;
        }

    }

    //Called When Player Gets A Candy
    public void GotCandy()
    {
        //Adds One To Candies
        Candies++;

        //Caps Candies
        Mathf.Clamp(Candies, 0, 99);

        //Update Score
        UpdateScore(ScorePerCandy);

        //Update UI
        CandiesText.SetText("X " + Candies.ToString());
    }

    //Called When Player Gets A Heart
    public void GotHeart()
    {
        //Adds A Life
        Lives++;

        //Caps Lives
        Lives = Mathf.Clamp(Lives, 0, MaxHealth);

        //Update Score
        UpdateScore(ScorePerHeart);

        //Update UI
        LivesText.SetText("X " + Lives.ToString());
    }

    //Called When Player Gets Hit By A Zombie
    public void PlayerGotHit()
    {
        Lives--;

        //Caps Lives
        Lives = Mathf.Clamp(Lives, 0, MaxHealth);

        //Update UI
        LivesText.SetText("X " + Lives.ToString());

        //Game Over
        if (Lives <= 0)
        {
            //Sound Effect
            audio.GameOver();

            gameOver();
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
            //Sound Effect
            audio.NoCandy();

            return false;
        }
        else
        {
            //Sound Effect
            audio.EatCandy(); 

            //Removes One Candy
            Candies--;

            //Caps Candies
            Mathf.Clamp(Candies, 0, 99);

            //Updates UI
            CandiesText.SetText("X " + Candies.ToString());

            return true;
        }
    }

    public void gameOver()
    {
        //Death Effects
        //TODO

        //Call Player Function 
        player.gameOver();

        //Load Game Over Scene
        SceneManager.LoadScene("Game Over");
    }

    public int GetLives()
    {
        return Lives;
    }

    void UpdateScore(int x)
    {
        //Update Vars
        score += x;
        PlayerPrefs.SetInt("Score", score);

        //Update UI
        ScoreText.SetText(score.ToString());
    }
}
