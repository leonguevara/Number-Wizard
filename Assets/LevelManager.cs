using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {



	// Esta función me permite cambiar la escena actual por la escena especificada
	public void LoadLevel(string levelName) {
		// Application.LoadLevel (levelName); <-- Esto ya no funcionará
		SceneManager.LoadScene (levelName);
	}

	public void EndGame() {
		Application.Quit ();
	}
}
