using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Main Menu Buttons 
    public void Play()
    {
        PlayerPrefs.SetFloat("Time Started", Time.time);
        SceneManager.LoadScene("Game");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LinkButton()
    {
        Application.OpenURL("https://chris32156.itch.io/");
    }

    //Game Over Button
    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
