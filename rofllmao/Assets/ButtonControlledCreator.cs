using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControlledCreator : MonoBehaviour {

	public GameObject thingToCreate;
	public List<GameObject> things = new List<GameObject>();

	public void Create(int count){
		for (int i = 0; i < count; ++i) {
			Vector3 p = transform.position;
			p += Random.onUnitSphere;
			p.z = 0;
			GameObject obj = Instantiate (thingToCreate, p, transform.rotation);
			things.Add (obj);
		}
	}

	public void DestroyAll(){
		for (int i = 0; i < things.Count; ++i) {
			Destroy (things [i]);
		}
		things.Clear ();
	}
}
