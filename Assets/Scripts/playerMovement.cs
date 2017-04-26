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
	public int diamonds = 5;  //set number of diamonds in inspector
	int collected = 0;
	public bool goal = false;
	public AudioSource aS;
	public ParticleSystem ps;
	float psStartSpeed;
	float psStartSize;
	float psStartEmissionRate;
	float psStartLifetime;
	public GameObject particlePrefab;

	void Start() {
		self = GetComponent<Rigidbody2D>();
		gameover = false;
		psStartSpeed = ps.startSpeed;
		psStartSize = ps.startSize;
		psStartEmissionRate = ps.emissionRate;
		psStartLifetime = ps.startLifetime;
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.CompareTag("obstacle")) {
			//Vector3 position = (col.transform.position - transform.position) / 2;
			Object explosion = Instantiate(particlePrefab, col.transform.position, Quaternion.Euler(0, 0, 0));
			Destroy(explosion, 3.0f);
			Debug.Log("Almost Collided");
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "diamond") {
			Destroy(col.gameObject);
			collected += 1;
			Debug.Log ("Collected Diamond");
		}
		else if (col.gameObject.tag == "obstacle") {
//			StartCoroutine(particleCollision());
			ContactPoint2D contact = col.contacts[0];
			Object explosion = Instantiate(particlePrefab, contact.point, Quaternion.Euler(0, 0, 0));
			Destroy(explosion, 3.0f);
			Debug.Log("Collided");

//			self.velocity *= -10;
//			self.AddForce(self.velocity.x * -1, self.velocity.y * -1);

			aS.GetComponent<gameSound>().hitObstacle = true;
			gameover = true;
		}
		else if (col.gameObject.tag == "titleObstacle") {
			ContactPoint2D contact = col.contacts[0];
			Object explosion = Instantiate(particlePrefab, contact.point, Quaternion.Euler(0, 0, 0));
			Destroy(explosion, 3.0f);
			Debug.Log("Collided");
			aS.GetComponent<gameSound>().hitObstacle = true;
		}
	}
	IEnumerator restartGame() {
		Debug.Log("Gameover");
		yield return new WaitForSeconds(0.5f);
		//Restarts current level
		Application.LoadLevel(Application.loadedLevel);


	}

	IEnumerator nextLevel(){
		yield return new WaitForSeconds (.5f);
		if (SceneManager.GetActiveScene ().name  == "avoidObstZ")
			SceneManager.LoadScene ("Level1.3");

		//SceneManager.LoadScene ("Level1.3");
		else if (SceneManager.GetActiveScene ().name == "Level1.3")
			SceneManager.LoadScene ("Level1.2");
		else if (SceneManager.GetActiveScene ().name == "Level1.2")
			SceneManager.LoadScene ("Level2");
		else if (SceneManager.GetActiveScene ().name  == "Level2")
			SceneManager.LoadScene ("usingObst");
		//else if (SceneManager.GetActiveScene ().name == "Level1.3")
		//	SceneManager.LoadScene ("Proto2");


		else if (SceneManager.GetActiveScene ().name == "usingObst")
			SceneManager.LoadScene ("Level1.1");

		else if (SceneManager.GetActiveScene ().name == "Level1.1")
			SceneManager.LoadScene ("Level3");
		else if (SceneManager.GetActiveScene ().name == "Level3")
			SceneManager.LoadScene ("Proto2");
	}
		
	void Update() {
		if (gameover) {
			Debug.Log("LOST");
			collected = 0;
			StartCoroutine (restartGame ());
		}
		if (collected >= diamonds) {
			//goalZone.GetComponent<SpriteRenderer>().enabled = true;
			//goalZone.GetComponent<goalZone>().enabled = true;
			//goal = true;
			Debug.Log ("WON");
			StartCoroutine (nextLevel ());

		}
		if (goal == true) {
			//StartCoroutine (restartGame ());
		}
		if (redZone >= 3) {
			Debug.Log("3circles");
			gameover = true;
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			self.velocity = new Vector2(self.velocity.x + speed, self.velocity.y);
		}
		if (Input.GetKey(KeyCode.LeftArrow)) {
			ps.startSpeed = 3.5f;
			ps.startSize = 2.0f;
			ps.emissionRate = 20;
			ps.startLifetime = 1;
		}
		if (Input.GetKeyUp(KeyCode.LeftArrow)) {
			ps.startSpeed = psStartSpeed;
			ps.startSize = psStartSize;
			ps.emissionRate = psStartEmissionRate;
			ps.startLifetime = psStartLifetime;
		}
		if (Input.GetKey(KeyCode.UpArrow)) {
			self.velocity = new Vector2(self.velocity.x, self.velocity.y + speed);
		}
		else if (Input.GetKey(KeyCode.DownArrow)) {
			self.velocity = new Vector2(self.velocity.x, self.velocity.y - speed);
		}
		else if (Input.GetKey(KeyCode.Space)) {
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	IEnumerator particleCollision() {
//		float prevStartSpeed = ps.startSpeed;
//		float prevStartSize = ps.startSize;
//		float prevEmissionRate = ps.emissionRate;
//
		ps.startSpeed = 10.5f;
		ps.startSize = 2.5f;
		ps.emissionRate = 50;
		ps.startLifetime = 0.4f;

		yield return new WaitForSeconds(0.2f);

		ps.startSpeed = psStartSpeed;
		ps.startSize = psStartSize;
		ps.emissionRate = psStartEmissionRate;
		ps.startLifetime = psStartLifetime;

		Debug.Log("Finished collision");
	}
}