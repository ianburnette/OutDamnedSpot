using UnityEngine;
using System.Collections;

public class PlayerWash : MonoBehaviour {
		
	public Transform basin, model;
	PlayerAnimation animScript;
	PlayerMovement movementScript;
	public float washTime;

	// Use this for initialization
	void Start () {
		animScript = GetComponent<PlayerAnimation> ();
		movementScript = GetComponent<PlayerMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (basin) {
			if (Input.GetButtonDown ("Fire1") && basin.transform != null) {
				WashHands ();
			}
		}
	}

	public void WashHands(){
		movementScript.enabled = false;
		model.LookAt (new Vector3(basin.position.x, 100f, basin.position.z));
		animScript.Wash ();
		Invoke ("KillGhosts", washTime);
	}

	void KillGhosts(){
		GameObject[] ghosts = GameObject.FindGameObjectsWithTag ("ghost");
		foreach (GameObject ghost in ghosts) {
			Destroy (ghost);
		}
		basin.GetComponent<basinScript> ().SetUsed ();
		movementScript.enabled = true;
		basin = null;
	}
}
