using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    //Params
    [SerializeField] TextMeshProUGUI TimerText;

    // Start is called before the first frame update
    void Start()
    {
        //Get How Many Seconds The Run Has Taken
        int timeOfRun = Mathf.RoundToInt(Time.time) - Mathf.RoundToInt(PlayerPrefs.GetFloat("Time Started"));

        //Get Minutes/ Seconds
        int Minutes = timeOfRun / 60;
        int Seconds = timeOfRun % 60;

        //Set Text
        TimerText.SetText("Time Survived " + Minutes.ToString("d2") + ":" + Seconds.ToString("d2"));
    }
}
