using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour {

	int currentRedzone;
	bool gameover = false;
	public GameObject player;
	public float shakeStrength = 0.0f;
	Vector3 startPosition;

	// Use this for initialization
	void Start () {
		// Remember where the camera started
		startPosition = transform.position;

		currentRedzone = player.GetComponent<playerMovement> ().redZone;

	}

	// Update is called once per frame
	void Update () {

		gameover = player.GetComponent<playerMovement> ().gameover;

		if(gameover || (currentRedzone < player.GetComponent<playerMovement>().redZone)){
			shakeStrength = 1f;
			currentRedzone = player.GetComponent<playerMovement> ().redZone;
			gameover = false;
		}

		// Decay shakeStrength over time
		shakeStrength = Mathf.Clamp(shakeStrength - Time.deltaTime * 20, 0f, 1f);

		// Multiply inside sin wave for faster frequency
		// Multiply outside sin wave for distance/amplitude
		transform.position = startPosition 
			+ shakeStrength * (
				transform.right * Mathf.Sin (Time.time * 25f) * .03f 
				+ transform.up * Mathf.Sin (Time.time * 25f) * .03f);

	}
}

