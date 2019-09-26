using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwat : MonoBehaviour
{
    public Transform swatter;
    public Tools playerTools;
    Animator swatAnim;
    AudioSource swingSound;
    public GameObject hitEffect;

    public bool swatting = false;
    public bool startSwat = false;

    void Start()
    {
        swatAnim = swatter.GetChild(0).GetComponent<Animator>();
        swingSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !swatting)
        {
            startSwat = true;
        }
    }

    private void FixedUpdate()
    {
        SetSwatterDir();

        if (startSwat)
        {
            SwingSwatter();
            startSwat = false;
        }
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
        if (playerTools.faceDir == Tools.Dir.Up)
        {
            swatter.eulerAngles = new Vector3(0, 0, 180);
        }
        else if (playerTools.faceDir == Tools.Dir.Down)
        {
            swatter.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (playerTools.faceDir == Tools.Dir.Left)
        {
            swatter.eulerAngles = new Vector3(0, 0, 270);
        }
        else if (playerTools.faceDir == Tools.Dir.Right)
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
