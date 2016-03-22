using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		Brick.BreakableCount = 0;
		SceneManager.LoadScene(name);
	}

	public void QuitRequest(){
		Application.Quit();
	}

	public void LoadNextLevel() {
		Brick.BreakableCount = 0;
		Scene currentScene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(currentScene.buildIndex + 1);
	}

	public void BrickDestroyed() {
		if (Brick.BreakableCount == 0) {
			LoadNextLevel();
		}
	}

}
