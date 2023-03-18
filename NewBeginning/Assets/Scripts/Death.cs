using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;
    private Scene scene;
    private string place;


    private void Awake()
    {
        scene = SceneManager.GetActiveScene();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Player")
        {
            DeathMenu();
        }
        
       
    }
    void DeathMenu()
    {
        switch (scene.name)
        {
            case ("Level1"):
                {
                    SceneManager.LoadScene(2);
                    break;
                }
            case ("Level2"):
                {
                    SceneManager.LoadScene(5);
                    break;

                }
            case ("Death1"):
                {
                    SceneManager.LoadScene(5);
                    break;

                }
            case ("Death2"):
                {
                    SceneManager.LoadScene(5);
                    break;

                }
            case ("Level3"):
                {
                    SceneManager.LoadScene(12);
                    break;

                }

            default:
                break;
        }
    }

    

    //IEnumerator Catch()
    //{
    //    yield return new WaitForSeconds(3f);
    //    yield break;




    //}
}

