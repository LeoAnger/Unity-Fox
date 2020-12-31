using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D coll;
    private Animator anim;

    public float speed, jumpForce;

    public Transform groundCheck;
    public LayerMask ground;

    public bool isGround, isJump;

    private bool jumpPressed;
    private int jumpCount;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && jumpCount > 0)
        {
            jumpPressed = true;
            
        }
    }

    void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground);
        
        GroundMovement();
        Jump();
        switchAnim();

    }

    void Jump()
    {
        if (isGround)
        {
            isJump = false;
            jumpCount = 2;
        }

        if (jumpPressed && isGround)
        {
            isJump = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount--;
            jumpPressed = false;
        }
        else if (jumpPressed && jumpCount > 0 && isJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount--;
            jumpPressed = false;
        }
    }
    
    void GroundMovement()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);

        if (horizontalMove != 0)
        {
            transform.localScale = new Vector3(horizontalMove, 1, 1);
        }
    }

    void switchAnim()
    {
        // 左右移动
        anim.SetFloat("running", Mathf.Abs(rb.velocity.x));

        if (isGround)
        {
            anim.SetBool("falling", false);
        } else if (!isGround && rb.velocity.y > 0)
        {
            // 跳跃
            anim.SetBool("jumping", true);
        } else if (rb.velocity.y < 0)
        {
            // 下落
            anim.SetBool("jumping", false);
            anim.SetBool("falling", true);
        }
    }
}































