using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformVertical : MonoBehaviour
{
    Rigidbody2D body;

    Vector2 direction = new Vector2(0, 1);

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        body.velocity = direction;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 1)
        {
            direction.y = 1;
        }
        else if (transform.position.y > 20)
        {
            direction.y = -1;
        }
    }
}
