using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwat : MonoBehaviour
{
    public Transform swatter;
    public PlayerMove playerMove;
    Animator swatAnim;
    AudioSource swingSound;
    public GameObject hitEffect;
    public bool swatting = false;

    void Start()
    {
        swatAnim = swatter.GetChild(0).GetComponent<Animator>();
        swingSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !swatting)
        {
            SwingSwatter();
        }
    }

    private void FixedUpdate()
    {
        SetSwatterDir();
    }

    void SwingSwatter()
    {
        swatting = true;
        swatAnim.SetTrigger("startSwat");

        swingSound.pitch = Random.Range(0.9f, 1.1f);
        swingSound.Play();
    }

    public void EndSwing()
    {
        swatting = false;

    }

    void SetSwatterDir()
    {
        if (playerMove.faceDir == PlayerMove.Dir.Up)
        {
            swatter.eulerAngles = new Vector3(0, 0, 180);
        }
        else if (playerMove.faceDir == PlayerMove.Dir.Down)
        {
            swatter.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (playerMove.faceDir == PlayerMove.Dir.Left)
        {
            swatter.eulerAngles = new Vector3(0, 0, 270);
        }
        else if (playerMove.faceDir == PlayerMove.Dir.Right)
        {
            swatter.eulerAngles = new Vector3(0, 0, 90);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<EnemyAI>().DealDamage(1);

            Instantiate(hitEffect, collision.transform.position, Quaternion.identity);
            collision.GetComponent<Rigidbody2D>().velocity = (collision.transform.position - swatter.position).normalized * 20;
        }
    }
}
