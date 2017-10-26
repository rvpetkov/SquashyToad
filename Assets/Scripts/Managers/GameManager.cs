using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	[HideInInspector] public static GameManager instance = null;

    public int maxConsecutiveDangerousLanes = 1;
    public int numberOfLanes = 5;
    public GameObject player;

    public Vector3 GetPlayerPosition
    {

        get
        {
            if (player == null)
            {
                player = FindObjectOfType<PlayerMovement>().gameObject;
            }
            return player.transform.position;
        }

        set
        {
            if (player == null)
            {
                player = FindObjectOfType<PlayerMovement>().gameObject;
            }
            player.transform.position = value;
        }
    }

    void Awake () {
		if (instance == null) {		//Check if instance already exists
			instance = this;
		} else if (instance != this) {	//If instance already exists and it's not this:
			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);
		}


        if (player == null)
        {
            player = FindObjectOfType<PlayerMovement>().gameObject;
        }

        //Don't destroy this when reloading/changing scenes.
        DontDestroyOnLoad (gameObject);
	}
}
