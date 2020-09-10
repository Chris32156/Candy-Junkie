using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    //Params
    [SerializeField] Image MuteIcon;
    [SerializeField] Sprite UnmutedIcon;
    [SerializeField] Sprite MutedIcon;

    //Declare Vars
    AudioManager audio;

    // Start is called before the first frame update
    void Start()
    {
        UpdateIcon();

        audio = FindObjectOfType<AudioManager>();
    }

    public void UpdateIcon()
    {
        //If Unmuted
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            MuteIcon.sprite = UnmutedIcon;
        }
        //If Muted
        else
        {
            MuteIcon.sprite = MutedIcon;
        }
    }

    public void ToggleMute()
    {
        audio.ButtonPress();

        //Toggles Muted 0 means Unmuted, 1 means muted
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            PlayerPrefs.SetInt("Muted", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Muted", 0);
        }

        audio.ButtonPress();

        UpdateIcon();
    }
}
