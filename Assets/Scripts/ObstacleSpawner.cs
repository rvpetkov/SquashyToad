using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is used to spawn random obsticles on random intervals.
/// </summary>
public class ObstacleSpawner : MonoBehaviour {

	#region Public members

	public GameObject[] obsticlePrefabs;
	public float meanTime = 3f;

	#endregion

	#region Private members

	private float spawnInterval;
	private float minTime = 2f;

	#endregion

	// Use this for initialization
	void Start () {
		spawnInterval = Random.Range (0f, 1.5f);	//set spawn time for the first obsticle
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > spawnInterval) {
			SpawnObstacle ();
			spawnInterval = Time.time + minTime - Mathf.Log (Random.value) * meanTime;
		}
	}

	private void SpawnObstacle() {
		int index = 0;

		if(obsticlePrefabs.Length > 1) {
			index = Random.Range (0, obsticlePrefabs.Length);
		}

		Instantiate (obsticlePrefabs [index], transform.position, transform.rotation, transform);
	}
}
