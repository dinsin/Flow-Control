using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene ().name != "Title" && SceneManager.GetActiveScene ().name != "LevelSelect"){
			SceneManager.LoadScene ("LevelSelect");
		}
		else if(Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene ().name == "LevelSelect"){
			SceneManager.LoadScene ("Title");
		}
	}
}
