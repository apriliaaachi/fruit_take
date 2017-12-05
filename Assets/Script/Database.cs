using UnityEngine;
using System.Collections;

public class Database : MonoBehaviour {
	public static int highscore;
	public static bool musop;
	// Use this for initialization
	void Start () {
		highscore = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void loadData(){
		highscore = PlayerPrefs.GetInt ("hs", 0);
	}

	public static void saveData(){
		PlayerPrefs.SetInt ("hs", highscore);
	}

	public static void LoadMusOp(){
		if (PlayerPrefs.GetString ("MusOp", "ON") == "ON") {
			musop = true;
		} else if (PlayerPrefs.GetString ("MusOp") == "OFF") {
			musop = false;
		}
	}
	
	public static void SaveMusOp(){
		if(musop == true){
			PlayerPrefs.SetString ("MusOp", "ON");
		}
		else if(musop == false){
			PlayerPrefs.SetString ("MusOp", "OFF");
		}
	}
}
