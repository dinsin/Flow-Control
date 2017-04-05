using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class playerMovement : MonoBehaviour {

	public float speed = .5f;
	public Rigidbody2D self;
	public Rigidbody2D goalZone;
	public bool gameover = false;
	public int redZone = 0;
	public Text gameStatus;
	public int diamonds = 8;  //set number of diamonds in inspector
	int collected = 0;
	public bool goal = false;
	public AudioSource aS;

	void Start () {
		self = GetComponent<Rigidbody2D> ();
		gameover = false;
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "diamond"){
			
			Destroy (col.gameObject);
			collected += 1;
			Debug.Log ("Collected Diamond");
		}
		else if(col.gameObject.tag == "obstacle"){
			//gameStatus.text = "Touched a Red Circle";
			gameover = true;
			aS.GetComponent<gameSound> ().hitObstacle = true;
			//Destroy (gameObject);
		}
	}
	IEnumerator restartGame(){
		Debug.Log ("Gameover");
		//gameStatus.enabled = true;
		yield return new WaitForSeconds (1.5f);
		//gameStatus.enabled = false;
		//SceneManager.LoadScene (0);

		//Restarts current level
		Application.LoadLevel(Application.loadedLevel);


	}


	void Update () {
		if(gameover){
			StartCoroutine (restartGame ());
		}
		if(collected >=diamonds){
			goalZone.GetComponent<SpriteRenderer> ().enabled = true;
			goalZone.GetComponent<goalZone> ().enabled = true;
		}
		if(goal == true){
			//gameStatus.text = "You collected " + collected + "/8 \n";
			if(collected == diamonds){
				//gameStatus.text += "Excellent!";
			}
			else if(collected >=diamonds-2){
				//gameStatus.text += "You win!";
			}
			else{
				//gameStatus.text += "You Lose!";
			}
			StartCoroutine (restartGame ());
			//gameover = true;
		}
		if(redZone >= 3){
			//gameStatus.text = "3 Red circles entered Red Zone";
			Debug.Log("3circles");
			gameover = true;
		}
		if(Input.GetKey(KeyCode.RightArrow)){
			transform.Translate(speed, 0f, 0f);
			//self.AddForce (new Vector2 (speed , 0.0f));\
		}
		else if(Input.GetKey(KeyCode.LeftArrow)){
		}
		else if(Input.GetKey(KeyCode.UpArrow)){
			transform.Translate(0f, speed, 0f);
			//self.AddForce (new Vector2 (0f , speed));
		}
		else if(Input.GetKey(KeyCode.DownArrow)){
			transform.Translate(0f, -speed, 0f);
			//self.AddForce (new Vector2 (0f , -speed));
		}
		else if(Input.GetKey(KeyCode.Space)){
			Application.LoadLevel(Application.loadedLevel);
			//SceneManager.LoadScene (0);
		}
	}
}