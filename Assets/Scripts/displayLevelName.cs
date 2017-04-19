using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayLevelName : MonoBehaviour {

	public GameObject overlay;
	public Text levelName;

	// Use this for initialization
	void Start () {
		//overlay.SetActive (true);
		//levelName.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine (EnableOverlay ());
		StartCoroutine (DisableOverlay ());
	}

	IEnumerator DisableOverlay(){
		yield return new WaitForSeconds (2.4f);
		overlay.SetActive (false);
		levelName.enabled = false;
	}

	IEnumerator EnableOverlay(){
		overlay.SetActive (true);
		levelName.enabled = true;
		yield return new WaitForSeconds (.1f);
	}
}
