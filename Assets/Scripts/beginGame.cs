using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;


public class beginGame : MonoBehaviour {

	public float speed = .1f;
	public Rigidbody2D self;
	public Camera cam;
	public Text gameStatus;
	Vector2 startPos;

	void Start () {
		self = GetComponent<Rigidbody2D> ();
		startPos = transform.position;
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "diamond") {
			SceneManager.LoadScene ("Info");
		} 
	}

	void Update () {
//		if(Input.GetKey(KeyCode.RightArrow)){
//			transform.Translate(speed, 0f, 0f);
//		}
//		else if(Input.GetKey(KeyCode.UpArrow)){
//			transform.Translate(0f, speed, 0f);
//		}
//		else if(Input.GetKey(KeyCode.DownArrow)){
//			transform.Translate(0f, -speed, 0f);
//		}

		if (transform.position.x > 6f) {
			transform.position = new Vector2(startPos.x, startPos.y);
		}
	}
}
