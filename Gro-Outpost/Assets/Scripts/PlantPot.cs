using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantPot : MonoBehaviour
{
    public GameController.PlantPhases currentPhase;
    public SpriteRenderer plantSprite;
    public SpriteRenderer cracks;
    public Sprite crack1;
    public Sprite crack2;

    int health = 3;

    float growthTimer = 0f;
    bool needWater = false;

    public bool changeReady = false;

    public Text waterText;

    public AudioSource plantSounds;
    public AudioClip growSound;
    public AudioClip flowerSound;

    void Start()
    {
        health = 3;
        growthTimer = 0f;
        waterText.text = "";
        cracks.enabled = false;
        plantSounds = GetComponent<AudioSource>();
        StartCoroutine("NeedWaterIndicator");
    }

    void Update()
    {
        NeedWaterTimer();
    }

    public void ChangeSprite(Sprite newSprite)
    {
        plantSprite.sprite = newSprite;
    }
    public void ChangePhase(GameController.PlantPhases newPhase)
    {
        currentPhase = newPhase;
        growthTimer = 0f;
    }

    void NeedWaterTimer()
    {
        if (currentPhase != GameController.PlantPhases.Flower && !changeReady)
        {
            if (growthTimer < 15f)
            {
                growthTimer += Time.deltaTime;
            }
            else
            {
                needWater = true;
            }
        }
    }

    public void ChangeToNextPhase()
    {
        changeReady = false;
        growthTimer = 0f;
    }

    IEnumerator NeedWaterIndicator()
    {
        while(true)
        {
            if (needWater)
            {
                waterText.text = "";
                yield return new WaitForSeconds(0.5f);
                waterText.text = "WATER!";
                yield return new WaitForSeconds(0.5f);
            }
            else
            {
                waterText.text = "";
                yield return new WaitForSeconds(0.5f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (needWater && collision.tag == "Water")
        {
            needWater = false;
            changeReady = true;
        }
        else if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            DamagePlant(1);
        }
    }

    void DamagePlant(int damage)
    {
        health -= damage;

        if (health == 2)
        {
            cracks.enabled = true;
            cracks.sprite = crack1;
        }
        else if (health == 1)
        {
            cracks.enabled = true;
            cracks.sprite = crack2;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
