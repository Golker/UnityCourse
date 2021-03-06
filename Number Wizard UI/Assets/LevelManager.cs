﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		//Debug.Log("Level request: " + name);
		SceneManager.LoadScene(name);
	}

	public void QuitRequest(){
		//Debug.Log("Quit request!");
		Application.Quit();
	}

}
