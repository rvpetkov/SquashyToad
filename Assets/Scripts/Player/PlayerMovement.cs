using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	#region Public members

	public float[] jumpModifiers = {300f, 500f, 700f};

	#endregion

	#region Private members

	private static int JUMP_ANGLE_IN_DEGREES = 45;

	private Rigidbody rb;
	private Camera playerCamera;
	private Vector3 jumpVector;
	private bool isGrounded = false;
	private int groudingCounter = 0;
	private int jumpCounter = 0;	//counts how many times the player has jumped in mid air - 3 time max
	private Death deathComponent;

	//player audio
	private PlayerAudio playerAudio;

	#endregion

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		playerCamera = GetComponentInChildren<Camera> ();
		jumpVector = new Vector3 (0, 3, 5);
		deathComponent = FindObjectOfType<Death> ();

		playerAudio = new PlayerAudio(GetComponent<GvrAudioSource>());
	}
	
	// Update is called once per frame
	void Update () {
		isGrounded = groudingCounter > 0;
		if (isGrounded) {
			jumpCounter = 0;
		}

		if (Input.GetButtonDown("Fire1") && jumpCounter < jumpModifiers.Length) {
			Jump (jumpModifiers[jumpCounter]);
			playerAudio.PlayJumpSound ();
			jumpCounter++;
		}

		if (transform.position.y < 0) {
			deathComponent.OnDeath ();
		}
	}

	void OnCollisionEnter(Collision collision) {
		groudingCounter++;
	}

	void OnCollisionExit(Collision collisionInfo) {
		groudingCounter--;
	}

	/// <summary>
	/// Used to make the player jump.
	/// </summary>
	/// <param name="jumpModifier">Multiplies the jump force vector.</param>
	private void Jump(float jumpModifier) {
		Vector3 forwardProjection = Vector3.ProjectOnPlane (playerCamera.transform.forward, Vector3.up);
		jumpVector = Vector3.RotateTowards (forwardProjection, Vector3.up, Mathf.Deg2Rad * JUMP_ANGLE_IN_DEGREES, 0);
		jumpVector = jumpVector.normalized;

		rb.AddForce(jumpVector * jumpModifier, ForceMode.VelocityChange);
	}
}
