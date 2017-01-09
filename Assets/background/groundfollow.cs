using UnityEngine;
using System.Collections;

public class groundfollow : MonoBehaviour {
	private Transform playerposition; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		playerposition = GameObject.FindGameObjectWithTag ("player").transform;  
		transform.position = new Vector2 (playerposition.position.x + 5f, transform.position.y); 
	}
}
