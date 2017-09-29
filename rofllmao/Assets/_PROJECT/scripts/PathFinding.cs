using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour {

	public var targetObject = Transform;
	private var navComponent = NavMeshAgent;

	// Use this for initialization
	void Start () {

		navComponent = this.transform.GetComponent (NavMeshAgent);
		
	}
	
	// Update is called once per frame
	void Update () {
		if (victim) {
		
			navComponent.SetDestination (targetObject.position);
		
		}
		
	}
}
