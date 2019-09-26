using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : MonoBehaviour
{
    public Tools playerTools;
    public Transform can;
    public bool watering;
    SpriteRenderer canSprite;
    Animator canAnim;
    AudioSource canSound;

    void Start()
    {
        canSprite = GetComponent<SpriteRenderer>();
        canAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            watering = true;
        }
        else
        {
            watering = false;
        }
    }

    void FixedUpdate()
    {
        SetCanDirection();

        canAnim.SetBool("watering", watering);
    }

    void SetCanDirection()
    {
        if (playerTools.faceDir == Tools.Dir.Up)
        {
            transform.localPosition = new Vector3(0.53f, 0.25f, 0f);
            canSprite.flipX = false;
            canSprite.sortingOrder = -5;
        }
        else if (playerTools.faceDir == Tools.Dir.Down)
        {
            transform.localPosition = new Vector3 (0.53f, -0.76f, 0f);
            canSprite.flipX = false;
            canSprite.sortingOrder = 5;
        }
        else if (playerTools.faceDir == Tools.Dir.Left)
        {
            transform.localPosition = new Vector3(0f, -0.25f, 0f);
            canSprite.flipX = false;
            canSprite.sortingOrder = -5;
        }
        else if (playerTools.faceDir == Tools.Dir.Right)
        {
            transform.localPosition = new Vector3(0f, -0.25f, 0f);
            canSprite.flipX = true;
            canSprite.sortingOrder = -5;
        }
    }
}
