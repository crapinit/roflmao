using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
	public float speed = .325f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float v = Input.GetAxis ("Vertical");
		float h = Input.GetAxis ("Horizontal");
		Vector2 dir = new Vector2 (h, v);
		dir.Normalize ();
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		rb.velocity = dir * speed;
	}

}
