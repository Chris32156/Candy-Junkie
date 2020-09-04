using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Params
    [SerializeField] float ButtonDelayTime;

    //Declare Vars
    AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Main Menu Buttons 
    public void Play()
    {
        int a = Mathf.RoundToInt(Time.time);
        PlayerPrefs.SetInt("Time Started", a);
        SceneManager.LoadScene("Game");
        audioManager.ButtonPress();
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
        audioManager.ButtonPress();
    }

    public void Quit()
    {
        audioManager.ButtonPress();
        Application.Quit();
    }

    public void LinkButton()
    {
        audioManager.ButtonPress();
        Application.OpenURL("https://chris32156.itch.io/");
    }

    //Game Over Button
    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        audioManager.ButtonPress();
    }
}
