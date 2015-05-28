using UnityEngine;
using System.Collections;

public class GhostChase : MonoBehaviour {

	NavMeshAgent nav;
	public Transform player, body1, body2, sword;
	public float margin = 1f;
	public float speed = 1f;
	public float timeToGhost = 3f;
	bool ready = false;

	// Use this for initialization
	void Start () {
		nav = GetComponent<NavMeshAgent> ();
		body1 = transform.GetChild (0);
		body2 = transform.GetChild (1);
		//sword = transform.FindChild ("sword");
		player = GameObject.Find ("Player").transform;
		body1.gameObject.SetActive (false);
		body2.gameObject.SetActive (false);
		//sword.gameObject.SetActive (false);
		nav.speed = 0;
		Invoke ("Chase", timeToGhost);
	}

	void Chase(){
		nav.speed = speed;
		body1.gameObject.SetActive (true);
		body2.gameObject.SetActive (true);
	//	sword.gameObject.SetActive (true);
		ready = true;
	}

	// Update is called once per frame
	void Update () {
		nav.destination = player.position;
		if (ready) {
			CheckProximity ();
		}
	}

	void CheckProximity(){
		if (Vector3.Distance (player.position, transform.position) < margin) {
			KillPlayer();
			GetComponent<ParticleHandler>().Poof ();
			Destroy (gameObject);
		}
	}

	void KillPlayer(){
		player.GetComponent<PlayerDie> ().Possessed ();
	}
}
