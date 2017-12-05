using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class tesTap : MonoBehaviour {

	/*
	public float fruitSpeed;
	public float maxPos = 2.2f;
	public int counter;
	public static int Lost;

	Vector3 position;
	public AudioManager am;
	//public Manager ui;
	public GameObject plus,minus;

	bool currentPlatformAndroid = false;

	Rigidbody2D rb;

	void Awake(){
		rb = GetComponent<Rigidbody2D> ();

	}

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (currentPlatformAndroid == true) {
			
		} else {
			position.x += Input.GetAxis ("Horizontal") * fruitSpeed * Time.deltaTime;
			position.x = Mathf.Clamp (position.x, -2.2f, 2.2f);

			transform.position = position;

		}
		
	}

	void TouchMove(){
		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch (0);

			float middle = Screen.width / 2;

			if (touch.position.x < middle && touch.phase == TouchPhase.Began) {
				MoveLeft ();
			} else if (touch.position.x > middle && touch.phase == TouchPhase.Began) {
				MoveRight ();
			}
		}
		else {
			SetVelocityZero ();
		}
	}

	public void MoveLeft(){
		rb.velocity = new Vector2 (-fruitSpeed, 0);
	}

	public void MoveRight(){
		rb.velocity = Vector2.zero;
	}

	public void SetVelocityZero(){
		rb.velocity = Vector2.zero;
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "buah") {
			if(Manager.Tipe == coll.gameObject.GetComponent<tesgerak>().tipe)
			{
				Manager.skor= Manager.skor +4;
				counter++;
				if(counter > 2){
					Manager.Tipe=Random.Range(0,6);
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
			Lost++;
			GameObject spawn = Instantiate (minus) as GameObject;
		}
	}
	*/
	float directionX;
	Rigidbody2D rb;


	void Start(){
		rb = GetComponent<Rigidbody2D> ();
	}

	void Update(){
		directionX = CrossPlatformInputManager.GetAxis ("Horizontal");
		rb.velocity = new Vector2 (directionX * 10, 0);
	}
}
