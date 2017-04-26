using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectedDiam : MonoBehaviour {

	public AudioClip audio;
	AudioSource aS;

	// Use this for initialization
	void Start () {
		aS = GetComponent<AudioSource>();
//		aS.clip = audio;
		aS.ignoreListenerVolume = true;
		aS.volume = 1;
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "player"){
//			AudioSource audio = GetComponent<AudioSource>();
			aS.Play();
			if (aS.isPlaying) Debug.Log("diamond collected");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
