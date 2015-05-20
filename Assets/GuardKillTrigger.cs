using UnityEngine;
using System.Collections;

public class GuardKillTrigger : MonoBehaviour {

	Transform player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider col){
		if (col.transform.tag == "Player" || col.transform.tag == "PlayerShadow") {
			player = col.transform;
			col.GetComponent<PlayerTextBubble>().SetText("Space to kill");
			col.GetComponent<PlayerAttack>().attackTarget = transform.parent;//("Space to kill");
		}
	}

	void OnTriggerExit (Collider col){
		if (col.transform.tag == "Player" || col.transform.tag == "PlayerShadow") {
			player = col.transform;
			col.GetComponent<PlayerTextBubble>().SetText("");
			col.GetComponent<PlayerAttack>().attackTarget = null;//
		}
	}

	void OnDisable(){
		if (player) {
			player.GetComponent<PlayerTextBubble> ().SetText ("");
			player.GetComponent<PlayerAttack> ().attackTarget = null;//
		}
	}
}
