using UnityEngine;
using System.Collections;

public class policeshoot : MonoBehaviour {

	private Vector2 difference; 
	private Vector3 playerposition; 

	public GameObject bullet; 
	public GameObject muzzleflash; 
	public Transform firepoint; 
	public float firedelay = 0.03f; 
	float cooldowntimer = 0f; 
	public bool shooting = false; 

	public bool automatic = false; 

	private Animator gunanim; 
	private enemyscript enemyscript; 
	private gamemanager gamemanagerscript; 

	// Use this for initialization
	void Start () {
		gunanim = GetComponent <Animator> (); 
	}
	
	// Update is called once per frame
	void Update () {
		gamemanagerscript = GameObject.FindObjectOfType <gamemanager> (); 
		enemyscript = gameObject.transform.parent.GetComponent<enemyscript> ();

		if (!gamemanagerscript.playerdeath) {
			playerposition = GameObject.FindObjectOfType<characterscript> ().GetComponent<characterscript> ().transform.position; 
			difference = transform.position - playerposition; 

			if (difference.x <= 16f && difference.x >= 2f) {
				shooting = true; 
			} else {
				shooting = false; 
			}

			difference.Normalize ();
			float rotz = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg; // find the angles in degrees


			if (Time.time > cooldowntimer && shooting) {
				cooldowntimer = Time.time + firedelay; 
				enemyscript.walking = false; 
				gunanim.SetTrigger ("shoot"); 
				Instantiate (muzzleflash, firepoint.position, transform.rotation); 
				GameObject bulletinstance; 
				bulletinstance = Instantiate (bullet, firepoint.position, transform.rotation) as GameObject; 
				bulletinstance.GetComponent<Rigidbody2D> ().AddForce (difference * -700f); 
			}
		}
	}
}
