using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelSelection : MonoBehaviour {

	public GameObject indicator;
	public GameObject[] levels;
	int index = 0;
//	Vector2 currentPos;
//	float diff;
	public GameObject player;
	float firstRowHeight;
	float secondRowHeight;
	float firstRowPlayerPos;

	void Start() {
//		currentPos = indicator.transform.position;
		firstRowHeight = indicator.transform.position.y;
		secondRowHeight = -212f;
	}
		
	void Update () {
		if (Input.GetKeyDown(KeyCode.RightArrow)) {
			if (index < levels.Length - 1) {
				index++;
				if (index < 6){
					indicator.transform.position = new Vector2(levels[index].transform.position.x, firstRowHeight);	
					player.transform.position = new Vector2(player.transform.position.x + 1.38f, player.transform.position.y);	
				}
				else if (index == 6){
					indicator.transform.position = new Vector2 (levels [index].transform.position.x, firstRowHeight - 50f);
					player.transform.position = new Vector2(player.transform.position.x - (5 * 1.38f), player.transform.position.y - 1.75f);
				}
				else if (index > 6 && index < 12){
					indicator.transform.position = new Vector2 (levels [index].transform.position.x, firstRowHeight - 50f);
					player.transform.position = new Vector2(player.transform.position.x + 1.38f, player.transform.position.y);
				}
//				indicator.transform.position = new Vector2(levels[index].transform.position.x, indicator.transform.position.y);	
//				diff = currentPos.x - levels[index].transform.position.x;
//				indicator.transform.Translate(-diff, 0, 0);
//				currentPos = indicator.transform.position;
//				indicator.transform.position = Vector3.Lerp(currentPos, levels[index].transform.position, Time.deltaTime);
//				currentPos = levels[index].transform.position.x;
//				player.transform.position = new Vector2(player.transform.position.x + 1.38f, player.transform.position.y);	
			}
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			if (index != 0 && index <= 5) {
				index--;
				indicator.transform.position = new Vector2(levels[index].transform.position.x, firstRowHeight);
				player.transform.position = new Vector2(player.transform.position.x - 1.38f, player.transform.position.y);	
			}
			else if (index == 6){
				index--;
				indicator.transform.position = new Vector2 (levels [index].transform.position.x, firstRowHeight);
				player.transform.position = new Vector2(player.transform.position.x + (5 * 1.38f), player.transform.position.y + 1.75f);
			}
			else if (index != 0 && index > 6 && index < 12) {
				index--;
				indicator.transform.position = new Vector2(levels[index].transform.position.x, firstRowHeight - 75f);
				player.transform.position = new Vector2(player.transform.position.x - 1.38f, player.transform.position.y);	
			}
		}
		if (Input.GetKeyDown(KeyCode.Space)) {
			if (index == 0) {
				SceneManager.LoadScene("Level0");
			}
			if (index == 1) {
				SceneManager.LoadScene("Level0.2");
			}
			if (index == 2) {
				SceneManager.LoadScene("avoidObstZ");
			}
			if (index == 3) {
				SceneManager.LoadScene("Level0.3");
			}
			if (index == 4) {
				SceneManager.LoadScene("Level1.3");
			}
			if (index == 5) {
				SceneManager.LoadScene("Level0.4");
			}
			if (index == 6) {
				SceneManager.LoadScene("usingObst");
			}
			if (index == 7) {
				SceneManager.LoadScene("Level1.1");
			}
			if (index == 8) {
				SceneManager.LoadScene("newLevel3");
			}
			if (index == 9) {
				SceneManager.LoadScene("Level1.2");
			}
			if (index == 10) {
				SceneManager.LoadScene("Proto2");
			}
			if (index == 11) {
				SceneManager.LoadScene("Level2");
			}

		}

	}
}
