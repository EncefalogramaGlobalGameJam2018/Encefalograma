using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Poits : MonoBehaviour {
    public Player myPlayer;
    public Text points; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        points.text = myPlayer.getCurrentPoints().ToString();

    }
}
