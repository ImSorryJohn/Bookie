using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    //Movement
    public float walkSpeed = 5f;
    public float runMultiplier = 1.5f;

    //Jumping
    public float jumpForce = 12f;
    public int maxJumps = 2;

    private Rigidbody2D rb;
    private int jumpsLeft;
    private bool isGrounded;

    //Ground Check
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private bool facingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpsLeft = maxJumps;
    }

    private void Update()
    {
        //movement 
        float moveInput = Input.GetAxisRaw("Horizontal");
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        float speed = walkSpeed * (isRunning ? runMultiplier : 1f);
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        //Sprite Flip
        if (moveInput > 0 && !facingRight) Flip();
        if (moveInput < 0 && facingRight) Flip();

        //Ground Check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded);
        {
            jumpsLeft = maxJumps;//resets the jump when on ground 
        }

        //jump
        if (Input.GetButtonDown("Jump") && jumpsLeft > 0)
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f); //reset for jump hight
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        jumpsLeft--;
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    
    private void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }



   
}
