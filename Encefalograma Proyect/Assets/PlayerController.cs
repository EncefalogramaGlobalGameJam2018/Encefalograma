using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float upIncrement = 1f;
    public int minimumLimit;
    public int maximumLimit;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }



    // Update is called once per frame
    void Update ()
    {


        if (isSpacePressed())
        {
            if (isPlayerBelowMaximumLimit())

            {
                move();
            }
 
        }

        if (isPlayerBelowMinimumLimit())
        {
            stopMovement();

        }
        if (isPlayerAboxMaximumLimit())
        {
            stopMovement();
        }


    }

    private void stopMovement()
    {
        rb.velocity = Vector2.zero;
    }

    private bool isPlayerAboxMaximumLimit()
    {
        return transform.position.y > maximumLimit;
    }

    private bool isPlayerBelowMinimumLimit()
    {
        return transform.position.y < minimumLimit;
    }

    private static bool isSpacePressed()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    private void move()
    {
        Vector3 movement = new Vector3(0, upIncrement, 0);

        rb.AddForce(movement);
    }

    private bool isPlayerBelowMaximumLimit()
    {
        return transform.position.y < maximumLimit;
    }
}
