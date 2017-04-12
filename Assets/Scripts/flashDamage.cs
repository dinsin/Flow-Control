using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class flashDamage : MonoBehaviour {

	public bool getDamage;
	public GameObject overlay;

	void Start () {
//		overlay.GetComponent<SpriteRenderer>().enabled = true;
	}
	
	void Update () {
		if (getDamage) {
			overlay.GetComponent<SpriteRenderer>().enabled = true;
			Color Opaque = new Color(1, 1, 1, 1);
			overlay.GetComponent<Renderer>().material.color = Color.Lerp(overlay.GetComponent<Renderer>().material.color, Opaque, 20 * Time.deltaTime);
			if (overlay.GetComponent<Renderer>().material.color.a >= 0.8) { //Almost Opaque, close enough
				getDamage = false;
			}
		}
		if (!getDamage) {
			Color Transparent = new Color(1, 1, 1, 0);
			overlay.GetComponent<Renderer>().material.color = Color.Lerp(overlay.GetComponent<Renderer>().material.color, Transparent, 20 * Time.deltaTime);
		}
	}
}
