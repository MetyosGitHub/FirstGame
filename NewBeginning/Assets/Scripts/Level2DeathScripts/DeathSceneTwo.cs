using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathSceneTwo : MonoBehaviour
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
        SceneManager.LoadScene(7);


    }




    //IEnumerator Catch()
    //{
    //    yield return new WaitForSeconds(3f);
    //    yield break;




    //}
}

