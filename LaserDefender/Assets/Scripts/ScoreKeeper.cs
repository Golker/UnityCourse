using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	int score;
	Text scoreText;

	// Use this for initialization
	void Start () {		
		this.score = 0;
		this.scoreText = GetComponent<Text>();
		this.scoreText.text = "Score: " + score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ChangeScore(int value) {
		this.score += value;
		this.scoreText.text = "Score: " + score.ToString();
	}

	public void Reset() {
		this.score = 0;
		this.scoreText.text = "Score: " + score.ToString();
	}
}
