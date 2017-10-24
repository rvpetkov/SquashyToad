using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for the movement of obsticles.
/// </summary>
public class ObstacleMovement : MonoBehaviour {

	#region Public members

	public float movementSpeed = 1000f;	//1000 = 10m * 100cm => 10 MPS

	#endregion

	void FixedUpdate()
	{
		transform.GetComponent<Rigidbody> ().MovePosition (transform.position - transform.right * movementSpeed * Time.deltaTime);
	}
}
