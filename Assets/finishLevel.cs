using UnityEngine;
using System.Collections;

public class finishLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider col) {
		if (col.transform.tag == "Player" || col.transform.tag == "PlayerShadow") {
			PlayerPrefs.SetInt("checkpointNum", 0);
			Application.LoadLevel(Application.loadedLevel+1);
		}
	}
}
