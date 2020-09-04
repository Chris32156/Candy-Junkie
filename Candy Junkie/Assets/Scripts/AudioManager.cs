﻿using System.Collections;
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

    // Start is called before the first frame update
    void Awake()
    {
        //Keeps It Loaded Even In Between Scenes
        DontDestroyOnLoad(gameObject);
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