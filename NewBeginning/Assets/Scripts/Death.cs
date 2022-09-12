using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;

     void OnTriggerEnter2D(Collider2D other)
    {
        //StartCoroutine(Catch());
       DeathScene();
       
    }

    public void DeathScene()
    {
        
        
        SceneManager.LoadScene(2);
    }

    //IEnumerator Catch()
    //{
    //    yield return new WaitForSeconds(3f);
    //    yield break;




    //}
}

