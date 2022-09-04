using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{

    [SerializeField] private float speed;
    private BoxCollider2D boxCollider;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    private bool slideAuthority;

    private void Awake()
    {
        //Grabs references for rigidbody and animator from game object.
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

    }

    private void Update()
    {

        body.velocity = new Vector2(speed, body.velocity.y);



        if (Input.GetKey(KeyCode.Space) && grounded)
            Jump();
        if (Input.GetKey(KeyCode.LeftShift) && grounded && slideAuthority)
        {
            Slide();
        }
        //sets animation parameters

        anim.SetBool("grounded", grounded);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("jump");
        grounded = false;
    }

    private void Slide()
    {
        slideAuthority = false;

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
}
//
