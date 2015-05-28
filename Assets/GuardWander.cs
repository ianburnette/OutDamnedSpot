using UnityEngine;
using System.Collections;

public class GuardWander : MonoBehaviour {

	NavMeshAgent nav;

	GuardAnimation animScript;
	public Transform[] waypoints;
	public int waypointIndex;
	public float waitAtPointTime, distFromPoint, walkSpeed;
	bool waiting;

	// Use this for initialization
	void Start () {
		nav = GetComponent<NavMeshAgent> ();
		walkSpeed = nav.speed;
		animScript = GetComponent<GuardAnimation> ();
		//SetFirstDestination ();
	}

	void OnEnable(){
		nav = GetComponent<NavMeshAgent> ();
		animScript = GetComponent<GuardAnimation> ();
		nav.speed = 1f;
		//SetNewDestination ();
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

	public void HitTrigger(){
//		if (!waiting) {
//			Invoke ("SetNewDestination", waitAtPointTime);
//			waiting = true;
//			nav.destination = transform.position;
//			animScript.StopWalking();
//		}
	}

	void SetFirstDestination(){
		nav.destination = waypoints [waypointIndex].position;
		animScript.StartWalking ();
	}



	void SetNewDestination(){
		if (waypoints.Length == 1) {
			//waypoints[0] = transform.position;
		} else {
			if (waypointIndex < waypoints.Length-1) {
				waypointIndex++;
			} else {
				waypointIndex = 0;
			}
			nav.destination = waypoints [waypointIndex].position;
			nav.speed = walkSpeed;
			animScript.StartWalking ();
			Invoke ("StopWaiting", waitAtPointTime / 2);
		}

	}

	void StopWaiting(){
		waiting = false;
	}
}
