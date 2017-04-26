using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

//	public GameObject playerParent;
	public Animator anim;
	public GameObject player;

	void Start () {
		anim = GetComponent<Animator>();
//		anim.Stop();
//		anim.Play("playerin");
//		anim.enabled = true;
//		anim.SetTrigger("playerin");
//		anim.enabled = false;
//		anim.enabled = true;
		anim.Play("playerin");
		player.GetComponent<CircleCollider2D>().enabled = false;
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.G)) {
//			anim.enabled = true;
//			anim.SetTrigger("pressedSpace");
//			anim.Play("playerin");
//			anim.Play("playerin");
			anim.Play("playerout");
		}
		StartCoroutine(enableCollision());
	
	}
	IEnumerator enableCollision() {
		yield return new WaitForSeconds(1f);
		player.GetComponent<CircleCollider2D>().enabled = true;
		Debug.Log(player.GetComponent<CircleCollider2D>().enabled);
	}
}
