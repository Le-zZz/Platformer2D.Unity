using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] float timeToFall = 0.05f;
    private float timerToFall = 0f;
    [SerializeField] float timeToRespawn = 4f;
    private float timerToRespawn = 0f;
    private bool isTriggered = false;
    Vector3 originalPosition;

    void Start()
    {
        body = transform.GetComponent<Rigidbody2D>();
        originalPosition = transform.position;
    }
    
    void Update()
    {

        switch(state)
        {
            case State.IDLE:

                timerToFall = timeToFall;
                timerToRespawn = timeToRespawn;
                body.bodyType = RigidbodyType2D.Static;
                break;
            case State.WAITING_TO_FALL:
                timerToFall -= Time.deltaTime;
                if(timerToFall <= 0)
                {
                    state = State.FALLING;
                }
                break;
            case State.FALLING:
                body.bodyType = RigidbodyType2D.Dynamic;
                timerToRespawn -= Time.deltaTime;
                if (timerToRespawn <= 0)
                {
                    state = State.RESPAWN;
                }
                break;
            case State.RESPAWN:
                body.position = originalPosition;
                state = State.IDLE;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        state = State.WAITING_TO_FALL;
    }

    enum State
    {
        IDLE,
        WAITING_TO_FALL,
        FALLING,
        RESPAWN
    }
    State state = State.IDLE;

}
