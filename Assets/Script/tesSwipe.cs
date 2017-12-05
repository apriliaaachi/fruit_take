using UnityEngine;
using System.Collections;

public class tesSwipe : MonoBehaviour {

	public int posisi;
	public Transform[] posMonster;
	public Animation script;

	public int counter;
	
	private bool isDrag,isUD;
	private Vector3 targetBefore;
	private Vector3 targetAfter;
	public static int Lost;

	public GameObject plus,minus;


	// Use this for initialization
	void Start () {
		isDrag = false;
		isUD = false;
		counter = 0;
		Lost = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Manager.isPlay) {
			if (Input.GetMouseButtonDown (0)) {
				isDrag = true;
				MouseDown ();
			}
			if (Input.GetMouseButtonUp (0)) {/*isDrag = false;*/
				MouseUp ();
			}
			if (isDrag)
				MouseDrag ();
		}

	}
	
	void MouseDown() {
		targetBefore = Camera.main.ScreenToWorldPoint(Input.mousePosition);

	}
	
	void MouseDrag() {
		targetAfter = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		
		//Debug.Log (targetBefore.y - targetAfter.y);
		if (Mathf.Abs(targetBefore.x - targetAfter.x) >= Mathf.Abs(targetBefore.x - targetAfter.x)) {
			if(Mathf.Abs(targetBefore.x - targetAfter.x) > 3)
				isUD = true;
		}
		
		if (isUD) {
			if(targetAfter.x >= targetBefore.x) {
				//kanan
				if(posisi<2){
					posisi++;
					this.gameObject.transform.position = posMonster[posisi].position;
				}
			}
			else {
				//kiri
				if(posisi>0){
					posisi--;
					this.gameObject.transform.position = posMonster[posisi].position;
				}
			}
			isDrag = false;
		}
	}
	
	void MouseUp() {
		isUD = false;
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
}
