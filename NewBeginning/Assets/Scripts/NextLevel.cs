using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
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
                        StartCoroutine(LoadLevel(3));
                        
                        break;
                    }
                case ("CutsceneEndLevel1"):
                    {
                        StartCoroutine(LoadLevel(4));
                        break;
                    }
                case ("CutsceneStartLevel1"):
                    {
                        StartCoroutine(LoadLevel(2));
                        break;
                    }
                case ("Level2"):
                    {
                        StartCoroutine(LoadLevel(8));
                        break;
                    }
                case ("CutsceneEndLevel2"):
                    {
                        StartCoroutine(LoadLevel(9));
                        break;
                    }
                case ("CutsceneStartLevel2"):
                    {
                        StartCoroutine(LoadLevel(5));
                        break;
                    }

                default:
                    break;
            }
            //Scene thisScene = SceneManager.GetActiveScene();
            //SceneManager.LoadScene(thisScene.buildIndex + 1);
        }
       IEnumerator LoadLevel(int levelIndex)
        {
            transition.SetTrigger("Start");

            yield return new WaitForSeconds(transitionTime);
            SceneManager.LoadScene(levelIndex);
        }
    }

    

    //IEnumerator Catch()
    //{
    //    yield return new WaitForSeconds(3f);
    //    yield break;




    //}
}

