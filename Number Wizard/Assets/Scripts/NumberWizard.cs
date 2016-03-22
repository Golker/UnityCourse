using UnityEngine;
using System.Collections;

public class NumberWizard : MonoBehaviour {

    int max, min, attempts;    

    // Use this for initialization
    void Start () {
        max = 1000;
        min = 1;
        attempts = 0;

        StartGame();        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            min = (max + min) / 2;
            AskValueQuestion();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            max = (max + min) / 2;
            AskValueQuestion();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            print("The number is " + (max + min) / 2 + "! It took me " + attempts + " attemps!");
            StartGame();
        }
    }

    void StartGame()
    {
        print("Welcome to number wiz! \n "
            + "Pick a number in your head, but don't tell me! \n "
            + "The maximum number you can pick is " + max + " and the minimum is " + min + ".");

        AskValueQuestion();
    }

    void AskValueQuestion()
    {
        print("Is the number higher (up arrow key), lower (down arrow key) than or equal "
            + "(return key) to " + (max + min) / 2 + "?");

        attempts++;
    }
}
