using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameSound : MonoBehaviour {

	public bool hitObstacle = false;
	public bool goalReached = false;
	public AudioSource aS;

	void Start () {
		
	}
	
	void Update () {

		if(hitObstacle == true){
			aS.pitch = .45f;
		}
		if(goalReached == true){
			aS.pitch = 1.2f;
		}

	}
}
