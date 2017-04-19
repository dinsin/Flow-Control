using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class playerMovement : MonoBehaviour {

	float speed = 1.0f;
	public Rigidbody2D self;
	public Rigidbody2D goalZone;
	public bool gameover = false;
	public int redZone = 0;
	public Text gameStatus;
	public int diamonds = 3;  //set number of diamonds in inspector
	int collected = 0;
	public bool goal = false;
	public AudioSource aS;
	public ParticleSystem ps;
	float psStartSpeed;
	float psStartSize;
	float psStartEmissionRate;

	void Start () {
		self = GetComponent<Rigidbody2D> ();
		gameover = false;
		psStartSpeed = ps.startSpeed;
		psStartSize = ps.startSize;
		psStartEmissionRate = ps.emissionRate;
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "diamond"){
			
			Destroy (col.gameObject);
			collected += 1;
			Debug.Log ("Collected Diamond");
		}
		else if(col.gameObject.tag == "obstacle"){
			gameover = true;
			aS.GetComponent<gameSound> ().hitObstacle = true;
		}
	}

	IEnumerator nextLevel(){
		yield return new WaitForSeconds (.5f);
		if (SceneManager.GetActiveScene ().name  == "Level1.1")
			SceneManager.LoadScene ("avoidObstZ");

		//SceneManager.LoadScene ("Level1.3");
		else if (SceneManager.GetActiveScene ().name == "avoidObstZ")
			SceneManager.LoadScene ("Level1.3");
		else if (SceneManager.GetActiveScene ().name == "Level1.3")
			SceneManager.LoadScene ("usingObst");
		else if (SceneManager.GetActiveScene ().name  == "usingObst")
			SceneManager.LoadScene ("Level1.2");
		//else if (SceneManager.GetActiveScene ().name == "Level1.3")
		//	SceneManager.LoadScene ("Proto2");


		else if (SceneManager.GetActiveScene ().name == "Level1.2")
			SceneManager.LoadScene ("Level2");

		else if (SceneManager.GetActiveScene ().name == "Level2")
			SceneManager.LoadScene ("Level3");
	}

	IEnumerator restartGame(){
		Debug.Log ("Gameover");
		yield return new WaitForSeconds (0.5f);
		//Restarts current level
		Application.LoadLevel(Application.loadedLevel);

	}


	void Update () {
		if(gameover){
			Debug.Log ("LOST");
			collected = 0;
			StartCoroutine (restartGame ());
		}
		if(collected >=diamonds){
			//goalZone.GetComponent<SpriteRenderer> ().enabled = true;
			//goalZone.GetComponent<goalZone> ().enabled = true;
			//goal = true;
			Debug.Log ("WON");
			StartCoroutine (nextLevel ());

		}
		if(goal == true){
			//StartCoroutine (restartGame ());
		}
		if(redZone >= 3){
			Debug.Log("3circles");
			gameover = true;
		}
		if(Input.GetKey(KeyCode.RightArrow)){
//			transform.Translate(speed, 0f, 0f);
//			self.AddForce (new Vector2 (speed , 0.0f));
			self.velocity = new Vector2(self.velocity.x + speed, self.velocity.y);
		}
		if(Input.GetKey(KeyCode.LeftArrow)){
			ps.startSpeed = 3.5f;
			ps.startSize = 2.5f;
			ps.emissionRate = 20;
		}
		if(Input.GetKeyUp(KeyCode.LeftArrow)) {
			ps.startSpeed = psStartSpeed;
			ps.startSize = psStartSize;
			ps.emissionRate = psStartEmissionRate;
		}
		if(Input.GetKey(KeyCode.UpArrow)){
//			transform.Translate(0f, speed, 0f);
			//self.AddForce (new Vector2 (0f , speed));
			self.velocity = new Vector2(self.velocity.x, self.velocity.y + speed);
		}
		else if(Input.GetKey(KeyCode.DownArrow)){
//			transform.Translate(0f, -speed, 0f);
			//self.AddForce (new Vector2 (0f , -speed));
			self.velocity = new Vector2(self.velocity.x, self.velocity.y - speed);
		}
		else if(Input.GetKey(KeyCode.Space)){
			Application.LoadLevel(Application.loadedLevel);
			//SceneManager.LoadScene (0);
		}
	}
}