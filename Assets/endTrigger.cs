using UnityEngine;
using System.Collections;

public class endTrigger : MonoBehaviour {

	public Transform player, macbeth, playerCanvas;
	public GameObject[] texts;
	public GameController gc;
	bool playerHere;
	bool macbethHere;

	// Use this for initialization
	void OnEnable () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (player.position, macbeth.position) < 2f) {
			macbethHere = true;
		}
		if (macbethHere && playerHere) {
			foreach (GameObject text in texts){
				text.SetActive(true);
			}
			gc.BeatGame();
		}
	}

	void OnTriggerEnter (Collider col){
		if (col.transform.tag == "Player" || col.transform.tag == "PlayerShadow") {
			//player = col.transform;
			macbeth.GetComponent<NavMeshAgent> ().speed = 1f;
			col.transform.root.GetComponent<PlayerMovement>().enabled = false;
			col.transform.root.GetComponent<PlayerTextBubble>().enabled = false;
			//col.transform.root.GetChild (2).gameObject.SetActive(false);
			playerCanvas.gameObject.SetActive(false);
			playerHere = true;
			
		}
	}
}
