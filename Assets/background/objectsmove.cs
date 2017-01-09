using UnityEngine;
using System.Collections;

public class objectsmove : MonoBehaviour {


	private Transform cameraTransform;
	private float lastCameraX; 

	// Use this for initialization
	void Start () {
		cameraTransform = GameObject.FindObjectOfType<camerascript> ().transform; 
		lastCameraX = cameraTransform.position.x; 
	}
	
	// Update is called once per frame
	void Update () {
		float deltaX = cameraTransform.position.x - lastCameraX; 
		transform.position = transform.position + Vector3.right * (deltaX * -0.5f); 
		lastCameraX = cameraTransform.position.x; 
	}
}
