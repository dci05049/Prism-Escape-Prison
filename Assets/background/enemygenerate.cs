using UnityEngine;
using System.Collections;

public class enemygenerate : MonoBehaviour {
	public GameObject enemy; 

	public float enemydelay = 2f; 
	float cooldowntimer = 0f; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Time.time > cooldowntimer) {
			cooldowntimer = Time.time + enemydelay; 
			Instantiate (enemy, transform.position, transform.rotation); 
		}
	}
}
