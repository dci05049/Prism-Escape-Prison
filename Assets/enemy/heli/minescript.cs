using UnityEngine;
using System.Collections;

public class minescript : MonoBehaviour {

	public GameObject mineexplosion; 
	private gamemanager gamemangerscript; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gamemangerscript = GameObject.FindObjectOfType<gamemanager> (); 
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "player") {
			other.GetComponent<characterscript> ().playertakedamage (20); 
			Instantiate (mineexplosion, new Vector2 (transform.position.x , transform.position.y + 3.3f) , transform.rotation); 
			Destroy (gameObject); 
		}
	}
}
