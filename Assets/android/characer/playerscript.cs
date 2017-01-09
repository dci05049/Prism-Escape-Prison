using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; 

public class playerscript : MonoBehaviour {

	private Rigidbody2D body2d; 
	private bool pressup;

	private birdgamemanager gamemanagerscript; 
	public GameObject endpanel; 
	private Animator anim; 

	// Use this for initialization
	void Start () {
		body2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		body2d.velocity = new Vector2 (3, body2d.velocity.y); 


		#if !Unity_ANDROID && !UNITY_IPHONE && !UNITY_BLACKBERRY && !UNITY_WYNRT  
		//fly (); 
		#endif

		if (pressup) {
			body2d.AddForce (Vector2.up * 25f);
			Debug.Log ("up");
		}

		if (transform.position.y <= -0.81f && !pressup) {
			body2d.gravityScale = 0f;
			body2d.velocity = new Vector2 (body2d.velocity.x, 0); 
		} else {
			body2d.gravityScale = 1f; 
		}
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "points1") {
			birdgamemanager.score += 2; 
			Destroy (other.gameObject); 
		} else if (other.gameObject.tag == "points2") {
			birdgamemanager.score += 1;
			Destroy (other.gameObject); 
		}

		if (other.gameObject.tag == "obstacle") {
			Destroy (gameObject); 
			gameover (); 
		}
	}

	public void fly () {
		pressup = true; 
		anim.SetBool ("birdglide", true); 
	}

	public void flydisable () {
		pressup = false; 
		anim.SetBool ("birdglide", false); 
	}

	public void gameover () {
		if (PlayerPrefs.GetInt ("score") < birdgamemanager.score) {
			PlayerPrefs.SetInt ("score", birdgamemanager.score);
			endpanel.SetActive (true); 
		}
	}

	public void onButtonclick (string sceneName) {
		SceneManager.LoadScene (sceneName); 
	}
}
