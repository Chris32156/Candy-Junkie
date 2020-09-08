using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Declare Vars
    AudioManager audioManager;
    SceneManagement SceneManagement;
    bool ButtonPressed = false;

    private void Start()
    {
            audioManager = FindObjectOfType<AudioManager>();
            SceneManagement = FindObjectOfType<SceneManagement>();
    }

    // Main Menu Buttons 
    public void Play()
    {
        if (!ButtonPressed)
        {
            int a = Mathf.RoundToInt(Time.time);
            PlayerPrefs.SetInt("Time Started", a);
            SceneManagement.LoadScene("Game");
            audioManager.ButtonPress();
            ButtonPressed = true;
        }
    }

    public void Settings()
    {
        if (!ButtonPressed)
        {
            SceneManagement.LoadScene("Settings");
            audioManager.ButtonPress();
            ButtonPressed = true;
        }
    }

    public void Quit()
    {
        if (!ButtonPressed)
        {
            audioManager.ButtonPress();
            Application.Quit();
            ButtonPressed = true;
        }
    }

    public void LinkButton()
    {
        if (!ButtonPressed)
        {
            audioManager.ButtonPress();
            Application.OpenURL("https://chris32156.itch.io/");
        }
    }

    //Game Over Button
    public void QuitToMainMenu()
    {
        if (!ButtonPressed)
        {
            SceneManagement.LoadScene("Main Menu");
            audioManager.ButtonPress();
            ButtonPressed = true;
        }
    }

    public void QuitToMainMenuNoTransition()
    {
        if (!ButtonPressed)
        {
            SceneManager.LoadScene("Main Menu 1");
            audioManager.ButtonPress();
            ButtonPressed = true;
        }
    }

    public void Tutorial()
    {
        if (!ButtonPressed)
        {
            SceneManager.LoadScene("Tutorial");
            audioManager.ButtonPress();
            ButtonPressed = true;
        }
    }

    public void Difficulty()
    {
        if (!ButtonPressed)
        {
            SceneManager.LoadScene("Difficulty Menu");
            audioManager.ButtonPress();
            ButtonPressed = true;
        }
    }

    public void MediumButton()
    {
        if (!ButtonPressed)
        {
            PlayerPrefs.SetString("Difficulty", "Medium");
            SceneManagement.LoadScene("Game");
            audioManager.ButtonPress();
            ButtonPressed = true;
        }
    }

    public void HardButton()
    {
        if (!ButtonPressed)
        {
            PlayerPrefs.SetString("Difficulty", "Hard");
            SceneManagement.LoadScene("Game");
            audioManager.ButtonPress();
            ButtonPressed = true;
        }
    }
}
