using UnityEngine;
using System.Collections;

public class PlayerDie : MonoBehaviour {

	public float possessTime, slicedTime;
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

	public void Sliced(Transform slicer){
		transform.LookAt(new Vector3 (slicer.position.x, 100f, slicer.position.z));
		animScript.GetSliced ();
		Invoke ("RestartLevel", slicedTime);

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
