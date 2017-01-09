using UnityEngine;
using System.Collections;

public class bloodexplosion : MonoBehaviour {

	public Sprite [] BigBlood; 
	private int BloodNum; 

	private bool BloodSplat = false; 

	private float vector_x1;
	private float vector_y1;

	private float force; 

	private parentbloodexplode parentscript; 
	// Use this for initialization
	void Start () {
		parentscript = gameObject.transform.parent.GetComponent<parentbloodexplode> (); 
		vector_x1 = Random.Range (parentscript.vector_x1, parentscript.vector_x2); 
		vector_y1 = Random.Range (parentscript.vector_y1, parentscript.vector_y2); 

		force = Random.Range (parentscript.force1, parentscript.force2); 

		GetComponent<Rigidbody2D> ().AddForce(new Vector2 (vector_x1, vector_y1) * force);
		BloodNum = Random.Range (0, BigBlood.Length); 
		GetComponent<SpriteRenderer> ().sprite = BigBlood [BloodNum]; 
	}

	void Update () {
		transform.Rotate (Vector3.right * 6 * Time.deltaTime);
	}


}
