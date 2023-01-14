using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4Portals : MonoBehaviour
{
    [SerializeField] public float gravity;
    [SerializeField] public Rigidbody2D bodyToGiveGravity;
    [SerializeField] public float timeToStartExecuting;
    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer portal;
    private bool hasRun = false;
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
            StartCoroutine(Portals());
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
            toRun = true;
    }

    public IEnumerator Portals()
    {
        if(hasRun==false)
        {
            portal.enabled = true;
            anim.SetTrigger("open");
            yield return new WaitForSeconds(0.2f);

            anim.SetTrigger("opened");
            yield return new WaitForSeconds(timeToStartExecuting);
            bodyToGiveGravity.gravityScale = gravity;
            yield return new WaitForSeconds(0.5f);
            anim.SetTrigger("close");
            yield return new WaitForSeconds(0.5f);
            portal.enabled = false;
            hasRun = true;
            yield break;
        }
        yield break;
    }
}
