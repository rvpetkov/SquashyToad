using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for the treasure chest connected audio.
/// </summary>
public class ChestAudio : MonoBehaviour {

	#region Private members

	private GvrAudioSource audioSource;
	private bool isOpened = false;

	#endregion

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<GvrAudioSource> ();
	}

	void Update() {
		if (audioSource.time >= 2f) {
			audioSource.Stop();
		}
	}

	void OnTriggerEnter (Collider collider) {
		if (audioSource != null && !isOpened) {
			audioSource.Play ();
			isOpened = true;
		}
	}
}
