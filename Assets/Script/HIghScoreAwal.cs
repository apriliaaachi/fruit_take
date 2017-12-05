using UnityEngine;
using System.Collections;

public class HIghScoreAwal : MonoBehaviour {
	public TextMesh txHS;
	// Use this for initialization
	void Start () {
		Database.loadData();
		txHS.text = Database.highscore.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }
	}
}
