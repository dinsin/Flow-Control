using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class redZone : MonoBehaviour {

	public Rigidbody2D player;
	public AudioSource aS;
	bool gameover = false;

	void Start () {
		
	}

	IEnumerator reStart(){
		yield return new WaitForSeconds (1.0f);
		//Restarts current level
		Application.LoadLevel(Application.loadedLevel);

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
			StartCoroutine (reStart ());
		}
	}

	void Update () {

	}

	IEnumerator flash(){
		GetComponent<flashDamage>().getDamage = true;
		//aS.Play();
		yield return new WaitForSeconds(0.1f);
		GetComponent<flashDamage>().getDamage = false;
	}
}
