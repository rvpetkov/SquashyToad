using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// THis class is responsible for managing the transition between scenes and quitting the application.
/// </summary>
public class LevelManager : MonoBehaviour {

	public void LoadNextScene() {
		int index = SceneManager.GetActiveScene ().buildIndex;
		SceneManager.LoadScene (++index);
	}

	public void LoadPreviousScene() {
		int index = SceneManager.GetActiveScene ().buildIndex;
		SceneManager.LoadScene (--index);
	}

	public void ReplayScene() {
		int index = SceneManager.GetActiveScene ().buildIndex;
		SceneManager.LoadScene (index);
	}

	public void NextLevel() {
		int index = SceneManager.GetActiveScene ().buildIndex;
		GameManager.instance.maxConsecutiveDangerousLanes++;
        GameManager.instance.numberOfLanes += 3;
		SceneManager.LoadScene (index);
	}

	public void QuitGame() {
		Debug.Log ("Game will quit!");
		Application.Quit ();
	}
}
