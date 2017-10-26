using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for keeping track of different types of score in the game - Distance, Time
/// </summary>
public class ScoreManager : MonoBehaviour {

	#region Public members

	public string DistanceScore { get; set; }
	public string TimeScore { get; set; }

	#endregion

	#region Private members

	private Vector3 spawnLocation;
	private float startTime;

	#endregion

	// Use this for initialization
	void Start () {
		spawnLocation = new Vector3 (0, 0, 0);
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance (spawnLocation, GameManager.instance.GetPlayerPosition) / 100;
		DistanceScore = distance.ToString("0.00");
	}

	/// <summary>
	/// This method is used to set the time that has passed since the beginning of the level.
	/// </summary>
	public void StopTime() {
		float timePassed = Time.time - startTime;
		TimeScore = string.Format ("{0:00}:{1:00}:{2:00}", Mathf.Floor(timePassed / 60),  Mathf.Floor(timePassed % 60), (timePassed - (int)timePassed) * 100);
	}
}
