using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tools : MonoBehaviour
{
    public bool inAction;

    public enum Dir { Up, Down, Left, Right };
    [HideInInspector]public Dir faceDir;

    public GameObject[] toolSlots;
    [HideInInspector]public GameObject selectedTool;
    int selectedToolIndex;

    public PlayerMove playerMove;
    public WateringCan wateringCan;
    public PlayerSwat flySwatter;

    public Sprite unselectedSlot;
    public Sprite selectedSlot;

    void Start()
    {
        faceDir = Dir.Down;
        SelectTool(0);
    }

    void Update()
    {
        HandleToolDirection();
        SwitchTool();
        CheckForAction();
    }

    void SwitchTool()
    {
        selectedTool.GetComponent<Image>().sprite = unselectedSlot;
        selectedTool.GetComponent<RectTransform>().sizeDelta = new Vector2(100f, 100f);

        if (Input.mouseScrollDelta.y < 0)
        {
            selectedToolIndex += 1;
        }
        else if (Input.mouseScrollDelta.y > 0)
        {
            selectedToolIndex -= 1;
        }

        if (selectedToolIndex > (toolSlots.Length - 1))
        {
            selectedToolIndex = 0;
        }
        else if (selectedToolIndex < 0)
        {
            selectedToolIndex = (toolSlots.Length - 1);
        }

        SelectTool(selectedToolIndex);
    }

    void SelectTool(int i)
    {
        selectedTool = toolSlots[i];
        selectedToolIndex = i;

        selectedTool.GetComponent<Image>().sprite = selectedSlot;
        selectedTool.GetComponent<RectTransform>().sizeDelta = new Vector2(112.5f, 112.5f);
    }

    void CheckForAction()
    {
        if (wateringCan.watering || flySwatter.swatting)
        {
            inAction = true;
        }
        else
        {
            inAction = false;
        }
    }

    void HandleToolDirection()
    {
        if (playerMove.inputDir.y > 0)
        {
            faceDir = Dir.Up;
            return;
        }
        else if (playerMove.inputDir.y < 0)
        {
            faceDir = Dir.Down;
            return;
        }
        if (playerMove.inputDir.x < 0)
        {
            faceDir = Dir.Left;
            return;
        }
        else if (playerMove.inputDir.x > 0)
        {
            faceDir = Dir.Right;
            return;
        }
    }
}
