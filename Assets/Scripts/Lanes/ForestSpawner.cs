using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestSpawner : MonoBehaviour {

	#region Public members

	public GameObject treePrefab;
	public int minTreeAmount = 7;
	public int maxTreeAmount = 15;

	public GameObject treasureChestPrefab;
	public float treasureSpawnPosibility = 0.2f;

	#endregion

	// Use this for initialization
	void Start () {
		for (int i = 0; i < Random.Range (minTreeAmount, maxTreeAmount); i++) {
			SpawnTreeRandomly ();
		}
		if(Random.value <= treasureSpawnPosibility) {
			SpawnTreasureChestRandomly ();
		}
	}

	/// <summary>
	/// Used to spawn the tree prefab at a random spot on the lane.
	/// </summary>
	private void SpawnTreeRandomly() {
		GameObject tree = Instantiate (treePrefab);
		tree.transform.parent = transform;
		tree.transform.localPosition = new Vector3 (
			Random.Range(-50f, 50f),
			0,
			Random.Range(-4f, 4f)
		);
	}

	/// <summary>
	/// Used to spawn the treasure chest prefab at a random spot on the lane.
	/// </summary>
	private void SpawnTreasureChestRandomly() {
		GameObject chest = Instantiate (treasureChestPrefab);
		chest.transform.parent = transform;
		chest.transform.localPosition = new Vector3 (
			Random.Range(-10f, 10f),
			0.5f,
			Random.Range(-4f, 4f)
		);
	}
}
