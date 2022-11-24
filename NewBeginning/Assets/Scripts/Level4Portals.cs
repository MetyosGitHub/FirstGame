using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4Portals : MonoBehaviour
{
    [SerializeField] public float gravity;
    [SerializeField] public Rigidbody2D bodyToGiveGravity;
    private bool toRun = false;
    private BoxCollider2D boxCollider;
    

    // Start is called before the first frame update
    void Start()
    {
        
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (toRun == true)
        {
            bodyToGiveGravity.gravityScale = gravity;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
            toRun = true;
    }
}
