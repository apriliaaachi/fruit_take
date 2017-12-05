using UnityEngine;
using System.Collections;

public class scriptefek : MonoBehaviour {
	// Use this for initialization
	void Start () {
		StartCoroutine (delay ());
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator delay(){
		yield return new WaitForSeconds(0.5f);
		Destroy (this.gameObject);
	}
	
}
