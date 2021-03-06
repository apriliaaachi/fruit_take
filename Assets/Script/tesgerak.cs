﻿using UnityEngine;
using System.Collections;

public class tesgerak : MonoBehaviour {
	public Sprite[] sprBuah;
	public int tipe;
	public Vector3 posAkhir;
	public float speed;
	public Vector3 sizeAkhir;

	// Use this for initialization
	void Start () {
		if (Manager.passedTime % Manager.intervals == 0) {
			Manager.fallSpeed += Manager.acceleration;
			Debug.Log ("Speed increased to " + Manager.fallSpeed);
		}

		//Debug.Log ("Time passed " + Manager.passedTime + " seconds");
		speed = Manager.fallSpeed;
		tipe = Random.Range (0, 4);
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = sprBuah [tipe];

		iTween.MoveTo (this.gameObject, iTween.Hash ("position", posAkhir,
		                                             "easetype", "linear",
		                                            "speed", speed));
		iTween.ScaleTo (this.gameObject, iTween.Hash("scale", sizeAkhir,
		                                             "easetype", "linear",
		                                             "time", speed));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
