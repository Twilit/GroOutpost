using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float runSpeed = 4f;

    float x = 0f;
    float y = 0f;
    Vector3 dir;

    Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        dir = new Vector3(x, y, 0);
    }

    void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.transform.position + dir.normalized * runSpeed * Time.fixedDeltaTime);
    }
}
