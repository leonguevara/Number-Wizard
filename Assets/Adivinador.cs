// Utiliza las siguientes bibliotecas para poder funcionar correctamente
using UnityEngine;           // Máquina de juegos
using System.Collections;    // Colecciones
using UnityEngine.UI;        // Interfaz de usuario de la máquina de juegos

public class Adivinador : MonoBehaviour {
	// Atributos (variables dentro de una clase)
	// [Alcance] TipoDeDatoObjeto NombreVariable [ValorInicial]
	int min = 1;
	int max = 1000;
	int guess = 500;

	// Estos atributos son públicos
	public Text myText;
	public int attempts = 5;

	// Use this for initialization
	// Esto es un método
	// [Alcance] TipoDeDatoObjeto NombreMetodo([Parámetros]) { ... }
	void Start () {
		ResetGame ();  // Toda línea debe terminar con punto y coma (;)
	}
	
	// Update is called once per frame
	void Update () {
		// if (PruebaLógica) { ... Verdadero ... } [ else { ... Falso ... } ]

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

		/*
		if (5 > 4)
			min = 0;
		*/
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
