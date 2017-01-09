using UnityEngine;
using System.Collections;

public class helicopterscript : MonoBehaviour {
	public GameObject airstrikebomb; 
	public Transform firepoint; 
	public float firedelay = 0.03f; 
	float cooldowntimer = 0f; 
	public bool airstrike = false; 
	public int health; 
	public GameObject miltiaryguy; 

	public float parachutedelay = 0.03f; 
	float cooltimeparachute = 0f; 

	public GameObject heliexplosion;

	private Rigidbody2D body2d; 

	public Sprite hitsprite; 
	public Sprite originalsprite; 
	public float backduration = 0.03f; 
	float cooldownback = 0f; 

	private Transform playertransform; 
	public bool miltary = false;
	public bool miltarystop = false; 
	// Use this for initialization
	void Start () {
		body2d = GetComponent<Rigidbody2D> (); 
	}
	
	// Update is called once per frame
	void Update () {

		playertransform = GameObject.FindObjectOfType<characterscript> ().transform;

		if (!miltarystop && (transform.position - playertransform.position).x <= 23f && (transform.position - playertransform.position).x >= 6f) {
			miltary = true; 
		}

		if (Time.time > cooldowntimer) {
			cooldowntimer = Time.time + firedelay; 
			Instantiate (airstrikebomb, firepoint.position, transform.rotation);
		}

		if (miltary) {
			StartCoroutine (miltarydeploy ()); 
		}

	

		if (health <= 0) { 
			Instantiate (heliexplosion, transform.position , transform.rotation); 
			Destroy (gameObject);
		}

		if (Time.time > cooldownback) {
			GetComponent<SpriteRenderer> ().sprite = originalsprite; 
		}

		body2d.velocity = new Vector2 (-5, body2d.velocity.y);
	}

	public void takedamage (int damage) {
		health -= damage; 
		GetComponent<SpriteRenderer> ().sprite = hitsprite; 
		cooldownback = Time.time + backduration; 
	}

	IEnumerator miltarydeploy () {
		for (int i = 0; i <= 0; i++) {
			miltarystop = true;
			miltary = false; 
			Instantiate (miltiaryguy, new Vector2 (transform.position.x - 3f, transform.position.y) , transform.rotation); 
			Instantiate (miltiaryguy, new Vector2 (transform.position.x - 1.5f, transform.position.y), transform.rotation); 
			Instantiate (miltiaryguy, new Vector2 (transform.position.x, transform.position.y), transform.rotation); 
			Instantiate (miltiaryguy, new Vector2 (transform.position.x + 1.5f, transform.position.y), transform.rotation); 
			GameObject bulletinstance; 
			yield return new WaitForSeconds (0.3f); 
		}
	}
}
