using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyWall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "obstacle"){
			Destroy (gameObject);
		}
	}

	void Update () {
		
	}
}
