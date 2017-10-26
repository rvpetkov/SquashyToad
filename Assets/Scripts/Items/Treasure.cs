using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour {

	#region Public members

	public GameObject treasureItem;

	#endregion

	#region Private members

	private float fraction = 0f;
	private GameObject treasure;
    private GvrAudioSource treasureAudioSource;
    private bool isRevealed = false;

    #endregion
    
    // Update is called once per frame
    void Update () {
		if (isRevealed && fraction <= 1) {
			fraction += Time.deltaTime / 2f;
			treasure.transform.position = Vector3.Lerp (transform.position, transform.position + Vector3.up * 75, fraction);
		} else if (treasure != null) {
            Destroy(treasure);
		}
	}

	public void RevealTreasure() {
		treasure = Instantiate (treasureItem);
        treasureAudioSource = treasure.GetComponent<GvrAudioSource>();
        treasure.transform.parent = transform;
		treasure.transform.rotation = Quaternion.Euler (transform.rotation.x - 90, transform.rotation.y + 90, transform.rotation.z);

		isRevealed = true;
	}
}
