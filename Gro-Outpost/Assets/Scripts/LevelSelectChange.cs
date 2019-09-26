using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelSelectChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text LevelSelect;

    // Start is called before the first frame update
    public void OnPointerEnter(PointerEventData eventData)
    {
        LevelSelect.color = Color.green;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        LevelSelect.color = Color.white;

    }
}
