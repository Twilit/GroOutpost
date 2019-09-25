using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    float delay = 0.2f;

    void Start()
    {
        Invoke("ClearEffect", this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject, this.GetComponent<AudioSource>().clip.length + delay);
    }

    void ClearEffect()
    {
        this.GetComponent<SpriteRenderer>().enabled = false;
    }
}
