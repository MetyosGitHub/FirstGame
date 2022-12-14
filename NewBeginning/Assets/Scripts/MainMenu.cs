using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
    public void RestartScene()
    {

        Scene thisScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("Level1");
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("CutsceneStartLevel1");
    }
}
