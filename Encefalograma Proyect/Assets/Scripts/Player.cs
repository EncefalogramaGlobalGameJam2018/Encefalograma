using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float upIncrement = 1f;
    [Range(-100, -1)]
    public int minimumLimit;
    [Range(1, 100)]
    public int maximumLimit;
    private Rigidbody2D rb;
    private float distanceToNextLineDown;
    private float distanceToNextLineUp;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }



    // Update is called once per frame
    void Update()
    {

        if (isSpacePressed())
        {
            move();
        }

        if (isPlayerBelowMinimumLimit())
        {
            stopMovement();
            bounceUpwards();

        }
        if (isPlayerAboveMaximumLimit())
        {
            stopMovement();
            bounceDownwards();
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
        if (hit.collider != null)
        {
            distanceToNextLineDown = hit.distance;
        }
        RaycastHit2D hitUp = Physics2D.Raycast(transform.position, Vector2.up);
        if (hitUp.collider != null)
        {
            distanceToNextLineUp = hitUp.distance;
            Debug.Log(distanceToNextLineUp);
        }


    }

    private void bounceDownwards()
    {
        Vector3 movement = new Vector3(0, -upIncrement, 0);

        rb.AddForce(movement);
    }

    private void bounceUpwards()
    {
        Vector3 movement = new Vector3(0, upIncrement, 0);

        rb.AddForce(movement);
    }

    private void stopMovement()
    {
        rb.velocity = Vector2.zero;
    }

    private bool isPlayerAboveMaximumLimit()
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


}
