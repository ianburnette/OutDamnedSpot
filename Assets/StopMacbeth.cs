using UnityEngine;
using System.Collections;

public class StopMacbeth : MonoBehaviour {

	public Transform macbeth;
	public MacbethStopTrigger stopScript;
	public bool canStop;

	// Use this for initialization
	void Start () {
		//stopScript = macbeth.GetComponent<MacbethStopTrigger> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1") && canStop) {
			stopScript.Toggle();
		}
	}
}
