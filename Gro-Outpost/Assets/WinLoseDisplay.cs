using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinLoseDisplay : MonoBehaviour
{

    public Text winLoseText;

    public void DisplayResult(bool win)
    {
        if (win)
        {
            winLoseText.text = "You Win";
        }
        else
        {
            winLoseText.text = "You Lose";
        }
    }
}
