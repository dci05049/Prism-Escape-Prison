using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loopgenerate : MonoBehaviour {

	public GameObject[] loopobjects;
	// Use this for initialization
	void Start () {
		Instantiate (loopobjects [Random.Range (0, loopobjects.Length)], transform.position, transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
