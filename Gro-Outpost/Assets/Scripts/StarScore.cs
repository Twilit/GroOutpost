using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScore : MonoBehaviour
{
    public string currentLevelHS;
    int highScore;
    int currentScore;

    void Start()
    {
        if (PlayerPrefs.HasKey(currentLevelHS))
        {
            highScore = PlayerPrefs.GetInt(currentLevelHS);
        }
    }

    void SaveScore()
    {
        if (currentScore > highScore)
        {
            PlayerPrefs.SetInt(currentLevelHS, currentScore);

            PlayerPrefs.Save();
        }
    }

    void DisplayScore()
    {

    }
}
