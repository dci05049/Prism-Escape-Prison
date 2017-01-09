using UnityEngine;
using System.Collections;

public class playerscript2 : MonoBehaviour {

	private Rigidbody2D body2d; 
	private bool presseddown; 

	private Animator anim; 
	// Use this for initialization
	void Start () {
		body2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> (); 
	}
	
	// Update is called once per frame
	void Update () {
		body2d.velocity = new Vector2 (3, body2d.velocity.y); 


		if (presseddown) {
			body2d.AddForce (Vector2.down * 25f);
			Debug.Log ("up");
		}

		if (transform.position.y >= 8.37f && !presseddown) {
			body2d.gravityScale = 0f;
			body2d.velocity = new Vector2 (body2d.velocity.x, 0); 
		} else {
			body2d.gravityScale = -1f; 
		}

	}

	public void fly () {
		presseddown = true; 
		anim.SetBool ("redglide", true); 
	}

	public void flydisable () {
		presseddown = false; 
		anim.SetBool ("redglide", false); 
	}
}
