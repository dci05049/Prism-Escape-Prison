using UnityEngine;
using System.Collections;

public class gunscript : MonoBehaviour {
	public Transform target; 
	public float firerate = 0;
	public bool facingright = true; 

	public float timetofire = 0; 
	public Transform firepoint; 

	public GameObject bullet; 
	public float firedelay = 0.03f; 
	float cooldowntimer = 0f; 
	public bool shooting = false; 

	public GameObject muzzleflash; 

	private Animator anim; 
	private bool automatic; 

	public bool canshoot; 

	private groundcollsion groundscript; 
	private Vector2 difference; 
	public float forceshoot; 

	public bool sniper; 

	private characterscript playerscript; 
	void Start () {
		automatic = true; 
	}


	void Update () {

	

		groundscript = GameObject.FindObjectOfType<groundcollsion> ().GetComponent<groundcollsion> (); 

		anim = GetComponent<Animator> (); 


		playerscript = GameObject.FindObjectOfType<characterscript> ().GetComponent <characterscript> (); 
		difference = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position; 
		difference.Normalize ();
		float rotz = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg; // find the angles in degrees

		Debug.Log (rotz); 

		rotz = Mathf.Clamp (rotz, -90f, 90f); 
		difference = new Vector2 (Mathf.Clamp (difference.x, 0, 1), Mathf.Clamp (difference.y, -1, 1));


		transform.rotation = Quaternion.Euler (0f, 0f, rotz); 

		/*
		if (Input.GetKeyDown ("d")) {
			gunforward = true; 
			gunfaceup = false; 
			gunfacedown = false;
			gunfaceupmiddle = false; 
			gunfacedownmiddle = false; 
		} else if (Input.GetKeyDown ("w")) {
			gunforward = false; 
			gunfaceup = true; 
			gunfacedown = false; 
			gunfaceupmiddle = false; 
			gunfacedownmiddle = false; 
		} else if (Input.GetKeyDown ("s")) {
			gunforward = false; 
			gunfaceup = false; 
			gunfacedown = true; 
			gunfaceupmiddle = false; 
			gunfacedownmiddle = false; 
		} else if (Input.GetKey ("d") && Input.GetKey("s")) {
			gunforward = false; 
			gunfaceup = false; 
			gunfacedown = false;
			gunfaceupmiddle = false; 
			gunfacedownmiddle = true; 
		} else if (Input.GetKey ("d") && Input.GetKey ("w")) {
			gunforward = false; 
			gunfaceup = false; 
			gunfacedown = false;
			gunfaceupmiddle = true; 
			gunfacedownmiddle = false; 
		}


		if (gunfaceup == true) {
			difference = new Vector2 (0, 1); 
		} else if (gunforward == true) {
			difference = new Vector2 (1, 0); 
		} else if (gunfacedown) {
			difference = new Vector2 (0, -1); 
		}  else if (gunfacedownmiddle) {
			difference = new Vector2 (3, -1); 
		} else if (gunfaceupmiddle) {
			difference = new Vector2 (2, 1); 
		}
		*/

		if (!playerscript.dead && automatic && Time.time > cooldowntimer) {
			canshoot = true; 
		} else {
			canshoot = false; 
		}

		if (canshoot && Input.GetMouseButton(0)) {
			Debug.Log ("shoot"); 

			cooldowntimer = Time.time + firedelay; 
			GameObject.FindObjectOfType<camerashake> ().GetComponent<camerashake> ().Shake (0.03f, 0.05f); 
			anim.SetTrigger ("shoot"); 
			Instantiate (muzzleflash, firepoint.position, transform.rotation); 
			GameObject bulletinstance; 
			bulletinstance = Instantiate (bullet, firepoint.position, transform.rotation) as GameObject; 
			bulletinstance.GetComponent<Rigidbody2D> ().AddForce (difference * forceshoot); 

			if (rotz <= -80f && rotz >= -90f && transform.position.y <= 6f) {
				playerscript.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 400f); 

			}

			shooting = true; 
		} else {
			shooting = false; 
		}

	}

	void Flip () {
		facingright = !facingright; 
		Vector3 theScale = transform.localScale; 
		theScale.y *= -1; 
		transform.localScale = theScale; 
	}

	static bool rouglyequal (float a, float b) {
		float thereshold = 4f; 
		return (Mathf.Abs (a - b) < thereshold); 
	}



}
