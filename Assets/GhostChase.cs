using UnityEngine;
using System.Collections;

public class GhostChase : MonoBehaviour {

	NavMeshAgent nav;
	public Transform player;
	public float margin = 1f;

	// Use this for initialization
	void Start () {
		nav = GetComponent<NavMeshAgent> ();
		player = GameObject.Find ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		nav.destination = player.position;
		CheckProximity ();
	}

	void CheckProximity(){
		if (Vector3.Distance (player.position, transform.position) < margin) {
			KillPlayer();
			Destroy (gameObject);
		}
	}

	void KillPlayer(){
		player.GetComponent<PlayerDie> ().Possessed ();
	}
}
