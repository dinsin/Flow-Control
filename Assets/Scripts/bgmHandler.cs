using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgmHandler : MonoBehaviour {

	public AudioSource audio;
	static bool beginAudio = false;

	void Awake(){
		if (!beginAudio) {
			audio.Play ();
			DontDestroyOnLoad (gameObject);
			beginAudio = true;
		} 
	}

	//void Update () {										Can stop the audio at a certain scene if you want to
	//	if(Application.loadedLevelName == "Proto2"){
	//		audio.Stop();
	//		beginAudio = false;
	//	}
	//}

}
