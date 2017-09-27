using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControlScript : MonoBehaviour {
	public float speed = .325f;
	public LayerMask whatIsWall;
	public float maxDistFromWall = 0f;
	public float laneEndX = 40;
	public float laneEndY = 40;
	Vector2 dir = Vector2.zero;



	// Use this for initialization
	void Start () {

	}



	// Update is called once per frame
	void Update () {
		
		float xPos = transform.position.x;
		float yPos = transform.position.y;
		Vector2 newPosition = new Vector2 (laneEndX, laneEndY);

		Vector2 oldPosition = new Vector2 (xPos, yPos);

		dir = newPosition - oldPosition;


		dir.Normalize ();
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		rb.velocity = dir * speed;


}

}
