using UnityEngine;
using System.Collections;

public class flipscript : MonoBehaviour {
	public Transform target; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("w")) {
			transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation , 10f);
		}
	
	}
}
