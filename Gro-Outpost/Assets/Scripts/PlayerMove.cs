using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float runSpeed = 4f;

    public Animator playerAnim;
    public PlayerSwat playerSwat;
    public enum Dir { Up, Down, Left, Right };
    [HideInInspector] public Dir faceDir;
    Vector2 inputDir;
    Vector3 velocity;

    Rigidbody2D rb2D;
    PlayerCollisions collisionChecker;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        collisionChecker = GetComponent<PlayerCollisions>();
        faceDir = Dir.Down;
    }

    void Update()
    {
        if (!playerSwat.swatting && !playerSwat.startSwat)
        {
            inputDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        }
        else
        {
            inputDir = Vector2.zero;
        }

        velocity = inputDir * runSpeed;
    }

    void FixedUpdate()
    {
        HandleFaceDir(inputDir);
        playerAnim.SetFloat("speed", Mathf.Abs(velocity.magnitude));
        rb2D.MovePosition(rb2D.transform.position + collisionChecker.CheckForCollision(velocity * Time.fixedDeltaTime));
    }

    void HandleFaceDir(Vector2 inputDir)
    {
        if (inputDir != Vector2.zero && !playerSwat.swatting && !playerSwat.startSwat)
        {
            playerAnim.SetFloat("X", inputDir.x);
            playerAnim.SetFloat("Y", inputDir.y);

            if (Mathf.Abs(inputDir.x) < 0.2f && inputDir.y > 0.8f)
            {
                faceDir = Dir.Up;
            }
            if (Mathf.Abs(inputDir.x) < 0.2f && inputDir.y < -0.8f)
            {
                faceDir = Dir.Down;
            }
            if (inputDir.x < -0.8f && Mathf.Abs(inputDir.y) < 0.2f)
            {
                faceDir = Dir.Left;
            }
            if (inputDir.x > 0.8f && Mathf.Abs(inputDir.y) < 0.2f)
            {
                faceDir = Dir.Right;
            }
        }
    }
}
