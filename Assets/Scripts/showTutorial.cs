using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class showTutorial : MonoBehaviour {

	public Text directionText;
	bool pressUp = false;
	bool pressDown = false;
	bool pressRight = false;
	bool pressLeft = false;
	public GameObject player;
	public GameObject enemy;
	Vector2 playerStart;
	Vector2 enemyStart;
	public bool canPressDown;
	public bool canPressUp;
	public bool canPressLeft;
	public bool canPressRight;

	void Start () {
		playerStart = player.transform.position;
		enemyStart = enemy.transform.position;

		canPressDown = false;
		canPressUp = false;
		canPressLeft = false;
		canPressRight = false;
		StartCoroutine(showStart());
	}
	
	void Update () {
		if (Input.GetKey(KeyCode.UpArrow) && pressUp) {
			directionText.text = "Good job!";
			pressUp = false;
			StartCoroutine(showDown());
		}
		if (Input.GetKey(KeyCode.DownArrow) && pressDown) {
			directionText.text = "Good job!";
			pressDown = false;
			StartCoroutine(showLeft());
		}
		if (Input.GetKey(KeyCode.LeftArrow) && pressLeft) {
			directionText.text = "Good job!";
			pressLeft = false;
			StartCoroutine(showRight());
		}
		if (Input.GetKey(KeyCode.RightArrow) && pressRight) {
			directionText.text = "Good job!";
			pressRight = false;
			StartCoroutine(endTutorial());
//			StartCoroutine(showLeft());
		}
	}

	IEnumerator showStart() {
//		yield return new WaitForSeconds(2.0f);
		directionText.text = "Obstacles move in the opposite direction";
		yield return new WaitForSeconds(4.0f);
//		StartCoroutine(showUp());
		directionText.text = "hold UP";

		canPressDown = false;
		canPressUp = true;
		canPressLeft = false;
		canPressRight = false;

		pressUp = true;

		while (pressUp) {
			yield return new WaitForSeconds(1.0f);
			directionText.text += ".";
		}
	}

	IEnumerator showDown() {
		yield return new WaitForSeconds(2.0f);
		resetPosition();
		directionText.text = "hold DOWN";
		pressDown = true;

		canPressDown = true;
		canPressUp = false;
		canPressLeft = false;
		canPressRight = false;

		while (pressDown) {
			yield return new WaitForSeconds(1.0f);
			directionText.text += ".";
		}
	}

	IEnumerator showLeft() {
		yield return new WaitForSeconds(2.0f);
		resetPosition();
		directionText.text = "hold LEFT";
		pressLeft = true;

		canPressDown = false;
		canPressUp = false;
		canPressLeft = true;
		canPressRight = false;

		while (pressLeft) {
			yield return new WaitForSeconds(1.0f);
			directionText.text += ".";
		}
	}

	IEnumerator showRight() {
		directionText.text = "keep in mind\nyou do not move when holding LEFT";
		yield return new WaitForSeconds(4.0f);
		resetPosition();
		directionText.text = "hold RIGHT";
		pressRight = true;

		canPressDown = false;
		canPressUp = false;
		canPressLeft = false;
		canPressRight = true;

		while (pressRight) {
			yield return new WaitForSeconds(1.0f);
			directionText.text += ".";
		}
	}

	IEnumerator endTutorial() {
		directionText.text = "avoid red balls!";
		yield return new WaitForSeconds(2.0f);
		SceneManager.LoadScene("Proto2");
	}

	void resetPosition() {
		player.transform.position = playerStart;
		enemy.transform.position = enemyStart;
		enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
	}

}
