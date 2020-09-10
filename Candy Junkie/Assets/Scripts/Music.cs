using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    //Cached Values
    AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Muted") == 0)
        {
            audio.mute = false;
        }
        else
        {
            audio.mute = true;
        }
    }
}
