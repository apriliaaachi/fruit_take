using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour {
	public int identifier;

	private SpriteRenderer SpRender;
	public Sprite on,off;
	public bool gantiButton;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		if(identifier == 0){
			SceneManager.LoadScene("Gameplay");
			tesSwipe.Lost=0;
		}
		if(identifier == 1){
			SceneManager.LoadScene("MainMenu");
		}
		if(identifier == 2){
			SceneManager.LoadScene("About");
		}
		if(identifier == 3){
			SceneManager.LoadScene("Help");
		}	
		if(identifier == 4){
			SpRender = GetComponent<SpriteRenderer>();
			Database.LoadMusOp();
			if(Database.musop){
				this.gameObject.GetComponent<SpriteRenderer>().sprite = off;
				Database.musop = false;
			} else {
				this.gameObject.GetComponent<SpriteRenderer>().sprite = on;
				Database.musop = true;
			}
			Database.SaveMusOp();
		}
		if(identifier == 5){
			Application.Quit();
		}
	}
}
