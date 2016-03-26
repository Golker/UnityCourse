using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	public static int score = 0;
	Text scoreText;

	// Use this for initialization
	void Start () {		
		this.scoreText = GetComponent<Text>();
		this.scoreText.text = "Score: " + score.ToString();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void ChangeScore(int value) {
		ScoreKeeper.score += value;
		this.scoreText.text = "Score: " + score.ToString();
	}

	public static void Reset() {
		ScoreKeeper.score = 0;
	}
}
