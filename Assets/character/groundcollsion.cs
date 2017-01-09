using UnityEngine;
using System.Collections;

public class groundcollsion : MonoBehaviour {
	
	public LayerMask collisonLayer;
	public bool grounded; 
	public Vector2 bottomposition = Vector2.zero; 
	public float radius = 10f; 

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		var botpos = bottomposition; 
		botpos.x = transform.position.x + bottomposition.x;
		botpos.y = transform.position.y + bottomposition.y;

		grounded = Physics2D.OverlapCircle (botpos, radius, collisonLayer); 
	}

	void OnDrawGizmos () {
		Gizmos.color = Color.red;
		var botpos = bottomposition; 
		botpos.x = transform.position.x + bottomposition.x;
		botpos.y = transform.position.y + bottomposition.y;

		Gizmos.DrawWireSphere (botpos, radius);

	}
}
