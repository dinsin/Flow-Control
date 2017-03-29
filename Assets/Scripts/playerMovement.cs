using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class playerMovement : MonoBehaviour {

	public float speed = .5f;
	public Rigidbody2D self;
	public bool gameover = false;
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
		if(goal == true){
			gameStatus.text = "You collected " + collected + "/8 \n";
			if(collected == 8){
				gameStatus.text += "Excellent!";
			}
			else if(collected >=4){
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
