using UnityEngine;
using System.Collections;

public class Loading : MonoBehaviour {
	public GameObject parent;
	public Transform finish;
	public AnimationClip anim;
	public GameObject cd;
	// Use this for initialization
	void Start () {
		iTween.MoveTo (this.gameObject, iTween.Hash ("position", finish.position,
		                                             "speed", 2f,
		                                             "easetype", "linear",
		                                             "oncompletetarget", this.gameObject,
		                                             "oncomplete", "complete"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void complete(){
		parent.GetComponent<SpriteRenderer> ().sprite = null;
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = null;
		//cd.SetActive (true);
		StartCoroutine (tunggu ());
	}
	
	IEnumerator tunggu(){
		cd.SetActive (true);
		yield return new WaitForSeconds(anim.length);
		Destroy (cd);
		//Debug.Log ("tepanggil");
		Manager.isPlay = true;
		Destroy (parent);

	}
}
