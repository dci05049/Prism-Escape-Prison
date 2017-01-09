using UnityEngine;
using System.Collections;

[System.Serializable]
public class characterobject : ScriptableObject {

	public string charactername = "character name"; 
	public int coincost = 50; 
	public string description; 

	public GameObject characterprefab; 
}


