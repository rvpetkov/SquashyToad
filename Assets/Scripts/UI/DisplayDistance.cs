using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayDistance : MonoBehaviour {

	#region Private members

	private Text distanceText;
	private ScoreManager scoreManager;

	#endregion

	// Use this for initialization
	void Start () {
		distanceText = GetComponent<Text> ();
		scoreManager = FindObjectOfType<ScoreManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		distanceText.text = "Distance: " + scoreManager.DistanceScore + 'm';
	}
}
