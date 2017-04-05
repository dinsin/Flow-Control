using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelSelection : MonoBehaviour {

	public GameObject indicator;
	public GameObject[] levels;

	void Start(){
		indicator.transform.position = -levels[0].transform.up;
	}
		
	// Update is called once per frame
	void Update () {
		//indicator.transform.position += new Vector3(1f, 0f, 0f);
		if (Input.GetKeyDown (KeyCode.Space)) {
			SceneManager.LoadScene ("LevelSelect");
		}


	}
}
