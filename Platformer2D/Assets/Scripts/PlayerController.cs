using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5f;
    private float movement = 0f;
    private Rigidbody2D body;

    private float jumpSpeed = 10f;
    private bool canJump = true;
    private float maxJump = 2;
    private float numberJump = 0;

    [SerializeField] Animator animator;
    private SpriteRenderer spriteRenderer_;
   
    private bool isLookingRight = true;
    private bool isLookingLeft = false;
    private float horizonzalMove;

    [SerializeField] private GameObject jumpSound;

    //[SerializeField] private GameObject movingPlatform;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer_ = GetComponent<SpriteRenderer>();
    }


    void Update()
    {

        movement = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(movement * speed, body.velocity.y);

        CheckJump();
        UpdateAnimation();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        //Jump
        canJump = true;
        numberJump = 0;
        animator.SetBool("OnGround", true);
        
    }

    void CheckJump()
    {

        if (Input.GetButtonDown("Jump") && canJump == true) 
        {
            body.velocity = new Vector2(body.velocity.x, jumpSpeed);
            numberJump++;

            animator.SetBool("OnGround", false);
            jumpSound.SetActive(true);
        }

        if (numberJump >= maxJump)
        {
            canJump = false;
            jumpSound.SetActive(false);
        }
        
    }

    void Respawn()
    {
 
    }

    void PlayerHealth()
    {
        
    }
    void UpdateAnimation()
    {
        animator.SetFloat("Speed",Mathf.Abs(body.velocity.x));
        horizonzalMove = Input.GetAxis("Horizontal");

        if (horizonzalMove < 0 && !isLookingLeft)
        {
            isLookingRight = false;
            isLookingLeft = true;
            animator.transform.Rotate(0,180,0);
        }

        if (horizonzalMove > 0 && !isLookingRight)
        {
            isLookingRight = true;
            isLookingLeft = false;
            animator.transform.Rotate(0,180,0);
        }
        
    }
}
