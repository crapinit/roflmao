using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControlScript : MonoBehaviour {
	public float speed = .325f;
	public LayerMask whatIsWall;
	public float maxDistFromWall = 0f;
	public Vector2[] waypoints;

	Vector2 dir = Vector2.zero;
	GameObject destinationLine;
	GameObject pathLine;
	GameObject targetCircleLine;
	Seeker seekr;
	GameObject dotProductLine;
	Pathfinding.Path myPath;
	public int myPathIndex = 0;
	Rigidbody2D rb;
	public Vector2 waypoint;
	public int waypointIndex;


	// Use this for initialization
	void Start () {
		
		waypoint = waypoints[0];

		rb = GetComponent<Rigidbody2D> ();
		seekr = GetComponent<Seeker> ();
		seekr.pathCallback = HandleOnPathDelegate;
		setTarget (waypoint);
	}

	void HandleOnPathDelegate (Pathfinding.Path p)
	{
		myPath = p;
		Debug.Log (myPath.vectorPath.Count + " points");
		Lines.Make (ref pathLine, p.vectorPath.ToArray (), p.vectorPath.Count, Color.magenta);
		if (myPath.vectorPath.Count > 0) {
			int closestIndex = 0;
			float closestDistance = Vector3.Distance (transform.position, myPath.vectorPath [closestIndex]);
			for (int i = 0; i < myPath.vectorPath.Count; i++) {
				float distanceCurrent = Vector3.Distance(transform.position, myPath.vectorPath[i]);

				if (distanceCurrent < closestDistance) {
					closestDistance = distanceCurrent;
					closestIndex = i;

				}
				
			}
			myPathIndex = closestIndex;
		
		}
	}

	public void setTarget(Vector3 location){
		waypoint = location;
		myPathIndex = 0;
		myPath = null;
		if (seekr) {
			seekr.CancelCurrentPathRequest ();
			seekr.StartPath (transform.position, (Vector3)waypoint);
		}
	
	}



	// Update is called once per frame
	void FixedUpdate () {
		Vector2 newPosition;
		if (myPath != null) 
		{
			if (myPathIndex >= myPath.vectorPath.Count) {
				newPosition = (Vector2) transform.position;
			} else {
				newPosition = (Vector2)(myPath.vectorPath [myPathIndex]);
			}
		} else {
			newPosition = (Vector2) transform.position;

		}

		Vector2 oldPosition = (Vector2)transform.position;
		dir = newPosition - oldPosition;
			
		Lines.Make (ref destinationLine, gameObject.transform.position, (Vector3)newPosition, Color.blue);

		dir.Normalize ();
		if (collisionNormal != Vector2.zero) {
			float dot = Vector2.Dot (collisionNormal, dir);
			if (dot < 0) {
				dir -= collisionNormal * dot;
			
				Lines.Make (ref dotProductLine, transform.position, transform.position + (Vector3)(collisionNormal * dot), Color.black);
				dir.Normalize ();
			}
		}
		rb.velocity = dir * speed;
		if (Vector3.Distance(transform.position,newPosition) < 1 ) {
			myPathIndex++;
			if(myPath != null){
				if (myPathIndex > myPath.vectorPath.Count) {
				
					if (waypointIndex + 1 > waypoints.Length) {
						return;
					} else {
						waypointIndex++;
						waypoint = waypoints [waypointIndex];
						setTarget (waypoint);

				
					}
				}

			}


		}
		Lines.MakeCircle (ref targetCircleLine, (Vector3)newPosition, Vector3.forward, Color.red);	
		collisionNormal = Vector2.zero;	


	}
	Vector2 collisionNormal;
	void OnCollisionStay2D(Collision2D c){
		collisionNormal = c.contacts [0].normal.normalized;
		
	}

}
