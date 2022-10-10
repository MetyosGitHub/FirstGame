using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private Scene scene;
    private void Awake()
    {
        scene = SceneManager.GetActiveScene();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       if(other.tag == "Player")
        {
            switch (scene.name)
            {
                case ("Level1"):
                    {
                        SceneManager.LoadScene(3);
                        break;
                    }
                case ("CutsceneEndLevel1"):
                    {
                        SceneManager.LoadScene(4);
                        break;
                    }
                case ("CutsceneStartLevel1"):
                    {
                        SceneManager.LoadScene(2);
                        break;
                    }
                case ("Level2"):
                    {
                        SceneManager.LoadScene(8);
                        break;
                    }
                case ("CutsceneEndLevel2"):
                    {
                        SceneManager.LoadScene(9);
                        break;
                    }
                case ("CutsceneStartLevel2"):
                    {
                        SceneManager.LoadScene(5);
                        break;
                    }

                default:
                    break;
            }
            //Scene thisScene = SceneManager.GetActiveScene();
            //SceneManager.LoadScene(thisScene.buildIndex + 1);
        }
    }

    

    //IEnumerator Catch()
    //{
    //    yield return new WaitForSeconds(3f);
    //    yield break;




    //}
}

