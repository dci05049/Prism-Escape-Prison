using UnityEngine;
using System.Collections;

public class policebullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "player") {
			other.GetComponent<characterscript> ().playertakedamage (20);
			other.gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (1f, 2.5f) * 70f);  
			Destroy (gameObject); 
		}
	}
}
