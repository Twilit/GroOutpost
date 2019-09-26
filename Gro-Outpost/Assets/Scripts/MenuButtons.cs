using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public Text StartGame;
    public Text LevelSelect;
    public Text Settings;


    public void OnPointerEnter(PointerEventData eventData)
    {
        StartGame.color = Color.green;
        Debug.Log("123");
        LevelSelect.color = Color.green;
        Settings.color = Color.green;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StartGame.color = Color.white;
        Debug.Log("456");
        LevelSelect.color = Color.white;
        Settings.color = Color.white;
    }
}