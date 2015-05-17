using UnityEngine;
using System.Collections;

public class PlayerDie : MonoBehaviour {

	public float possessTime;
	PlayerAnimation animScript;
	PlayerMovement movementScript;

	// Use this for initialization
	void Start () {
		animScript = GetComponent<PlayerAnimation> ();
		movementScript = GetComponent<PlayerMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Possessed(){
		animScript.Possess ();
		movementScript.enabled = false;
		Invoke ("RestartLevel", possessTime);
	}

	void RestartLevel(){
		Application.LoadLevel (Application.loadedLevel);
		                   
	}
}
