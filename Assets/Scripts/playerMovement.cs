using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class playerMovement : MonoBehaviour {

	public float speed = .5f;
	public Rigidbody2D self;
<<<<<<< HEAD
	public Rigidbody2D goalZone;
	bool gameover = false;
=======
	public bool gameover = false;
>>>>>>> 84cc51ab1b5a83d4a49fc1d7e122fd315bd81656
	public int redZone = 0;
	public Text gameStatus;
	public int diamonds = 8;
	public int collected = 0;
	public bool goal = false;

	void Start () {
		self = GetComponent<Rigidbody2D> ();
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "diamond"){
			Destroy (col.gameObject);
			collected += 1;
			Debug.Log ("Collected Diamond");
		}
		else if(col.gameObject.tag == "obstacle"){
			gameStatus.text = "Touched a Red Circle";
			gameover = true;
			//Destroy (gameObject);
		}
	}
	IEnumerator restartGame(){
		gameStatus.enabled = true;
		yield return new WaitForSeconds (1.1f);
		gameStatus.enabled = false;
		SceneManager.LoadScene (0);

	}


	void Update () {
		if(gameover){
			StartCoroutine (restartGame ());
		}
<<<<<<< HEAD
		if(collected >=6){
			goalZone.GetComponent<SpriteRenderer> ().enabled = true;
			goalZone.GetComponent<goalZone> ().enabled = true;
		}
=======
>>>>>>> 84cc51ab1b5a83d4a49fc1d7e122fd315bd81656
		if(goal == true){
			gameStatus.text = "You collected " + collected + "/8 \n";
			if(collected == 8){
				gameStatus.text += "Excellent!";
			}
<<<<<<< HEAD
			else if(collected >=6){
=======
			else if(collected >=4){
>>>>>>> 84cc51ab1b5a83d4a49fc1d7e122fd315bd81656
				gameStatus.text += "You win!";
			}
			else{
				gameStatus.text += "You Lose!";
			}
			gameover = true;
		}
		if(redZone > 3){
			gameStatus.text = "3 Red circles entered Red Zone";
			gameover = true;
		}
		if(Input.GetKey(KeyCode.RightArrow)){
			transform.Translate(speed, 0f, 0f);
		}
<<<<<<< HEAD
		else if(Input.GetKey(KeyCode.LeftArrow)){
			//transform.Translate(-speed, 0f, 0f);
		}
=======
>>>>>>> 84cc51ab1b5a83d4a49fc1d7e122fd315bd81656
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
