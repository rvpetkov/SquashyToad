using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is used to create the proper rotation and movement for the UI element in the scene.
/// </summary>
public class HUDRotation : MonoBehaviour {

	#region Private members

	private Camera playerCamera;
	private Vector3 forwardProjection;

	#endregion

	// Use this for initialization
	void Start () {
		playerCamera = transform.parent.GetComponentInChildren<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		forwardProjection = Vector3.ProjectOnPlane (playerCamera.transform.forward, Vector3.up);
		transform.rotation = Quaternion.LookRotation (forwardProjection);
	}
}
