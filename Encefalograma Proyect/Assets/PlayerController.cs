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
    void Update () {


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (transform.position.y < maximumLimit)
                
            {
                Debug.Log("Y is: " + transform.position.y + "maximum: " + maximumLimit);
                Vector3 movement = new Vector3(0, upIncrement, 0);

                rb.AddForce(movement);
            }

            
        }
        
        
        
    }
}
