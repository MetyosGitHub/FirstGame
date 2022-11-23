using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3ScriptOfWood : MonoBehaviour
{
    [SerializeField] public float speed;
    private bool toRun = false;
    private BoxCollider2D boxCollider;
    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(toRun==true)
        {
            body.velocity = new Vector2(speed, body.velocity.y);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
            toRun = true;
    }
}
