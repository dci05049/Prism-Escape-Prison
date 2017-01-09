using UnityEngine;
using System.Collections;

public class characterguncontrol : MonoBehaviour {
	private GameObject[] gunlist; 
	private int index; 

	public bool rocketlancher; 


	// Use this for initialization
	void Start () {
		gunlist = new GameObject[transform.childCount];
		for (int i = 0; i < transform.childCount; i++)
			gunlist [i] = transform.GetChild (i).gameObject; 

		foreach (GameObject go in gunlist) 
			go.SetActive(false); 

		if (gunlist [0])
			gunlist [0].SetActive (true); 

	}

	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
			if (hit.collider.name == "rocketlauncheritem") {
				Debug.Log ("hi"); 
				rocketlancher = true; 
			}
		}


		if (rocketlancher) {
			gunlist = new GameObject[transform.childCount];
			for (int i = 0; i < transform.childCount; i++)
				gunlist [i] = transform.GetChild (i).gameObject; 

			foreach (GameObject go in gunlist)
				if (go.name == "rocketlauncher") {
					go.SetActive (true); 
				} else {
					go.SetActive (false); 
				}
		}

	}


}
