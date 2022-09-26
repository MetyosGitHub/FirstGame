using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    [SerializeField] private float speed;
    private BoxCollider2D boxCollider;
    private Rigidbody2D body;


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        body.velocity = new Vector2(speed, body.velocity.y);
    }
}
