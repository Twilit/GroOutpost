using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

        public void GotoMainScene()
        {
            SceneManager.LoadScene("Stage1");
        }
    public void GotoLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
