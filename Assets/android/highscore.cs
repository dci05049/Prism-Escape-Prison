using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highscore : MonoBehaviour {

	public Text scoretext; 

	// Use this for initialization
	void Start () {
		scoretext.text = PlayerPrefs.GetInt ("score").ToString (); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
