﻿using UnityEngine;
using System.Collections;

public class PlayerDie : MonoBehaviour {

	public float possessTime, slicedTime;
	PlayerAnimation animScript;
	PlayerMovement movementScript;
	public Transform playerCanvas;
	public GameController gc;

	// Use this for initialization
	void Start () {
		animScript = GetComponent<PlayerAnimation> ();
		movementScript = GetComponent<PlayerMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Sliced(Transform slicer){
	//	transform.LookAt(new Vector3 (slicer.position.x, 0, slicer.position.z));
		slicer.GetComponent<GuardAwareness> ().HideMark ();
		playerCanvas.gameObject.SetActive (false);
		animScript.GetSliced ();
	//	Invoke ("RestartLevel", slicedTime);
		movementScript.enabled = false;
		gc.EndLevel (0);
	}

	public void Possessed(){
		animScript.Possess ();
		movementScript.enabled = false;
		gc.EndLevel (0);
	//	Invoke ("RestartLevel", possessTime);
	}

	void RestartLevel(){
		//Application.LoadLevel (Application.loadedLevel);
		                   
	}
}
