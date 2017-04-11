using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redZone : MonoBehaviour {

	public Rigidbody2D player;
	public AudioSource aS;

	void Start () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		Debug.Log ("onTrigger");
		if(col.gameObject.tag == "obstacle"){
			player.GetComponent<playerMovement> ().redZone += 1;
//			GetComponent<flashDamage>().getDamage = true;
			StartCoroutine(flash());
			Debug.Log ("redCircle");
		}
		if(col.gameObject.tag == "diamond"){
			Destroy (col.gameObject);
			player.GetComponent<playerMovement> ().diamonds -= 1;
		}
		if(col.gameObject.tag == "player"){
			player.GetComponent<playerMovement> ().gameover = true;
		}
	}

	void Update () {
		
	}

	IEnumerator flash(){
		GetComponent<flashDamage>().getDamage = true;
		aS.Play();
		yield return new WaitForSeconds(0.1f);
		GetComponent<flashDamage>().getDamage = false;
	}
}
