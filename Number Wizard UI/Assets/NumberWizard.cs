using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NumberWizard : MonoBehaviour {

    int max, min, attempts, guess, maxAttempts;    

	public Text guessText;

    // Use this for initialization
    void Start () {
        max = 1000;
        min = 1;
        attempts = 0;
		maxAttempts = 10;
		guess = (max + min) / 2;
		guessText.text = "";
		GuessNumber();
	}

	void Update(){
		if(attempts > maxAttempts){
			SceneManager.LoadScene("Win");
		}
	}
	
	void GuessNumber(){		
		guess = Random.Range(min, max);
		Debug.Log(string.Format("Max: {0} | Min: {1} | Guess: {2}", max, min, guess));
		guessText.text = guess.ToString();
		attempts++;
	}

	public void TryHigher(){
		min = guess + 1;
		GuessNumber();
	}

	public void TryLower(){
		max = guess - 1;
		GuessNumber();
	}

	public void CorrectGuess(){
		print("The number is " + guess + "! It took me " + attempts + " attemps!");
		SceneManager.LoadScene("Lose");
	}
}
