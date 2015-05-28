using UnityEngine;
using System.Collections;

public class PlayerWash : MonoBehaviour {
		
	public Transform basin, model;
	PlayerAnimation animScript;
	PlayerMovement movementScript;
	public float washTime;
	public bool dirty;
	public Texture dirtyTexture, cleanTexture;
	public Renderer myRenderer;

	// Use this for initialization
	void Start () {
		animScript = GetComponent<PlayerAnimation> ();
		movementScript = GetComponent<PlayerMovement> ();
		//myRenderer = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (basin) {
			if (Input.GetButtonDown ("Fire1") && basin.transform != null) {
				WashHands ();
			}
		}
		if (dirty && myRenderer.material.mainTexture != dirtyTexture) {
			myRenderer.material.mainTexture = dirtyTexture;
		} else if (!dirty && myRenderer.material.mainTexture != cleanTexture) {
			myRenderer.material.mainTexture = cleanTexture;
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
			print (ghost.name);
			ghost.SendMessage("Poof", SendMessageOptions.DontRequireReceiver);
			//ghost.GetComponent<ParticleHandler>().Poof ();
			Destroy (ghost);
		}
		dirty = false;
		basin.GetComponent<basinScript> ().SetUsed ();
		Invoke ("ResetMovement", 2f);

	}

	void ResetMovement(){
		movementScript.enabled = true;
		basin = null;
		dirty = false;
	}
}
