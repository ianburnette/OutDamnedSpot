using UnityEngine;
using System.Collections;

public class MacbethFollow : MonoBehaviour {

	NavMeshAgent nav;
	public Transform player;
	GuardAnimation animationScript;
	bool moving;

	// Use this for initialization
	void Start () {
		nav = GetComponent<NavMeshAgent> ();
		animationScript = GetComponent<GuardAnimation> ();
		nav.destination = player.position;
		animationScript.StartWalking ();
	}
	
	// Update is called once per frame
	void Update () {
		if (nav.enabled) {
			nav.destination = player.position;
		}
		if (nav.velocity.magnitude < .1f && moving) {
			animationScript.StopWalking ();
			moving = false;
		} else if (nav.velocity.magnitude > .1f && !moving) {
			animationScript.StartWalking ();
			moving = true;
		} else if (nav.speed == 0) {
			animationScript.StopWalking ();
			moving = false;
		}

	}
}
