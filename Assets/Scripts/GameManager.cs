using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LevelManager))]
public class GameManager : MonoBehaviour {

	[HideInInspector] public static GameManager instance = null;

	#region Private members

	private LevelManager levelManager = null;

	#endregion

	#region Constructors

	private GameManager() {	}

	#endregion

	// TODO check if the verification in awake() is really needed or the private constructor is enough to ensure the Singleton pattern
	void Awake () {
		if (instance == null) {		//Check if instance already exists
			instance = this;
		} else if (instance != this) {	//If instance already exists and it's not this:
			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);
		}

		//Don't destroy this when reloading/changing scenes.
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public LevelManager LevelManager {
		get {
			if (levelManager == null) {
				levelManager = GetComponent<LevelManager> ();
			}
			return levelManager;
		}
	}
}
