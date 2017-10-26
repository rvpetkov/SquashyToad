using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is used to destroy obstacles and other spawnable objects in the scene to prevent memory leaks.
/// </summary>
public class Destructor : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		Destroy (other.gameObject);
	}
}
