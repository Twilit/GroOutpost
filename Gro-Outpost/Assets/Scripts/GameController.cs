using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public enum PlantPhases { Seed, Seedling, Bulb, Flower };
    enum GameState { Playing, Win, Lose };
    GameState currentGameState;

    public PlantPot[] pots;
    public Sprite[] plantPhaseSprites;

    public GameObject winLoseScreen;

    private void Awake()
    {
        currentGameState = GameState.Playing;
    }

    void Start()
    {
        winLoseScreen.SetActive(false);

        for (int i = 0; i < pots.Length; i++)
        {
            pots[i].ChangeSprite(plantPhaseSprites[0]);
            pots[i].ChangePhase(PlantPhases.Seed);
        }

        InvokeRepeating("CheckPlantGrowth", 0f, 0.5f);
    }

    void CheckPlantGrowth()
    {
        for (int i = 0; i < pots.Length; i++)
        {
            if (pots[i] == null)
            {
                EndGame(false);
                return;
            }

            if (pots[i].currentPhase == GameController.PlantPhases.Flower)
            {
                EndGame(true);
            }

            if (pots[i].changeReady)
            {
                ChangeToNextPhase(i);
            }
        }
    }

    void ChangeToNextPhase(int i)
    {
        pots[i].changeReady = false;

        if (pots[i].currentPhase == GameController.PlantPhases.Seed)
        {
            pots[i].ChangeSprite(plantPhaseSprites[1]);
            pots[i].ChangePhase(PlantPhases.Seedling);
            pots[i].plantSounds.clip = pots[i].growSound;
            pots[i].plantSounds.Play();
        }
        else if (pots[i].currentPhase == GameController.PlantPhases.Seedling)
        {
            pots[i].ChangeSprite(plantPhaseSprites[2]);
            pots[i].ChangePhase(PlantPhases.Bulb);
            pots[i].plantSounds.clip = pots[i].growSound;
            pots[i].plantSounds.Play();
        }
        else if (pots[i].currentPhase == GameController.PlantPhases.Bulb)
        {
            pots[i].ChangeSprite(plantPhaseSprites[3]);
            pots[i].ChangePhase(PlantPhases.Flower);
            pots[i].plantSounds.clip = pots[i].flowerSound;
            pots[i].plantSounds.Play();
        }
    }

    void EndGame(bool win)
    {
        winLoseScreen.SetActive(true);
        winLoseScreen.GetComponent<WinLoseDisplay>().DisplayResult(win);
    }
}
