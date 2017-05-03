using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleMove : MonoBehaviour {

	public Rigidbody2D player;
	public Rigidbody2D self;
	public float speed = 1.2f; //uniform speed

	public static float Ldrag = .5f;

	void Start () {
		self = GetComponent<Rigidbody2D> ();
		GetComponent<Rigidbody2D> ().drag = Ldrag;

	}

	void Update () {
		//moving objects everytime the player moves

		if(Input.GetKey(KeyCode.RightArrow)){
			self.AddForce (new Vector2 (-speed , 0.0f));

		}
		if(Input.GetKey(KeyCode.LeftArrow)){
			self.AddForce (new Vector2 (speed * 3, 0.0f));

		}
		if(Input.GetKey(KeyCode.UpArrow)){
			self.AddForce (new Vector2 (0.0f, -speed));

		}
		if(Input.GetKey(KeyCode.DownArrow)){
			self.AddForce (new Vector2 (0.0f, speed));

		}

	}
}
