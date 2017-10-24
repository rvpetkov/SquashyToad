using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class makes a Game Object lethal - gives it the ability to call the OnDeath() method (which kills the player).
/// </summary>
public class Lethal : MonoBehaviour {

	#region Private members

	private Death deathComponent;

	#endregion

	// Use this for initialization
	void Start () {
		deathComponent = FindObjectOfType<Death> ();
	}

	void OnCollisionEnter(Collision collision) {
		deathComponent.OnDeath ();
	}
}
