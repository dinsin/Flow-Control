using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;


public class tutorialPlayerMovement : MonoBehaviour {

	public float speed = .1f;
	public Rigidbody2D self;
	public Camera cam;
	public Text gameStatus;

	void Start () {
		self = GetComponent<Rigidbody2D> ();
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "obstacle"){
			gameStatus.text = "Touched a Red Circle";
		}
	}

	void Update () {
		if(Input.GetKey(KeyCode.RightArrow)){
			transform.Translate(speed, 0f, 0f);
		}
		else if(Input.GetKey(KeyCode.UpArrow)){
			transform.Translate(0f, speed, 0f);
		}
		else if(Input.GetKey(KeyCode.DownArrow)){
			transform.Translate(0f, -speed, 0f);
		}
		else if(Input.GetKey(KeyCode.Space)){
			SceneManager.LoadScene (0);
		}

	}
}
