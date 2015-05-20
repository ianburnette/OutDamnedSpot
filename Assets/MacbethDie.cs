using UnityEngine;
using System.Collections;
using UnityStandardAssets.Cameras;

public class MacbethDie : MonoBehaviour {

	RagdollScript ragdollScr;
	GuardWander wanderScript;
	GuardAnimation animationScript;
	NavMeshAgent nav;
	public Transform camFocus;

	// Use this for initialization
	void Start () {
		ragdollScr = GetComponent<RagdollScript> ();
		wanderScript = GetComponent<GuardWander> ();
		animationScript = GetComponent<GuardAnimation> ();
		nav = GetComponent <NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Sliced(Transform slicer){
		//print ("activated");
		camFocus.parent = transform;
		camFocus.position = transform.position;
		nav.enabled = false;
		ragdollScr.enabled = true;
		ragdollScr.Die ();
		wanderScript.enabled = false;
		animationScript.enabled = false;
	}
}
