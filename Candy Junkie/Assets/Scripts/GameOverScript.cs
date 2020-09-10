using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScript : MonoBehaviour
{
    //Params
    [SerializeField] TextMeshProUGUI DiedFromText;
    [SerializeField] TextMeshProUGUI ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        //Update Death Text
        if (PlayerPrefs.GetString("Death") == "Candy")
        {
            DiedFromText.SetText("Died From Eating Too Much Candy");
        }
        else
        {
            DiedFromText.SetText("Died From Zombies");
        }

        //Set Score Text
        ScoreText.SetText(PlayerPrefs.GetInt("Score", 0).ToString());
    }
}
