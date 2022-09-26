using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    

    void OnTriggerEnter2D(Collider2D other)
    {
       if(other.tag == "Player")
        {
            Scene thisScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(thisScene.buildIndex + 1);
        }
    }

    

    //IEnumerator Catch()
    //{
    //    yield return new WaitForSeconds(3f);
    //    yield break;




    //}
}

