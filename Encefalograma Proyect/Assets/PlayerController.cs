using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float upSpeed = 1f;

	
	// Update is called once per frame
	void Update () {
        float translation = Input.GetAxis("Vertical") * upSpeed;
        translation *= Time.deltaTime;
        transform.Translate(0, translation, 0);
    }
}
