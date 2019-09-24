using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float runSpeed = 4f;

    float x = 0f;
    float y = 0f;
    Vector3 dir;
    Vector3 velocity;

    Rigidbody2D rb2D;
    PlayerCollisions collisionChecker;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        collisionChecker = GetComponent<PlayerCollisions>();
    }

    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        dir = new Vector3(x, y, 0);
        velocity = dir.normalized * runSpeed;
    }

    void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.transform.position + collisionChecker.CheckForCollision(velocity * Time.fixedDeltaTime));
    }
}
