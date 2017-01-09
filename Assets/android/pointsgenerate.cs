using UnityEngine;
using System.Collections;

public class pointsgenerate : MonoBehaviour {

	public GameObject[] obstacles; 
	public float spawnmin = 1f;
	public float spawnmax = 3f; 

	private int indexposition; 

	private float y_positionspawn; 

	// Use this for initialization
	void Start () {
		Spawn ();
	}


	void Spawn () {
		indexposition = Random.Range (0, obstacles.Length);
		y_positionspawn = Random.Range (-3, 3); 
		Instantiate (obstacles [Random.Range (0, obstacles.Length)], new Vector2 (transform.position.x , transform.position.y + y_positionspawn)  , Quaternion.identity);
		Invoke ("Spawn", Random.Range (spawnmin, spawnmax));
	}
}
