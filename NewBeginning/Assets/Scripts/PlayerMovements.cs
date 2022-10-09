using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerMovements : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float jump;
    [SerializeField] private float cameraSpeed;
    [SerializeField] private AudioSource running;
    [SerializeField] private AudioSource runningGravel;
    [SerializeField] private AudioSource runningBuilding;
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioSource jumping;
    [SerializeField] private AudioSource sliding;
    [SerializeField] private AudioSource slidingGravel;
    [SerializeField] private AudioSource slidingBuilding;
    [SerializeField] private CinemachineVirtualCamera cameraToZoom;
    public Vector3[] Target;
    private BoxCollider2D boxCollider;
    private Rigidbody2D body;
    private Animator anim;
    private string slideSound;
    private bool grounded;
    private bool slideAuthority;
    private bool fall;
    private bool needToZoom;
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
        if(needToZoom)
        {
            cameraToZoom.m_Lens.OrthographicSize = Mathf.Lerp(cameraToZoom.m_Lens.OrthographicSize, 7, cameraSpeed);
        }
        //while (needToZoom)
        //{
        //    while (cameraToZoom.m_Lens.OrthographicSize <= 7)
        //    {
        //        cameraToZoom.m_Lens.OrthographicSize = Mathf.Lerp(cameraToZoom.m_Lens.OrthographicSize, 8, cameraSpeed);

        //    }
        //    needToZoom = false;
        //}
        if (grounded&&!running.isPlaying)
        {
            //running.Play();
            
        }
        else if(!grounded)
        {
            running.Stop();
            runningBuilding.Stop();
            runningGravel.Stop();
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
        runningBuilding.Stop();
        runningGravel.Stop();
        jumping.Play();
        anim.SetTrigger("jump");
        grounded = false;
    }

    private void Slide()
    {
        slideAuthority = false;
        if(grounded)
        {
            switch (slideSound)
            {
                case ("Gravel"):

                    slidingGravel.Play();
                    runningGravel.Pause();

                    break;
                case ("Ground"):


                    running.Pause();
                    sliding.Play();
                    break;
                case ("Building"):


                    slidingBuilding.Play();
                    runningBuilding.Pause();

                    break;
                default:
                    break;
            }
            
        }
        
        anim.SetTrigger("slide");
        body.velocity = new Vector2(speed * 0.8f, body.velocity.y);
        boxCollider.enabled = false;
        StartCoroutine(stopSlide());
       

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Gravel" || collision.gameObject.tag == "Building")
        {
            grounded = true;
            slideAuthority = true;
            switch(collision.gameObject.tag)
            {
                case ("Gravel"):
                    slideSound = "Gravel";
                    runningGravel.Play();
                    runningBuilding.Stop();
                    running.Stop();
                    break;
                case ("Ground"):
                    slideSound = "Ground";
                    runningGravel.Stop();
                    runningBuilding.Stop();
                    running.Play();
                    break;
                case ("Building"):
                    slideSound = "Building";
                    runningGravel.Stop();
                    runningBuilding.Play();
                    running.Stop();
                    break;
                default:
                    break;
            }
        }

        if (collision.gameObject.tag == "Transition")
        {
            needToZoom = true;
           
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
