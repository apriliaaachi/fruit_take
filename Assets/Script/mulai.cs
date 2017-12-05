using UnityEngine;
using System.Collections;

public class mulai : MonoBehaviour {
	public static GameObject prnt;
	public Animator anim;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void kill(){
		prnt = GameObject.Find ("bg_loading");
		Destroy (prnt);
		Manager.isPlay = true;
	}

	IEnumerator tunggu(){
		yield return new WaitForSeconds(1.7f);
	}
}
