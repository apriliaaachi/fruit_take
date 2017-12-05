using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public AudioClip clipSatu;
	public AudioClip clipDua;

	AudioSource audioSource;

	void Awake(){
		audioSource = GetComponent<AudioSource>();
	}

	void Update(){

		if(Input.GetKeyDown(KeyCode.O)){
			audioSource.clip = clipSatu;
			audioSource.Play();
		}

		if(Input.GetKeyDown(KeyCode.P)){
			audioSource.clip = clipDua;
			audioSource.Play();
		}
	}
}
