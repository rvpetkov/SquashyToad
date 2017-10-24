using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour {

	#region Public members

	public GameObject VictoryCanvas;

	#endregion

	#region Private members

	private PlayerMovement playerMovement;
	private GvrReticlePointer gvrReticlePointer;
	private ScoreManager scoreManager;

	#endregion

	void Start() {
		playerMovement = FindObjectOfType<PlayerMovement> ();
		gvrReticlePointer = FindObjectOfType<GvrReticlePointer> ();
		scoreManager = FindObjectOfType<ScoreManager> ();
	}

	/// <summary>
	/// Raises the death event.
	/// When the player dies the UI and ReticlePointer are enabled and the player's movement is being disabled.
	/// </summary>
	public void OnVictory() {
		VictoryCanvas.SetActive (true);
		gvrReticlePointer.enabled = true;
		playerMovement.enabled = false;
		GetComponent<Rigidbody> ().isKinematic = true;
		scoreManager.StopTime ();
	}
}
