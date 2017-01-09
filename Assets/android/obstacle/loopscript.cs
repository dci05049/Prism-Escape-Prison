using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loopscript : MonoBehaviour {

	public bool redloop; 
	public bool blueloop; 
	public bool grayloop; 

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay2D (Collider2D other) {
		if (redloop && other.name == "bluebird") {
			Destroy (other.gameObject); 
		} else if (blueloop && other.name == "redbird") {
			Destroy (other.gameObject);
		} else {
			Destroy (other.gameObject); 
		}
	}
}
