using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

//	public GameObject playerParent;
	public Animator anim;
	public GameObject player;
	CircleCollider2D[] colliders;
	bool endAnimating;
	Vector2 startPos;
	bool enableCol;

	void Start () {
		anim = GetComponent<Animator>();
		endAnimating = false;
		enableCol = false;
		startPos = player.transform.position;
//		anim.Stop();
//		anim.Play("playerin");
//		anim.enabled = true;
//		anim.SetTrigger("playerin");
//		anim.enabled = false;
//		anim.enabled = true;
		colliders = player.GetComponents<CircleCollider2D>();
		for (int i = 0; i < colliders.Length; i++) {
			colliders[i].enabled = false;
		}
		anim.Play("playerin");
//		StartCoroutine(enableCollision());
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.G)) {
//			anim.enabled = true;
//			anim.SetTrigger("pressedSpace");
//			anim.Play("playerin");
//			anim.Play("playerin");
//			anim.Play("playerout");
			for (int i = 0; i < colliders.Length; i++) {
				colliders[i].enabled = false;
			}
			anim.Play("playerout");
		}
		if (enableCol == false) {
			enableCol = true;
			StartCoroutine(enableCollision());
		}
		if ((endAnimating == false) && (player.GetComponent<playerMovement>().collected == 3)) {
			endAnimating = true;
			for (int i = 0; i < colliders.Length; i++) {
				colliders[i].enabled = false;
			}
//			player.transform.position = new Vector2(startPos.x, startPos.y);
//			anim.Play("playerout");
//			endAnimating = true;
		}
	
	}
	IEnumerator enableCollision() {
		yield return new WaitForSeconds(1f);
//		player.GetComponent<CircleCollider2D>().enabled = true;
		for (int i = 0; i < colliders.Length; i++) {
			colliders[i].enabled = true;
		}
		Debug.Log(player.GetComponent<CircleCollider2D>().enabled);
	}
}
