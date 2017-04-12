using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelSelection : MonoBehaviour {

	public GameObject indicator;
	public GameObject[] levels;
	int index = 0;

	void Start() {
		
	}
		
	void Update () {
		if (Input.GetKeyDown(KeyCode.RightArrow)) {
			if (index < levels.Length - 1) {
				index++;
				indicator.transform.position = new Vector2(levels[index].transform.position.x, indicator.transform.position.y);		
			}
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			if (index != 0) {
				index--;
				indicator.transform.position = new Vector2(levels[index].transform.position.x, indicator.transform.position.y);
			}
		}
		if (Input.GetKeyDown(KeyCode.Space)) {
			if (index == 0) {
				SceneManager.LoadScene("avoidObstZ");
			}
			if (index == 1) {
				SceneManager.LoadScene("Level1.1");
			}
			if (index == 2) {
				SceneManager.LoadScene("Level1.2");
			}
			if (index == 3) {
				SceneManager.LoadScene("Level1.3");
			}
			if (index == 4) {
				SceneManager.LoadScene("Level2");
			}
			if (index == 5) {
				SceneManager.LoadScene("Level3");
			}
			if (index == 6) {
				SceneManager.LoadScene("Proto2");
			}
		}

	}
}
