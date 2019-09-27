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

    public AudioSource music;
    public AudioClip bgMusic;
    public AudioClip winFanfare;
    public AudioClip loseFanfare;

    private void Awake()
    {
        currentGameState = GameState.Playing;
    }

    void Start()
    {
        winLoseScreen.SetActive(false);

        music.Stop();
        music.clip = bgMusic;
        music.Play();

        for (int i = 0; i < pots.Length; i++)
        {
            pots[i].ChangeSprite(plantPhaseSprites[0]);
            pots[i].ChangePhase(PlantPhases.Seed);
        }

        InvokeRepeating("CheckPlantGrowth", 0f, 0.5f);
    }

    void CheckPlantGrowth()
    {
        if (currentGameState == GameState.Playing)
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
        if (win)
        {
            music.Stop();
            music.clip = winFanfare;
            music.loop = false;
            music.Play();
        }
        else
        {
            music.Stop();
            music.clip = loseFanfare;
            music.loop = false;
            music.Play();
        }

        winLoseScreen.SetActive(true);
        winLoseScreen.GetComponent<WinLoseDisplay>().DisplayResult(win);

        Time.timeScale = 0;
    }
}
