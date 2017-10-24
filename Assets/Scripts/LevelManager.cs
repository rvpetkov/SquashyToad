using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// THis class is responsible for managing the transition between scenes and quitting the application.
/// </summary>
public class LevelManager : MonoBehaviour {

	#region Private members

	private LaneSpawner laneSpawner;

	#endregion

	void Start() {
		laneSpawner = FindObjectOfType<LaneSpawner> ();
	}

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
		laneSpawner.DestroyChildren ();
		SceneManager.LoadScene (index);
	}

	public void NextLevel() {
		int index = SceneManager.GetActiveScene ().buildIndex;
		laneSpawner.DestroyChildren ();
		laneSpawner.maxConsecutiveDangerousLanes++;
		laneSpawner.numberOfLanes += 3;
		SceneManager.LoadScene (index);
	}

	public void QuitGame() {
		Debug.Log ("Game will quit!");
		Application.Quit ();
	}
}
