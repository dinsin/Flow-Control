using UnityEngine;
using System.Collections;

/*
public class DamageFlash : MonoBehaviour {

	public SpriteRenderer playerSprite;
	public GameObject player;
	int currentHealth;

	void Start() {

		currentHealth = player.GetComponent<Damageable> ().remainingHealth;

	}
	
	// Update is called once per frame
	void Update () {
		if ( player != null && (currentHealth > player.GetComponent<Damageable> ().remainingHealth)){
			StartCoroutine (Damage (2));
			currentHealth = player.GetComponent<Damageable> ().remainingHealth;
		}
	}

	IEnumerator Damage(int flashCountMax = 4){
		for (int flashCount = 0; flashCount < flashCountMax; flashCount++){
			playerSprite.color = new Color (1f, 0f, 0f);
			yield return new WaitForSeconds (0.1f);
			playerSprite.color = new Color (1f, 1f, 1f);
			yield return new WaitForSeconds (0.1f);

			if(flashCount == 3){
				yield break;
			}

		}
	}
}
*/
