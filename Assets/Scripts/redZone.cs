using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redZone : MonoBehaviour {

	public Rigidbody2D player;

	void Start () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		Debug.Log ("onTrigger");
		if(col.gameObject.tag == "obstacle"){
			player.GetComponent<playerMovement> ().redZone += 1;
			Debug.Log ("redCircle");
		}
		if(col.gameObject.tag == "diamond"){
			Destroy (col.gameObject);
			player.GetComponent<playerMovement> ().diamonds -= 1;
		}
		if(col.gameObject.tag == "player"){
		//	player.GetComponent<playerMovement> ().goal = true;
		}
	}

	void Update () {
		
	}
}
