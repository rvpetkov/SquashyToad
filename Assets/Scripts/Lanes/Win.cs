using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour {

	#region Private members

	private Victory victoryComponent;

	#endregion

	// Use this for initialization
	void Start () {
		victoryComponent = FindObjectOfType<Victory> ();
	}

	void OnCollisionEnter(Collision collision) {
		victoryComponent.OnVictory ();
	}
}
