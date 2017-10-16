using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControlScript : MonoBehaviour {
	public float speed = .325f;
	public LayerMask whatIsWall;
	public float maxDistFromWall = 0f;

	public Vector2 targetLocation = new Vector2 (40, 40);
	Vector2 dir = Vector2.zero;



	// Use this for initialization
	void Start () {

	}



	// Update is called once per frame
	void Update () {
			
		Vector2 newPosition = new Vector2 (targetLocation.x,targetLocation.y);

		Vector2 oldPosition = transform.position;
		dir = newPosition - oldPosition;


		dir.Normalize ();
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		rb.velocity = dir * speed;


}

}
