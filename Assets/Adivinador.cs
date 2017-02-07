using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Adivinador : MonoBehaviour {
	int min = 1;
	int max = 1000;
	int guess = 500;
	public Text myText;
	public int attempts = 5;

	// Use this for initialization
	void Start () {
		ResetGame ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			//print ("Up arrow was pressed");
			GuessHigher();

		} else {
			if (Input.GetKeyDown (KeyCode.DownArrow)) {
				//print ("Down arrow was pressed");
				GuessLower();
			} else {
				if (Input.GetKeyDown(KeyCode.Return)) {
					LevelManager lm = new LevelManager ();
					lm.LoadLevel ("Lose");
				}
			}
		}
	}

	public void GuessHigher() {
		min = guess;
		UpdateGuess ();
	}

	public void GuessLower() {
		max = guess;
		UpdateGuess ();
	}

	void UpdateGuess() {
		attempts -= 1; // <-- Es lo mismo que attempts = attempts - 1
		// attempts--;

		if (attempts > 0) {
			guess = (max + min) / 2;

			//print ("El número que pensaste es " + guess + "?");
			myText.text = "Did you think of number " + guess + "?";
		} else {
			LevelManager lm = new LevelManager ();
			lm.LoadLevel ("Win");
		}
	}

	void ResetGame() {
		min = 1;
		max = 1000;
		guess = 500;

		myText.text = "Did you think of number " + guess + "?";
		//print ("Bienvenido al juego del Adivinador");
		//print ("Elige un número, pero no me lo digas");

		//print ("El límite inferior es " + min);
		//print ("El límite superior es " + max);

		//print ("El número que pensaste es 500?");
		//print ("Flecha arriba = mayor, Flecha abajo = menor, enter = igual");
	}
}
