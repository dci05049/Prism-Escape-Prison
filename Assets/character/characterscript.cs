using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; 

public class characterscript : MonoBehaviour {


	private Rigidbody2D body2d; 
	public float speed;
	public bool facingright = true; 
	public bool dead = false; 
	public int health = 10; 

	public GameObject bloodexplosion; 
	public GameObject bodyparts; 

	private groundcollsion groundcollisionscript; 
	public float jumpfroce; 

	private gamemanager gamemangerscript; 

	// Use this for initialization
	void Start () {
		body2d = GetComponent<Rigidbody2D> (); 
	}

	// Update is called once per frame
	void Update () {


		gamemangerscript = GameObject.FindObjectOfType<gamemanager> (); 

		// when the character is dead 
		if (health <= 0) {
			Instantiate (bloodexplosion, new Vector2 (transform.position.x + 2f, transform.position.y + 1.3f), transform.rotation); 
			gamemangerscript.playerdeath = true; 
			Destroy (gameObject);
			speed = 0;
		}

		groundcollisionscript = GetComponent<groundcollsion> ();

		// float h = Input.GetAxis ("Horizontal"); 
		body2d.velocity = new Vector2 (speed, body2d.velocity.y);

		if (groundcollisionscript.grounded && Input.GetKeyDown ("space")) {
			OnJump (); 
		}
	}

	void Flip () {
		facingright = !facingright; 
		Vector3 theScale = transform.localScale; 
		theScale.x *= -1; 
		transform.localScale = theScale; 
	}

	void OnJump () {
		body2d.velocity = new Vector2 (body2d.velocity.x, jumpfroce);
	}

	public void playertakedamage (int damage) {
		health -= damage; 
	}

	void OnTriggerStay2D (Collider2D other) {
		if (other.tag == "shop" && Input.GetKeyDown ("w")) {
			SceneManager.LoadScene ("Shop"); 
		}
	}
}