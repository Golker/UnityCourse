using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		SceneManager.LoadScene(name);
	}

	public void QuitRequest(){
		Application.Quit();
	}

	public void LoadNextLevel() {
		Scene currentScene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(currentScene.buildIndex + 1);
	}

	public void PlayerKilled() {
		LoadLevel("Lose");
	}

	public void AllEnemiesKilled() {
		LoadNextLevel();
	}
}
