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


	// Use this for initialization
	void Start () {
		
	}

	public void Create(int count){
		for (int i = 0; i < count; ++i) {
			Vector3 p = transform.position;
			p += Random.onUnitSphere;
			p.z = 0;
			GameObject obj = Instantiate (thingToCreate, p, transform.rotation,ai);


			things.Add (obj);
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
			p1 = GameObject.Find ("player");
			var thing = GameObject.Find ("minion(Clone)");
			thing.GetComponent<AILerp> ().target = p1.transform; 
			for(int  i =0; i< things.Count;
		}
	}
}
