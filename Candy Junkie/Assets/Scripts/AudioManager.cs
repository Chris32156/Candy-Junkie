using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //Params
    [SerializeField] AudioClip ButtonSound;
    [SerializeField] AudioClip ExplosionSound;
    [SerializeField] AudioClip GameOverSound;
    [SerializeField] AudioClip CandyEatingSound;
    [SerializeField] AudioClip NoCandySound;

    //Cached Refrences
    AudioSource audio;

    void Awake()
    {
        var objs = FindObjectsOfType<AudioManager>();

        //Checks If Already Spawned
        if (objs.Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            //Keeps It Loaded Even In Between Scenes
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            //Toggles Muted 0 means Unmuted, 1 means muted
            if (PlayerPrefs.GetInt("Muted", 0) == 0)
            {
                PlayerPrefs.SetInt("Muted", 1);
            }
            else
            {
                PlayerPrefs.SetInt("Muted", 0);
            }
        }
    }

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void ButtonPress()
    {
        audio.PlayOneShot(ButtonSound);
    }

    public void ExplosionDeath()
    {
        audio.PlayOneShot(ExplosionSound);
    }

    public void NoCandy()
    {
        audio.PlayOneShot(NoCandySound);
    }

    public void EatCandy()
    {
        audio.PlayOneShot(CandyEatingSound);
    }

    public void GameOver()
    {
        audio.PlayOneShot(GameOverSound);
    }
}
