using UnityEngine;
using System.Collections;

public class WaypointTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider col) {
		col.GetComponent<GuardWander> ().HitTrigger ();
	}
}
