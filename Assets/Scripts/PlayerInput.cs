using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool IsGrounded=false;
    
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpHeight = 5f;
    
    private Vector2 direction = Vector2.zero;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    
    void OnMove(InputValue value)
    {
        Vector2 direction = value.Get<Vector2>();
        Debug.Log(direction);
        this.direction = direction;

    }
    
    void Update()
    {
        Move(direction.x);
    }

    private void Move(float x)
    {
        rb.velocity = new Vector2(x * speed, rb.velocity.y);
        
    }
    
    void OnJump()
    {
        if (IsGrounded)
        {
            Jump();
        }

        
    }
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        IsGrounded = false;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (Vector2.Angle(collision.GetContact(0).normal, Vector2.up) < 45f)
        {
            IsGrounded = true;
            
        }
        else
        {
            IsGrounded = false;
        }
    }
}
