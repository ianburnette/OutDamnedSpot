using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class GuardWander : MonoBehaviour {

	AICharacterControl aiControl;
	public Transform[] waypoints;
	public int waypointIndex;
	public float waitAtPointTime;
	bool waiting;

	// Use this for initialization
	void Start () {
		aiControl = GetComponent<AICharacterControl> ();
		SetNewDestination ();
	}
	
	// Update is called once per frame
	void Update () {
		if (waiting) {
			aiControl.agent.updateRotation = false;
		}
	}

	public void HitTrigger(){
		if (!waiting) {
			Invoke ("SetNewDestination", waitAtPointTime);
			waiting = true;
			aiControl.target = null;
		}
	}

	void SetNewDestination(){
		if (waypointIndex < waypoints.Length-1) {
			waypointIndex++;
		} else {
			waypointIndex = 0;
		}
		aiControl.target = waypoints [waypointIndex];
		Invoke ("StopWaiting", waitAtPointTime / 2);
	}

	void StopWaiting(){
		waiting = false;
	}
}
