using UnityEngine;
using System.Collections;

public class tankhitscript : MonoBehaviour {

	public Sprite hitsprite; 
	public Sprite originalsprite; 
	public float backduration = 0.03f; 
	float cooldownback = 0f; 

	public int health = 50; 

	public GameObject heliexplosion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) { 
			Instantiate (heliexplosion, transform.position , transform.rotation); 
			Destroy (gameObject);
		}

		if (Time.time > cooldownback) {
			GetComponent<Animator> ().enabled = true; 
		}
			
	}

	public void takedamage (int damage) {
		health -= damage; 
		GetComponent<SpriteRenderer> ().sprite = hitsprite; 
		cooldownback = Time.time + backduration; 
		GetComponent<Animator> ().enabled = false; 
	}
}
