using UnityEngine;
using System.Collections;

public class activateMacbeth : MonoBehaviour {

	public MacbethFollow wanderScript;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider col) {
		if (col.transform.tag == "Player" || col.transform.tag == "PlayerShadow") {
			wanderScript.enabled = true;
		}
	}
}
