using UnityEngine;
using System.Collections;

public class bodyblown : MonoBehaviour {

	public Vector2 forcedirection; 
	public float forceamount; 
	public int health = 16; 
	public GameObject bloodexplosion; 

	public bool rotatestop = false; 

	private float vector_x1;
	private float vector_y1;

	private float force; 

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().AddForce(new Vector2 (Random.Range(2, 10),Random.Range(3,8)) * Random.Range(30,40));
	}
	
	// Update is called once per frame
	void Update () {
		if (!rotatestop) {
			transform.Rotate (Vector3.right * 6 * Time.deltaTime);
		}
		//if (health <= 0) {
		//	Instantiate (bloodexplosion, new Vector2 (transform.position.x + 2f, transform.position.y + 1.3f), transform.rotation); 
		///	Destroy (gameObject);
		//}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.collider.tag == "ground") {
			rotatestop = true; 
		}
	}

	public void takedamage (int damage) {
		health -= damage; 
	}
}
