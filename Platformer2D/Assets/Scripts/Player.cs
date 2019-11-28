using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private Rigidbody2D body;
    
    Vector2 direction;
    
    [SerializeField]
    private float speed = 1;
    [SerializeField]
    private float maxSpeed = 10;

    private int health = 5;

    bool canJump = true;
    [Header("Jump")] private int maxJump = 2;
    [SerializeField] float jumpVelocity = 2.5f;
    [SerializeField] float raycastJumpLength = 1f;

    [SerializeField] float timeStopJump = 0.1f;
    float timerStopJump = 0;
    [SerializeField] float jumpFallingModifier = 1;

    enum State
    {
        IDLE,
        RUN,
        JUMP,
        DEAD
    }

    private State state = State.IDLE;
    
    void Start() 
    {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        body.velocity = direction;

        if (body.velocity.y < 0) {
            body.velocity = new Vector2(body.velocity.x, body.velocity.y * jumpFallingModifier);
        }

        body.velocity = Vector2.ClampMagnitude(body.velocity, maxSpeed);
    }

    void Update() 
    {
        
        direction = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
               
        CheckJump();

    }
    
    void CheckJump() 
    {
        timerStopJump -= Time.deltaTime;
        
        if (Input.GetAxis("Jump") > 0.1f && canJump) 
        {
            direction.y += jumpVelocity;

            canJump = false;

            timerStopJump = timeStopJump;
        }
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastJumpLength, LayerMask.NameToLayer("Player"));

        if (timerStopJump <= 0) {
            if (hit.rigidbody != null) {
                canJump = true;
            } else {
                canJump = false;
            }
        }
    }
    
    void OnDrawGizmos() 
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine((Vector2)transform.position, (Vector2)transform.position + Vector2.down * raycastJumpLength);
        
        Gizmos.DrawWireCube((Vector2) transform.position + Vector2.down * 0.5f, new Vector2(1f, 0.2f));
    }
    
}
