using UnityEngine;
using System.Collections;

public class bulletscript : MonoBehaviour {
	public float speed = 8f; 
	private Rigidbody2D body2d; 
	public GameObject blood; 

	public GameObject bulletafter;
	public bool sniper; 

	public int damage; 
	// Use this for initialization
	void Start () {
		body2d = GetComponent<Rigidbody2D> (); 
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "enemy") {
			other.GetComponent<enemyscript> ().takedamage (damage);
			Instantiate (blood, new Vector2 (transform.position.x + 0.5f, transform.position.y + 2f), transform.rotation);
			Instantiate (bulletafter, transform.position, transform.rotation); 
			other.gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (1f,2.5f) * 70f);  
			if (!sniper) {
				Destroy (gameObject); 
			}
		}

		if (other.tag == "bodyparts") {
			other.GetComponent<bodyblown> ().takedamage (damage);
			Instantiate (blood, new Vector2 (transform.position.x + 0.5f, transform.position.y + 1.3f), transform.rotation);
			other.gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (1f,2.5f) * 80f);  
			Instantiate (bulletafter, transform.position, transform.rotation); 
			Destroy (gameObject); 
		}

		if (other.tag == "helicopter") {
			other.GetComponent<helicopterscript> ().takedamage (damage);
			Instantiate (bulletafter, transform.position, transform.rotation); 
			Destroy (gameObject); 
		}

		if (other.tag == "tank") {
			other.GetComponent<tankhitscript> ().takedamage (damage);
			Instantiate (bulletafter, transform.position, transform.rotation); 
			Destroy (gameObject); 
		}

		if (other.tag == "ground") {
			Destroy (gameObject); 
			Instantiate (bulletafter, transform.position, transform.rotation); 
		}

		if (other.tag == "miltaryparachute") {
			other.GetComponent<miltaryscript> ().takedamage (damage);
			Instantiate (blood, new Vector2 (transform.position.x + 0.5f, transform.position.y + 2f), transform.rotation);
			Instantiate (bulletafter, transform.position, transform.rotation);  
			if (!sniper) {
				Destroy (gameObject); 
			}
		}
	}
}
