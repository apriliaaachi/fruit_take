using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {
	public static int skor;
	public static float time;
	public static bool isPlay;

	public static int Tipe;
	public GameObject target;
	public Sprite[] sprList;

	public GameObject[] objRacun;
	public static int bracun;
	public int maxracun;
	//public Transform[] posSpawn;
	public int spw;
	public int jenis;
	public GameObject[] spPempek, spRacun;
	public bool once;

	public bool kalah;
	public TextMesh txSkor, TxTime ,txHasilAkhir, txHighScore;
	public GameObject GameOver;

	public static float fallSpeed = 2f;
	public static float acceleration = 0f;
	public static int passedTime = 0;
	public static int intervals = 0;

	public float initialAcceleration;
	public int initialIntervals;

	public GameObject keranjang;

	// Use this for initialization
	void Start () {
		acceleration = initialAcceleration;
		intervals = initialIntervals;
		//isPlay = false;
		StartCoroutine (eksekusiPempek());
		StartCoroutine (eksekusiRacun());
		StartCoroutine (countTimes ());
		Tipe = Random.Range (0, 6);
		once = false;
		Time.timeScale = 1;
		skor = 0;
		time = 0;
	}

	IEnumerator countTimes()
	{
		while (true) {
			passedTime++;
			//Debug.Log ("Passed time: " + passedTime);
			yield return new WaitForSeconds (1f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (isPlay) {
			time = time + Time.deltaTime;
			txSkor.text = skor.ToString ();
			TxTime.text = ((int)time).ToString ();
			target.GetComponent<SpriteRenderer> ().sprite = sprList [Tipe];
			if(!once){
				StartCoroutine (eksekusiPempek());
				StartCoroutine (eksekusiRacun());
				once = true;
			}
			objRacun = GameObject.FindGameObjectsWithTag ("busuk");
			bracun = objRacun.Length;
			if ( Geser.Lost==3)
			{
				isPlay=false;
				kalah=true;
			}
		}
		if (kalah) {
			Debug.Log ("KALAH");
			Database.loadData();
			if(skor > Database.highscore){
				Database.highscore = skor;
				Database.saveData();
			}
			fallSpeed = 2f;
			passedTime = 0;
			GameOver.SetActive(true);
			Time.timeScale = 0;
			txHasilAkhir.text = skor.ToString(); 
			txHighScore.text = Database.highscore.ToString();
		}

		/*if (Input.GetKey ("left")) {
			keranjang.GetComponent<Geser> ().GeserKeranjangKiri ();
		} else if (Input.GetKey ("right")) {
			keranjang.GetComponent<Geser> ().GeserKeranjangKanan ();
		}*/


	}

	IEnumerator eksekusiPempek(){
		while (isPlay) {	
			if (passedTime % 10 == 0) {
				spw = 3;
			} else {
				spw = Random.Range (0,3);
			}
				GameObject spawn = Instantiate (spPempek[spw]) as GameObject;
			/*if (spawn.GetComponent<SpriteRenderer> ().sprite == ) {
				Debug.Log ("Destroy buah hantu");
				Destroy (spawn);
			}*/
				Debug.Log ("pempek");
			yield return new WaitForSeconds(1f);
		}
	}
	IEnumerator eksekusiRacun(){
		while (isPlay) {
			spw = Random.Range (0,3);
			GameObject spawn = Instantiate (spRacun[spw]) as GameObject;
			Debug.Log ("racun");
			yield return new WaitForSeconds(3.3f);
		}
	}
}
