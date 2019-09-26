using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SettingsChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text Settings;


    public void OnPointerEnter(PointerEventData eventData)
    {
        Settings.color = Color.green;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Settings.color = Color.white;
    }
}