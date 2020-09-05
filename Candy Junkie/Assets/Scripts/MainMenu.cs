using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Declare Vars
    AudioManager audioManager;
    SceneManagement SceneManagement;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        SceneManagement = FindObjectOfType<SceneManagement>();
    }

    // Main Menu Buttons 
    public void Play()
    {
        int a = Mathf.RoundToInt(Time.time);
        PlayerPrefs.SetInt("Time Started", a);
        SceneManagement.LoadScene("Game");
        audioManager.ButtonPress();
    }

    public void Settings()
    {
        SceneManagement.LoadScene("Settings");
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
        SceneManagement.LoadScene("Main Menu");
        audioManager.ButtonPress();
    }

    public void QuitToMainMenuNoTransition()
    {
        SceneManager.LoadScene("Main Menu 1");
        audioManager.ButtonPress();
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
        audioManager.ButtonPress();
    }
}
