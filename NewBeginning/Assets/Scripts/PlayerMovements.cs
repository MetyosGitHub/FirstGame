using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float jump;
    [SerializeField] private AudioSource running;
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioSource jumping;
    [SerializeField] private AudioSource sliding;
    private BoxCollider2D boxCollider;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    private bool slideAuthority;
    private bool fall;
    private float velocityY = 5f;

    private void Awake()
    {
        //Grabs references for rigidbody and animator from game object.
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

    }

    private void FixedUpdate()
    {
        if(grounded&&!running.isPlaying)
        {
            running.Play();
            
        }
        else if(!grounded)
        {
            running.Stop();
        }
        //else if(grounded && running.isPlaying)
        //{ 
        //    running.
        //}
        
        if (velocityY > body.velocity.y)
        {
            fall = true;
        }
        else
        {
            fall = false;
        }
        body.velocity = new Vector2(speed, body.velocity.y);

        velocityY = body.velocity.y;
        
        if (Input.GetKey(KeyCode.Space) && grounded)
            Jump();
        if (Input.GetKey(KeyCode.LeftShift)  && slideAuthority)
        {
            Slide();
        }
        //sets animation parameters
        anim.SetBool("fall", fall);
        anim.SetBool("grounded", grounded);
    }

    private void Update()
    {
      
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jump);
        running.Stop();
        jumping.Play();
        anim.SetTrigger("jump");
        grounded = false;
    }

    private void Slide()
    {
        slideAuthority = false;
        if(grounded)
        {
            sliding.Play();
        }
        
        anim.SetTrigger("slide");
        body.velocity = new Vector2(speed * 0.8f, body.velocity.y);
        boxCollider.enabled = false;
        StartCoroutine(stopSlide());

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            slideAuthority = true;
        }


    }

    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(0.75f);
        boxCollider.enabled = true;
        yield break;

        


    }

    IEnumerator playSound()
    {
        yield return new WaitForSeconds(11f);
        yield break;
    }
}
//
