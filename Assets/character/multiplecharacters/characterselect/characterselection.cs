using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; 

public class characterselection : MonoBehaviour {

	private GameObject[] charlist; 
	private int index; 


	// Use this for initialization
	void Start () {
		charlist = new GameObject[transform.childCount];
		for (int i = 0; i < transform.childCount; i++)
			charlist [i] = transform.GetChild (i).gameObject; 

		foreach (GameObject go in charlist) 
			go.GetComponent<Animator>().enabled = false; 

		if (charlist [0])
			charlist [0].GetComponent<Animator> ().enabled = true; 
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ToggleLeft () {
		charlist [index].GetComponent<Animator>().enabled = false; 

		index--; 
		if (index < 0)
			index = charlist.Length - 1; 

		charlist [index].GetComponent<Animator> ().enabled = true; 

	}

	public void ToggleRight () {
		charlist [index].GetComponent<Animator>().enabled = false; 

		index++; 
		if (index == charlist.Length)
			index = 0;

		charlist [index].GetComponent<Animator> ().enabled = true; 

	}

	public void confirmbutton () {
		SceneManager.LoadScene ("spacenog"); 
	}
}
