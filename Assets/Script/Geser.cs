using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geser : MonoBehaviour {

	public GameObject keranjang;
	private Vector3 currPos;
	public int counter;
	public GameObject plus,minus;

	private float[] possiblePos;
	private int currIndex;
	public static int Lost;


	// Use this for initialization
	void Start () {
		Lost = 0;
		counter = 0;
		currPos = keranjang.transform.position;
		possiblePos = new float[] { -1.87f, -1.87f + 2.0f, -1.87f + 4.0f };
		currIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void GeserKeranjangKanan() {
		Debug.Log ("Geser");
		currIndex = (currIndex + 1) % 3;
		keranjang.transform.position = new Vector3 (possiblePos[currIndex], currPos.y, currPos.z);

	}

	public void GeserKeranjangKiri() {
		currIndex--;
		if (currIndex < 0)
			currIndex = possiblePos.Length - 1;
		keranjang.transform.position = new Vector3 (possiblePos[currIndex], currPos.y, currPos.z);
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "emas") {
			Debug.Log ("Emas");
			Manager.skor += 50;
			Manager.fallSpeed += 1;
			counter++;
			if(counter > 2){
				Manager.Tipe=Random.Range(0,7);
				counter = 0;
			}
		}
		else if (coll.gameObject.tag == "buah") {
			if(Manager.Tipe == coll.gameObject.GetComponent<tesgerak>().tipe) {
				Manager.skor= Manager.skor +4;
				counter++;
				if(counter > 2){
					Manager.Tipe=Random.Range(0,7);
					counter = 0;
				}
			}
			Manager.skor++;
			Destroy(coll.gameObject);
			GameObject spawn = Instantiate (plus) as GameObject;
		}
		if (coll.gameObject.tag == "busuk") {
			Manager.skor--;
			Destroy (coll.gameObject);
			//Lost++;
			GameObject spawn = Instantiate (minus) as GameObject;
		}
	}
}
