using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwat : MonoBehaviour
{
    public Transform swatter;
    Animator swatAnim;

    bool swatting = false;

    void Start()
    {
        swatAnim = swatter.GetChild(0).GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !swatting)
        {
            SwingSwatter();
        }
    }

    void SwingSwatter()
    {
        swatting = true;
        swatAnim.SetTrigger("startSwat");
    }

    public void EndSwing()
    {
        swatting = false;

    }
}
