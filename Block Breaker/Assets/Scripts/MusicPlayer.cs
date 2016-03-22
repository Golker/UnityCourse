using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	public static MusicPlayer musicPlayer = null;

	void Awake() {
		if (MusicPlayer.musicPlayer == null) {
			musicPlayer = this;
			GameObject.DontDestroyOnLoad(gameObject); 
		} else {
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
