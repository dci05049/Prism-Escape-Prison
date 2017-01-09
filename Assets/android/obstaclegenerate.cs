using UnityEngine;
using System.Collections;

public class obstaclegenerate : MonoBehaviour {

	public GameObject[] obstacles; 
	public float spawnmin = 1f;
	public float spawnmax = 3f; 

	private int indexposition; 

	// Use this for initialization
	void Start () {
		Spawn ();
	}


	void Spawn () {
		indexposition = Random.Range (0, obstacles.Length);
		Instantiate (obstacles [Random.Range (0, obstacles.Length)], transform.position, Quaternion.identity);
		Invoke ("Spawn", Random.Range (spawnmin, spawnmax));
	}
}
