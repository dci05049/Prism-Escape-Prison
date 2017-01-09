using UnityEngine;
using System.Collections;

public class bombscrit : MonoBehaviour {
	public GameObject explosion; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "ground") {
			Instantiate (explosion, new Vector2 (transform.position.x , transform.position.y + 3.3f) , transform.rotation); 
			Destroy (gameObject); 
		}
	}
}
