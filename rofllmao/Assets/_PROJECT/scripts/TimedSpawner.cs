using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawner : MonoBehaviour {

	public float timeDuration = 1;
	public GameObject thingToCreate;
	public List<GameObject> things = new List<GameObject>();
	public float timer;
	public int amountOf;
	public GameObject p1;
	public GameObject p2;


	// Use this for initialization
	void Start () {
		
	}

	public void Create(int count){
		for (int i = 0; i < count; ++i) {
			Vector3 p = transform.position;
			p += Random.onUnitSphere;
			p.z = 0;
			GameObject obj = Instantiate (thingToCreate, p, transform.rotation);
			//p1 = GameObject.Find ("player");
			AILerp ailerp = obj.GetComponent<AILerp> ();
			if (ailerp != null) {
				ailerp.target = p1.transform;



			}


			things.Add (obj);
			if (obj.transform == p1.transform) {
				ailerp.target == p2.transform;
			}
		

		}
	}
	public 
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= timeDuration) {
			timer -= timeDuration;
			Debug.Log ("The timer went off at " + Time.time);
			Create (amountOf);





			//var thing = GameObject.Find ("minion(Clone)");
			//thing.GetComponent<AILerp> ().target = p1.transform; 

		}
	}
}
