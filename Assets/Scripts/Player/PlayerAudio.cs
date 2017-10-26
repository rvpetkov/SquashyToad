using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for the player connected audio.
/// </summary>
public class PlayerAudio {

	#region Private members

	private GvrAudioSource audioSource;

	#endregion

	#region Constructors

	public PlayerAudio(GvrAudioSource audioSource) {
		this.audioSource = audioSource;
	}

	#endregion
	
	public void PlayJumpSound() {
		if (audioSource != null) {
			audioSource.Play ();
		}
	}
}
