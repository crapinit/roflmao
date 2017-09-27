using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
	public float speed = .325f;
	public enum ControlledBy {none, keyboard, mouse};
	public ControlledBy controlledBy = ControlledBy.mouse;
	Vector2 clicked;

	private GameObject deltaLine, dirLine;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 dir = Vector2.zero;
		switch (controlledBy) {
		//case for keyboard input
		case ControlledBy.keyboard:
			{//finds the vertical and horizontal compenents of the input and sets it to a Vector 2 in the variable dir (or direction)
				float v = Input.GetAxis ("Vertical");
				float h = Input.GetAxis ("Horizontal");
				dir = new Vector2 (h, v);

			}
			break;
			//case for mouse input
		case ControlledBy.mouse:
			//0 is for left click, checks for left click input
			if (Input.GetMouseButtonDown (0)) {
				//Ray is two vectors, direction and origin, ray everything from starting position to the final position with direction factored in
				Ray r = Camera.main.ScreenPointToRay (Input.mousePosition);
				clicked = new Vector2 (r.origin.x, r.origin.y);
				//since the mouse has been clicked, find the origin x,y

			
			}
			//change the direction to the deltaX between the final position(clicked) and the origin
			dir = clicked - (Vector2)transform.position;
			Lines.Make (ref deltaLine, transform.position, transform.position + (Vector3)dir, Color.blue);//make a line that keeps track of the player relative to the clicked position
			break;
		}
		float dirlength = dir.magnitude;//setting the length of the direction to the magnitude
		if (dirlength < speed * Time.deltaTime) {//checks to see if you are clicking on top of the player and comparing it to moving nowhere
			dir = Vector2.zero;//if it would move where you clicked,then set the vector to zero
		} else {
			dir.Normalize ();//normalize the points, moving in either 1 or -1 in delta X
		}

		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		rb.velocity = dir * speed;//find the velocity that it needs to move at
		Vector3 p0 = (Vector3)rb.position, p1=(Vector3)(rb.position + rb.velocity);
		p0.z = p1.z = -2;
		//forcing 2d math into 3d math so that lines can draw correctly
		Lines.MakeArrow (ref dirLine, p0, p1 , 2, Color.red,0.05f,0.05f);// making an arrow that keeps track of the direction that the player is moving in
	}

}
