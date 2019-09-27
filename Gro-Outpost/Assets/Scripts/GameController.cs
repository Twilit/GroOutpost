using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public enum PlantPhases { Seed, Seedling, Bulb, Flower };

    public PlantPot[] pots;
    public Sprite[] plantPhaseSprites;

    void Start()
    {
        for (int i = 0; i < pots.Length; i++)
        {
            pots[i].ChangeSprite(plantPhaseSprites[0]);
            pots[i].ChangePhase(PlantPhases.Seed);
        }
    }

    void Update()
    {
        
    }
}
