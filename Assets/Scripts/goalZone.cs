﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goalZone : MonoBehaviour {


	public Rigidbody2D player;
	public AudioSource aS;

	void Start () {
		
	}


	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "player"){
			player.GetComponent<playerMovement> ().goal = true;
			aS.GetComponent<gameSound> ().goalReached = true;
	
			if (SceneManager.GetActiveScene ().name  == "Level1.1")
				SceneManager.LoadScene ("Level1.2");
			else if (SceneManager.GetActiveScene ().name  == "Level1.2")
				SceneManager.LoadScene ("Level1.3");
			else if (SceneManager.GetActiveScene ().name == "Level1.3")
				SceneManager.LoadScene ("Proto");
			else if (SceneManager.GetActiveScene ().name == "Proto")
				SceneManager.LoadScene ("Level2");
			else if (SceneManager.GetActiveScene ().name == "Level2")
				SceneManager.LoadScene ("Level3");

		}
	}

	void Update () {
		
	}
}
