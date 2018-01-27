using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public Transform player;
    public float offset;
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(player.position.x + offset, transform.position.y, transform.position.z);
	}
}
