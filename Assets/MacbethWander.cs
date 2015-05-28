using UnityEngine;
using System.Collections;

public class MacbethWander : MonoBehaviour {

	NavMeshAgent nav;
	
	GuardAnimation animScript;
	public Transform[] waypoints;
	public int waypointIndex;
	public float waitAtPointTime, distFromPoint;
	public bool waiting;
	public float walkSpeed;
	
	// Use this for initialization
	void Start () {
		nav = GetComponent<NavMeshAgent> ();
		animScript = GetComponent<GuardAnimation> ();
		SetFirstDest ();
	}
	
	void OnEnable(){
//		nav = GetComponent<NavMeshAgent> ();
//		animScript = GetComponent<GuardAnimation> ();
//		nav.speed = 1f;
//		SetFirstDest ();
	}
	
	// Update is called once per frame
	void Update () {
		CheckForProximity ();
		if (waiting) {
			//aiControl.agent.updateRotation = false;
		}
	}

	void CheckForProximity(){
		if (Vector3.Distance (transform.position, nav.destination) < distFromPoint && nav.speed != 0) {
			Invoke ("SetNewDestination", waitAtPointTime);
			nav.speed = 0;
			animScript.StopWalking();
		}
	}


	void SetFirstDest(){
		nav.destination = waypoints [waypointIndex].position;
		animScript.StartWalking ();
	}

	void SetNewDestination(){
		if (waypointIndex < waypoints.Length) {
			waypointIndex++;
		} else {
			return;
		}
		nav.destination = waypoints [waypointIndex].position;
		nav.speed = walkSpeed;
		animScript.StartWalking ();
		//Invoke ("StopWaiting", waitAtPointTime / 2);
	}

	public void FinalDestination(Transform dest){
		nav.destination = dest.position;
		animScript.StartWalking ();
	}
	
	void StopWaiting(){
		waiting = false;
	}
}
