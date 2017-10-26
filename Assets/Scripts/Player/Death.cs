using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for the player's death.
/// </summary>
public class Death : MonoBehaviour {

	#region Public members

	public GameObject GameOverCanvas;

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
	public void OnDeath() {
		GameOverCanvas.SetActive (true);
		gvrReticlePointer.enabled = true;
		playerMovement.enabled = false;
		GetComponent<Rigidbody> ().isKinematic = true;
		scoreManager.StopTime ();
	}
}
