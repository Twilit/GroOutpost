using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools : MonoBehaviour
{
    public bool inAction;

    public enum Dir { Up, Down, Left, Right };
    public Dir faceDir;
    public PlayerMove playerMove;

    void Start()
    {
        faceDir = Dir.Down;
    }

    void Update()
    {
        HandleToolDirection();
    }

    void HandleToolDirection()
    {
        if (Mathf.Abs(playerMove.inputDir.x) <= 0.7f && playerMove.inputDir.y >= 0.7f)
        {
            faceDir = Dir.Up;
        }
        else if (Mathf.Abs(playerMove.inputDir.x) <= 0.7f && playerMove.inputDir.y <= -0.7f)
        {
            faceDir = Dir.Down;
        }
        else if (playerMove.inputDir.x <= -0.9f)
        {
            faceDir = Dir.Left;
        }
        else if (playerMove.inputDir.x >= 0.9f)
        {
            faceDir = Dir.Right;
        }
    }
}
