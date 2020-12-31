using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class player : MonoBehaviour
{

    public Rigidbody2D rb;
    public Animator anim;
    public Collider2D coll;
    public LayerMask ground;

    public float speed;
    public float jumpforce;

    private bool isKeyJ = false;

    public static bool isJump = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        ExitGame();
        ChangeAnim();   // anim
    }

    private int i = 0;
    // 接收键盘
    void FixedUpdate()
    {
//        Jump();    // Jump
        if (Input.GetKeyDown(KeyCode.J))
        {
            print("按下J次数" + i++);
            if (!isKeyJ)
            {
                isKeyJ = true;
            }
        }
        Movement();     // left, right
    }

    private void ExitGame()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void Jump()
    {
        // throw new NotImplementedException();
        if (isKeyJ && isJump)
        {
            isJump = false;
            print("Jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            anim.SetBool("jumping", true);
        }
        
    }

    private float horizonalmentmove;
    private float facedirection;
    private Vector2 localScaleVector2 = new Vector2(1,1);
    private Vector2 rbVector2;
    private void Movement()
    {
        horizonalmentmove = Input.GetAxis("Horizontal");    // 范围： [-1， 1]    类型：float
        facedirection = Input.GetAxisRaw("Horizontal");     // 范围： -1， 0， 1  类型：int
        if(horizonalmentmove != 0)
        {
            // 有位移
            rbVector2.x = horizonalmentmove * speed;
            rbVector2.y = rb.velocity.y;
            rb.velocity = rbVector2;
            anim.SetFloat("running", Mathf.Abs(facedirection));
        }
        if(facedirection  != 0)
        {
            localScaleVector2.x = facedirection;
            transform.localScale = localScaleVector2;
        }
    }


    void ChangeAnim()
    {
        anim.SetBool("idle", false);
        if(anim.GetBool("jumping"))
        {
            // jump --> fall
            if(rb.velocity.y < 0)
            {
                anim.SetBool("jumping", false);
                anim.SetBool("falling", true);
            
            }
        } else if(coll.IsTouchingLayers(ground))
        {
            // 落到地面
            anim.SetBool("falling", false);
            anim.SetBool("idle", true);
            // 更新Jump值
            isKeyJ = false;
        }
    }
}
