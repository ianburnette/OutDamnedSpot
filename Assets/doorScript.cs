using UnityEngine;
using System.Collections;

public class doorScript : MonoBehaviour {

	public Transform player, macbeth, finalDest;
	public float minDistance = 2f;
	Animator anim;


	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator> ();
		player = GameObject.Find ("Player").transform;
		macbeth = GameObject.Find ("Macbeth").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (transform.position, player.position) < minDistance && Vector3.Distance (transform.position, macbeth.position) < minDistance) {
			print ("here");
			anim.SetTrigger("open");
			//macbeth.GetComponent<MacbethWander>().FinalDestination(finalDest);
		}
	}

	public void FreezeDoor(){
		anim.StopPlayback ();
	}
}
