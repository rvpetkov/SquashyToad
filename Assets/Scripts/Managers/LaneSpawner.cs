using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum LaneType { 
	Safe = 0, 
	Dangerous = 1 
}
		
/// <summary>
/// This class is used to dynamicly create the map.
/// The map consists of different lanes of the same size. These lanes could be safe or dangerous.
/// The number of lanes and the level's difficulty are open to adjustments.
/// </summary>
public class LaneSpawner : MonoBehaviour {

	#region Public members

	public GameObject[] safeLanes;
	public GameObject[] dangerousLanes;
	public GameObject victoryLane;
	public int laneSpawnDistance = 5000;	//Lanes after this distance are not yet created 
											//and lanes before this distance are destroyed.

	#endregion

	#region Private members

	private LaneType lastSpawnedLane = LaneType.Dangerous;
	private int consecutiveDangerousLaneCount;
	private int spawnedLanes = 0;
	private int offset = 0;

	#endregion

	// Use this for initialization
	void Start () {
		SpawnPlayer ();
		consecutiveDangerousLaneCount = GameManager.instance.maxConsecutiveDangerousLanes;	//This way the first spawned lane is a Safe one
	}

	void Update() {
		CreateLanesDynamically ();
		DestroyPastLanes ();
	}

	/// <summary>
	/// Creates the lanes dynamicly based on the player's location along the Z axis.
	/// </summary>
	private void CreateLanesDynamically() {
		while ((offset < laneSpawnDistance + GameManager.instance.GetPlayerPosition.z) && (spawnedLanes < GameManager.instance.numberOfLanes)) {
			if ((lastSpawnedLane == LaneType.Dangerous) && (consecutiveDangerousLaneCount == GameManager.instance.maxConsecutiveDangerousLanes)) {
				//If the last lane was Dangerous and we can't spawn any more Dangerous lanes in a row
				//we should spawn a Safe one.
				CreateRandomLane (safeLanes, offset);
				lastSpawnedLane = LaneType.Safe;
				consecutiveDangerousLaneCount = 0;
			} else {
				//if the last lane was Safe, spawn a Dangerous one.
				CreateRandomLane (dangerousLanes, offset);
				lastSpawnedLane = LaneType.Dangerous;
				consecutiveDangerousLaneCount++;
			}

			offset += 1000;
			spawnedLanes++;
		}
		if(spawnedLanes == GameManager.instance.numberOfLanes) {
			CreateVictoryLane (offset);
			spawnedLanes++;
		}
	}

	/// <summary>
	/// Spawns the player at a predefined position at the beginning of the level.
	/// </summary>
	private void SpawnPlayer () {
        GameManager.instance.GetPlayerPosition = new Vector3 (transform.position.x, 5, transform.position.z);
	}

	/// <summary>
	/// Creates a lane that is being randomly selected from the given lanes array with a given offset in the Z axis.
	/// </summary>
	/// <param name="lanes">Array of GameObject-s - lanes to randomly choose from.</param>
	/// <param name="offset">Offset in the Z axis.</param>
	private void CreateRandomLane(GameObject[] lanes, float offset) {
		int index = Random.Range (0, lanes.Length);

		GameObject lane = Instantiate (lanes [index]);
		lane.transform.SetParent(transform, false);
		lane.transform.Translate (0, 0, offset);
	}

	/// <summary>
	/// Destroys the lanes that are behind the player at distance less than the laneSpawnDistance.
	/// </summary>
	private void DestroyPastLanes() {
		foreach (Transform line in transform) {
			if (line.transform.position.z < GameManager.instance.GetPlayerPosition.z - laneSpawnDistance) {
				Destroy (line.gameObject);
			}
		}
	}

	/// <summary>
	/// Creates the last lane of the level - the victory lane. If the player reaches it he/she wins.
	/// </summary>
	/// <param name="offset">Offset in the Z axis.</param>
	private void CreateVictoryLane(float offset) {
		GameObject[] victoryLaneArr = new GameObject[] { victoryLane };
		CreateRandomLane (victoryLaneArr, offset);
	}
}
