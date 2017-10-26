using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is used to control the treasure chest's animations.
/// </summary>
public class TreasureChest : MonoBehaviour {
	
	#region Private members

	private Animator animator;
	private bool isOpened = false;
	private Treasure treasure;

	#endregion

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		treasure = GetComponentInChildren<Treasure> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider collider) {
		if (!isOpened) {
			animator.Play ("ChestOpen", 0, 0f);
			isOpened = true;

			treasure.RevealTreasure ();
		}
	}
}
