using UnityEngine;
using System.Collections;

public class tankshoot : MonoBehaviour {

	private Vector2 difference; 
	private Vector3 playerposition; 

	public bool shooting = false; 
	public float firedelay = 0.03f; 
	float cooldowntimer = 0f; 
	public Transform firepoint; 
	public GameObject tankbullet; 

	private Animator gunanim; 
	private gamemanager gamemanagerscript; 
	// Use this for initialization
	void Start () {
		gunanim = GetComponent <Animator> (); 
	}
	
	// Update is called once per frame
	void Update () {
		gamemanagerscript = GameObject.FindObjectOfType <gamemanager> (); 

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
				gunanim.SetTrigger ("tankshoot"); 
				GameObject bulletinstance; 
				bulletinstance = Instantiate (tankbullet, firepoint.position, transform.rotation) as GameObject; 
				bulletinstance.GetComponent<Rigidbody2D> ().AddForce (Vector3.left * 1000f); 
			}
		}
	}
}
