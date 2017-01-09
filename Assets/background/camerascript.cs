using UnityEngine;
using System.Collections;

public class camerascript : MonoBehaviour {

	private Transform playerposition; 
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		
		playerposition = GameObject.FindObjectOfType<playerscript> ().transform;  
		transform.position = new Vector3 (playerposition.position.x + 3f, transform.position.y, -10); 
	}
}
