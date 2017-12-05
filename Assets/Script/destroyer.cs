using UnityEngine;
using System.Collections;

public class destroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag != "Player") {
			if (coll.gameObject.tag == "buah") {
				Debug.Log ("Buah Jatuh");
				Geser.Lost++;
			}
			Destroy (coll.gameObject);
		}
	}
}
