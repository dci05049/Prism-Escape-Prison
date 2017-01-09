using UnityEngine;
using System.Collections;

public class tankshootperson : MonoBehaviour {
	
	private Vector2 difference; 
	private Transform playertransform; 

	private gamemanager gamemanagerscript; 

	public float firedelay = 0.03f; 
	float cooldowntimer = 0f; 

	public GameObject muzzleflash; 
	public Transform firepoint; 
	public GameObject bullet; 

	public bool shoot = false; 

	public bool rot = true; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gamemanagerscript = GameObject.FindObjectOfType <gamemanager> (); 

		playertransform = GameObject.FindObjectOfType<characterscript> ().transform;

		if ((transform.position - playertransform.position).x <= 23f && (transform.position - playertransform.position).x >= 6f) {
			shoot = true; 
		}  
		else if (shoot && rot) {
			shoot = false; 
			rot = false; 
		}


		if (rot && shoot) {
			difference = transform.position - playertransform.position; 
			difference.Normalize ();
			float rotz = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg; // find the angles in degrees
			transform.rotation = Quaternion.Euler (0f, 0f, rotz);
		}
			

		if (shoot && !gamemanagerscript.playerdeath && Time.time > cooldowntimer) {
			GameObject.FindObjectOfType<camerashake> ().GetComponent<camerashake> ().Shake (0.03f, 0.05f); 
			cooldowntimer = Time.time + 1f; 
			StartCoroutine (shootconsecutive()); 
				//anim.SetTrigger ("shoot");  
		}
	}

	IEnumerator shootconsecutive () {
		for (int i = 0; i <= 2; i++) {
			rot = false; 
			Instantiate (muzzleflash, firepoint.position, transform.rotation); 
			GameObject bulletinstance; 
			bulletinstance = Instantiate (bullet, firepoint.position, transform.rotation) as GameObject; 
			bulletinstance.GetComponent<Rigidbody2D> ().AddForce (difference * -1500f); 
			yield return new WaitForSeconds (0.1f); 
		}

		rot = true; 
	}
}
