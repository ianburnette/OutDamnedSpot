using UnityEngine;
using System.Collections;

public class GuardInvestigate : MonoBehaviour {

	NavMeshAgent nav;
	GuardAwareness awarenessScript;
	GuardAnimation animScript;
	public float waitAtPointTime;
	bool waiting;
	public Vector3 destination;
	public float margin;
	
	// Use this for initialization
	void Start () {
		nav = GetComponent<NavMeshAgent> ();
		animScript = GetComponent<GuardAnimation> ();
		awarenessScript = GetComponent<GuardAwareness> ();
		SetNewDestination ();
	}

	void SetNewDestination(){

	}

	// Update is called once per frame
	void Update () {
		if (destination != Vector3.zero) {
			nav.destination = destination;
		}
		if (Vector3.Distance (transform.position, destination) < margin) {
			Wait();
		}
	}

	void Wait(){
		waiting = true;
		nav.speed = 0;
		animScript.StopWalking ();
		Invoke ("ResumeWander", waitAtPointTime);
	}

	void ResumeWander(){
		awarenessScript.ResumeWandering ();
	}
}
