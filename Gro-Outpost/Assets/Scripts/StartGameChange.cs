using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StartGameChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text StartGame;

    // Start is called before the first frame update
    public void OnPointerEnter(PointerEventData eventData)
    {
        StartGame.color = Color.green;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StartGame.color = Color.white;

    }
}
