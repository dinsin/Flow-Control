using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalZone : MonoBehaviour {


	public Rigidbody2D player;
	public AudioSource aS;

	void Start () {
		
	}


	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "player"){
			player.GetComponent<playerMovement> ().goal = true;
			aS.GetComponent<gameSound> ().goalReached = true;
		}
	}

	void Update () {
		
	}
}
