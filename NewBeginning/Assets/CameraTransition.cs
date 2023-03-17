using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cameraToTransition;
    [SerializeField] private Transform tFollow;
    private bool transition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transition)
        {
            StartCoroutine(Transition());
            
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            transition = true;

        }
    }

    IEnumerator Transition()
    {
        yield return new WaitForSeconds(4f);
        cameraToTransition.Priority = 12;
        yield break;




    }
}
