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
    public int pointsRange = 2;
    private Rigidbody2D rb;
    private float distanceToNextLineDown;
    private float distanceToNextLineUp;
    private float currentPoints;


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

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2Down());
        if (isHitDetected(ref hit))
        {
            distanceToNextLineDown = hit.distance;
            if (distanceToNextLineDown < pointsRange)
            {
                currentPoints += 1/distanceToNextLineDown;
                distanceToNextLineDown = 1000f;
                Debug.Log("Abajo");
            }
            //Debug.Log(distanceToNextLineDown);
        }
        RaycastHit2D hitUp = Physics2D.Raycast(transform.position, Vector2.up);
        if (isHitDetected(ref hitUp))
        {
            distanceToNextLineUp = hitUp.distance;
            if (distanceToNextLineUp < pointsRange)
            {
                currentPoints += 1/distanceToNextLineUp;
                distanceToNextLineUp = 1000f;
                Debug.Log("Arriba");
            }
            //Debug.Log(distanceToNextLineUp);
        }

        //Debug.Log("Puntos actuales: " + currentPoints);

    }

    private static Vector2 Vector2Down()
    {
        return -Vector2.up;
    }

    private static bool isHitDetected(ref RaycastHit2D hit)
    {
        return hit.collider != null;
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
