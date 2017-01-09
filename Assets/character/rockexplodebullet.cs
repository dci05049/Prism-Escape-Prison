using UnityEngine;
using System.Collections;

public class rockexplodebullet : MonoBehaviour {

	public int damage; 
	public GameObject blood; 
	// Use this for initialization
	void Start () {
		GameObject.FindObjectOfType<camerashake> ().GetComponent<camerashake> ().Shake (0.1f, 0.07f); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "enemy") {
			other.GetComponent<enemyscript> ().takedamage (damage);
			Instantiate (blood, new Vector2 (transform.position.x + 0.5f, transform.position.y + 2f), transform.rotation);
			other.gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (1f,2.5f) * 70f);  
		}

		if (other.tag == "miltaryparachute") {
			other.GetComponent<miltaryscript> ().takedamage (damage);
			Instantiate (blood, new Vector2 (transform.position.x + 0.5f, transform.position.y + 2f), transform.rotation);
			other.gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (1f,2.5f) * 70f); 
		}
			
	}
}
