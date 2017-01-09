using UnityEngine;
using System.Collections;

public class camerashake : MonoBehaviour {

	public Camera maincam; 

	float ShakeAmount = 0;

	void Awake () {
		if (maincam == null)
			maincam = Camera.main;
	}

	void Update () {

	}

	public void Shake (float amt , float length)
	{
		ShakeAmount = amt; 
		InvokeRepeating ("BeginShake", 0, 0.01f); 
		Invoke ("StopShake", length); 
	}

	void BeginShake () 
	{
		if (ShakeAmount > 0) {
			Vector3 camPos = maincam.transform.position; 

			float offsetx = Random.value * ShakeAmount * 2 - ShakeAmount; 
			float offsety = Random.value * ShakeAmount * 2 - ShakeAmount; 
			camPos.x += offsetx; 
			camPos.y += offsety; 

			maincam.transform.position = camPos; 
		}
	}

	void StopShake () 
	{
		CancelInvoke ("BeginShake"); 
		maincam.transform.localPosition = Vector3.zero; 
	}
}
