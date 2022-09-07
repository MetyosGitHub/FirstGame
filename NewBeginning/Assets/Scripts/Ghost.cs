using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayerMask;
    private bool isClose;
    private Animator anim;
    private CircleCollider2D body;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<CircleCollider2D>();
    }
    // Update is called once per frame
    void Update()
    {

        RaycastHit2D hit = Physics2D.Raycast(body.bounds.center, Vector2.right, 3f, playerLayerMask);
        if(hit.collider != null) 
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.right) * 3f, Color.green);
            isClose = true;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.right) * 3f, Color.red);
            isClose = false;

        }
        anim.SetBool("isClose", isClose);
        
    }
}
