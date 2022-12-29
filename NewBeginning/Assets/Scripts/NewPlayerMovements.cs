using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovements : MonoBehaviour
{
    //Harekteristiki
    [SerializeField] private float speed;
    [SerializeField] private float jump;
    [SerializeField] private AudioSource running;
    [SerializeField] private AudioSource jumping;
    [SerializeField] private AudioSource slide;
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
        if (velocityY > body.velocity.y+0.0001)
        {
           
                running.Stop();
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
    //Method for jumping
    private void Jump()
    {
        
        body.velocity = new Vector2(body.velocity.x, jump);
        running.Stop();
        jumping.Play();
        anim.SetTrigger("jump");
        grounded = false;
    }
    //Method for sliding
    private void Slide()
    {
        if(grounded)
        {
            slide.Play();
        }
        
        anim.SetTrigger("slide");
        body.velocity = new Vector2(speed * 0.8f, body.velocity.y);
        StartCoroutine(stopSlide());
    }
    //Check if Player's body has collided with the ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Ground")
            grounded = true;
        running.Play();


    }
    //Enumerator for stopping and controlling the Slide
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
