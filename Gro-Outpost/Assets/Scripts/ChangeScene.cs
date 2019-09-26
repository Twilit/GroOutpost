using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public void GotoMainMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void GotoLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }
    public void GotoStartGame()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void GotoLevel2()
    {
        SceneManager.LoadScene("Stage2");
    }
    public void GotoLevel3()
    {
        SceneManager.LoadScene("Stage3");
    }
    public void GotoCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void GotoControls()
    {
        SceneManager.LoadScene("Controls");
    }
}
