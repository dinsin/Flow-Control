using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleMove : MonoBehaviour {

	public Rigidbody2D player;
	public Rigidbody2D self;
	public float speed = 1.0f; //uniform speed
	float xPos; //will keep a note of where the object started in
	float yPos; //order to limit how far each axis each object can move.


	void Start () {
		//speed = Random.Range (1.0f, 3.0f) ;
		self = GetComponent<Rigidbody2D> ();
		xPos = transform.position.x;
		yPos = transform.position.y;
	}

	void Update () {
		//moving objects everytime the player moves

		if(Input.GetKey(KeyCode.RightArrow)){
			self.AddForce (new Vector2 (-speed , 0.0f));
			//transform.Translate(-speed, 0f, 0f);

		}
		if(Input.GetKey(KeyCode.LeftArrow)){
			self.AddForce (new Vector2 (speed * 3, 0.0f));
			//transform.Translate(speed, 0f, 0f);

		}
		if(Input.GetKey(KeyCode.UpArrow)){
			self.AddForce (new Vector2 (0.0f, -speed));
			//transform.Translate(0f, -speed, 0f);

		}
		if(Input.GetKey(KeyCode.DownArrow)){
			self.AddForce (new Vector2 (0.0f, speed));
			//transform.Translate(0f, speed, 0f);

		}

	}
}
