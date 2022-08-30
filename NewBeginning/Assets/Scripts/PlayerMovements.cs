using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField]private LayerMask platformLayerMask;

    private Rigidbody2D body;
    private BoxCollider2D boxCollider2D;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        body.velocity = new Vector2(speed, body.velocity.y) ;

        if (Input.GetKey(KeyCode.Space) && IsGrounded())
            body.velocity = new Vector2(body.velocity.x, speed);
    }

    private bool IsGrounded() {
        float extraHeight = 0.5f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, extraHeight, platformLayerMask);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(boxCollider2D.bounds.center + new Vector3(boxCollider2D.bounds.extents.x, 0), Vector2.down * (boxCollider2D.bounds.extents.y + extraHeight), rayColor);
        Debug.DrawRay(boxCollider2D.bounds.center - new Vector3(boxCollider2D.bounds.extents.x, 0), Vector2.down * (boxCollider2D.bounds.extents.y + extraHeight), rayColor);
        Debug.DrawRay(boxCollider2D.bounds.center - new Vector3(boxCollider2D.bounds.extents.x, boxCollider2D.bounds.extents.y), Vector2.right * (boxCollider2D.bounds.extents.y + extraHeight), rayColor);
        return raycastHit.collider != null;
    }   
        

}
//
 