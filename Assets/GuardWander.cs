using UnityEngine;
using System.Collections;

public class GuardWander : MonoBehaviour {

	NavMeshAgent nav;

	GuardAnimation animScript;
	public Transform[] waypoints;
	public int waypointIndex;
	public float waitAtPointTime;
	bool waiting;

	// Use this for initialization
	void Start () {
		nav = GetComponent<NavMeshAgent> ();
		animScript = GetComponent<GuardAnimation> ();
		SetNewDestination ();
	}

	void OnEnable(){
		nav = GetComponent<NavMeshAgent> ();
		animScript = GetComponent<GuardAnimation> ();
		nav.speed = 1f;
	}

	// Update is called once per frame
	void Update () {

		if (waiting) {
			//aiControl.agent.updateRotation = false;
		}
	}

	public void HitTrigger(){
		if (!waiting) {
			Invoke ("SetNewDestination", waitAtPointTime);
			waiting = true;
			nav.destination = transform.position;
			animScript.StopWalking();
		}
	}

	void SetNewDestination(){
		if (waypointIndex < waypoints.Length-1) {
			waypointIndex++;
		} else {
			waypointIndex = 0;
		}
		nav.destination = waypoints [waypointIndex].position;
		animScript.StartWalking ();
		Invoke ("StopWaiting", waitAtPointTime / 2);
	}

	void StopWaiting(){
		waiting = false;
	}
}
