using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveManager : MonoBehaviour {

    private Rigidbody2D rb;
    public float velocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update ()
    {
        rb.velocity = new Vector2(velocity, rb.velocity.y);
    }
}
