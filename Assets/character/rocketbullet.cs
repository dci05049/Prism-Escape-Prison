using UnityEngine;
using System.Collections;

public class rocketbullet : MonoBehaviour {
	public GameObject explosionrocket; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "enemy") {
			Instantiate (explosionrocket, new Vector2 (transform.position.x , other.transform.position.y + 5f) , other.transform.rotation); 
			Destroy (gameObject); 
		}

		if (other.tag == "miltaryparachute") {
			Instantiate (explosionrocket, new Vector2 (transform.position.x , other.transform.position.y + 5f) , other.transform.rotation); 
			Destroy (gameObject); 
		}

		if (other.tag == "ground") {
			Instantiate (explosionrocket, new Vector2 (transform.position.x , transform.position.y + 3f) , other.transform.rotation); 
			Destroy (gameObject); 
		}


	}
}
