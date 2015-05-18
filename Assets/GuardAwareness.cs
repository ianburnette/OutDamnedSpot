using UnityEngine;
using System.Collections;

public class GuardAwareness : MonoBehaviour {

	public Vector3 eyeHeight, cubeSize,cube2Size;
	public float eyeAngle, sightDistance, aspect;
	GuardInvestigate investigateScript;
	GuardWander wanderScript;
	public int behavior;

	// Use this for initialization
	void Start () {
		investigateScript = GetComponent<GuardInvestigate> ();
		wanderScript = GetComponent<GuardWander> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ResumeWandering(){
		investigateScript.enabled = false;
		wanderScript.enabled = true;
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.blue;
		Gizmos.DrawCube (transform.position + (transform.forward * (sightDistance / 2)), cube2Size);
		Gizmos.color = Color.red;
		//Gizmos.DrawFrustum (transform.position + eyeHeight, eyeAngle, sightDistance, 0f, aspect);
		Gizmos.DrawCube (transform.position + (transform.forward * (sightDistance / 2)), cubeSize);

	}
}
