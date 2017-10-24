using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTime : MonoBehaviour {

	#region Private members

	private Text timeText;
	private ScoreManager scoreManager;

	#endregion

	// Use this for initialization
	void Start () {
		timeText = GetComponent<Text> ();
		scoreManager = FindObjectOfType<ScoreManager> ();
	}

	// Update is called once per frame
	void Update () {
		timeText.text = "Time: " + scoreManager.TimeScore;
	}
}
