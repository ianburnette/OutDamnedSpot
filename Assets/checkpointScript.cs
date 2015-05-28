using UnityEngine;
using System.Collections;

public class checkpointScript : MonoBehaviour {

	public Transform gm;
	public Transform[] previousCheckpoints;
	public Transform[] guards;
	public int checkpointNum;
	public Transform player, macbeth;
	public Transform playerPos, macbethPos;
	public int nextMacIndex;
	public bool setMacbeth;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider col){
		if (col.transform.tag == "Player" || col.transform.tag == "PlayerShadow") {
			bool newCheckpoint = gm.GetComponent<checkpointManager>().PassedCheckpoint(checkpointNum);
			if (newCheckpoint){
				//DisableMyGuards();
				//DisablePreviousCheckpoints();
			}
		}
	}

	public void LoadThisCheckpoint(){
		DisableMyGuards ();
		DisablePreviousCheckpoints ();
		SetPositions ();
	}

	public void SetPositions(){
		player.position = playerPos.position;
		if (setMacbeth) {
			macbeth.GetComponent<NavMeshAgent>().enabled = false;
			macbeth.position = macbethPos.position;
			Invoke ("ResetNav", 1f);
//			macbeth.GetComponent<MacbethWander> ().enabled = true;
//			macbeth.GetComponent<MacbethWander> ().waypointIndex = nextMacIndex;
		}
	}

	void ResetNav(){
		macbeth.GetComponent<NavMeshAgent> ().enabled = true;
	}

	public void DisableMyGuards(){

		foreach (Transform guard in guards) {
			guard.GetComponent<RagdollScript>().JustRagdoll();
		}
	}

	public void DisablePreviousCheckpoints(){
		foreach (Transform checkpoint in previousCheckpoints) {
			DisableMyGuards();
			checkpoint.GetComponent <checkpointScript>().DisablePreviousCheckpoints();

		}
	}
}
