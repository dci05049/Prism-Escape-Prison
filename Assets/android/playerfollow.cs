using UnityEngine;
using System.Collections;

public class playerfollow : MonoBehaviour {
	private Transform playertransform; 

	// Use this for initialization
	void Start () {
		playertransform = GameObject.FindObjectOfType<playerscript> ().transform; 
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector2 (playertransform.position.x, transform.position.y);
	}
}
