﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float upIncrement = 50f;
    private float minimumLimit;
    private float maximumLimit;
    public float limitThreshold = 0.0005f;
    public float pointsRange = 0.2f;
    private Rigidbody2D rb;
    private float distanceToNextLineDown;
    private float distanceToNextLineUp;
    private static float currentPoints;
    private GameObject cubePanelYScale;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cubePanelYScale = GameObject.FindWithTag("cubePanel");
        //Debug.Log(cubePanelYScale);
        //Debug.Log(cubePanelYScale.transform.lossyScale.y);
        maximumLimit = cubePanelYScale.transform.lossyScale.y + limitThreshold;
        minimumLimit = (cubePanelYScale.transform.lossyScale.y / 2) / 2;
       // Debug.Log(maximumLimit);
        //Debug.Log(minimumLimit);
        

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

        //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2Down());
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, Vector2Down());
        foreach (var h in hit)
        {
           // Debug.Log("Fuera");
            //Debug.Log(h.collider);
            if ( h.collider.CompareTag("Player")) { continue; }
            if (h.collider.CompareTag("Limit")) { continue; }
            //Debug.Log("En medio");
            if (h.collider is EdgeCollider2D)
            {
                distanceToNextLineDown = h.distance;
                //Debug.Log("Dentro");
                if (isNextDownLineNear())
                {   
                    
                    //Debug.Log(distanceToNextLineDown);
                    incrementPoints(distanceToNextLineDown);
                    distanceToNextLineDown = reset();

                }
            }
        }

        RaycastHit2D[] hitUp = Physics2D.RaycastAll(transform.position, Vector2.up);
        foreach (var h in hitUp)
        {
            // Debug.Log("Fuera");
            //Debug.Log(h.collider);
            if (h.collider.CompareTag("Player")) { continue; }
            if (h.collider.CompareTag("Limit")) { continue; }
            //Debug.Log("En medio");
            if (h.collider is EdgeCollider2D)
            {
                distanceToNextLineUp = h.distance;
                //Debug.Log("Dentro");
                if (isNextUpLineNear())
                {

                    //Debug.Log(distanceToNextLineUp);
                    incrementPoints(distanceToNextLineUp);
                    distanceToNextLineUp = reset();

                }
            }
        }


       
    }

    public int getCurrentPoints()
    {
        return (int)currentPoints;
    }

    public void setCeroPoints()
    {
        currentPoints=0;
    }

    private bool isNextUpLineNear()
    {
        return GetDistanceToNextLineUp() < pointsRange;
    }

    private float GetDistanceToNextLineUp()
    {
        return distanceToNextLineUp;
    }

    private bool isNextDownLineNear()
    {
        return distanceToNextLineDown < pointsRange;
    }

    private static float reset()
    {
        return 1000f;
    }

    private void incrementPoints(float distanceToNextLine)
    {
        currentPoints += distanceToNextLine;
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
