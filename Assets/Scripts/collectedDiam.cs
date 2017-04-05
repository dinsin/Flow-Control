using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectedDiam : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "player"){
			GetComponent<AudioSource> ().Play();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
