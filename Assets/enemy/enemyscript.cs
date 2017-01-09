using UnityEngine;
using System.Collections;

public class enemyscript : MonoBehaviour {
	public int health; 
	public GameObject bloodexplosion; 
	public GameObject bodyparts; 
	public bool walking = true; 
	private Rigidbody2D body2d; 
	private float speed = -5f;  
	private gamemanager gamemangerscript; 

	private Animator anim; 
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> (); 
		body2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		gamemangerscript = GameObject.FindObjectOfType<gamemanager> (); 

		if (health <= 0) {
			Instantiate (bodyparts, transform.position , transform.rotation); 
			Destroy (gameObject);
		}

		if (walking == false) {
			anim.SetBool ("shoot", true); 
			speed = 0f;
		}

		if (!gamemangerscript.playerdeath) {
			body2d.velocity = new Vector2 (speed, body2d.velocity.y);
		}
	}

	public void takedamage (int damage) {
		health -= damage; 
	}
}
