using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantPot : MonoBehaviour
{
    GameController.PlantPhases currentPhase;
    SpriteRenderer plantSprite;

    float growthTimer = 0f;
    bool needWater = false;

    public Text waterText;

    void Start()
    {
        plantSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();

        growthTimer = 0f;
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
    }

    void NeedWaterTimer()
    {
        if (growthTimer < 30f)
        {
            growthTimer += Time.deltaTime;
        }
        else
        {

        }
    }

    IEnumerator NeedWaterIndicator()
    {
        while(true)
        {
            waterText.text = "";
            yield return new WaitForSeconds(0.5f);
            waterText.text = "WATER!";
            yield return new WaitForSeconds(0.5f);
        }
    }
}
