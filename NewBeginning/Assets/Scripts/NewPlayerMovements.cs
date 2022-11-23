using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovements : MonoBehaviour
{
    //Harekteristiki
    [SerializeField] private float speed;
    [SerializeField] private float jump;
    private BoxCollider2D boxCollider;
    private Rigidbody2D body;
    private Animator anim;
    private float velocityY=5f;
    private bool grounded;
    private bool slideAuthority = true;
    private bool fall;

    private void Awake()
    {
        //Grabs references for rigidbody and animator from game object.
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();



    }

    // Update is called once per frame
    void Update()
    {


        //Movement and Jump and Slide
       
        if (grounded)
        {
            body.velocity = new Vector2(speed, body.velocity.y);
            if (Input.GetKey(KeyCode.Space))
            {
                Jump();
            }
        }
        if (Input.GetKey(KeyCode.LeftShift) && slideAuthority)
        {
            Slide();
        }
        //Animations about Falling
        if (velocityY > body.velocity.y+0.1)
        {
            fall = true;
        }
        else
        {
            fall = false;
        }
        velocityY = body.velocity.y;

        anim.SetBool("fall", fall);
        
        anim.SetBool("grounded", grounded);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jump);

        anim.SetTrigger("jump");
        grounded = false;
    }
    private void Slide()
    {
        anim.SetTrigger("slide");
        body.velocity = new Vector2(speed * 0.8f, body.velocity.y);
        StartCoroutine(stopSlide());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Ground")
            grounded = true;
       
    }

    IEnumerator stopSlide()
    {
        boxCollider.enabled = false;
        yield return new WaitForSeconds(1f);
        slideAuthority = false;
        boxCollider.enabled = true;
        yield return new WaitForSeconds(1f);
        slideAuthority = true;
        yield break;




    }
}
