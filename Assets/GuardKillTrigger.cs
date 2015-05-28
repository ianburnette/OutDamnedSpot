using UnityEngine;
using System.Collections;

public class GuardKillTrigger : MonoBehaviour {

	Transform player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider col){
		if (col.transform.tag == "Player" || col.transform.tag == "PlayerShadow") {
//			print (col);
		//	player = col.transform;
			col.transform.root.GetComponent<PlayerTextBubble>().SetText("Kill");
			col.transform.root.GetComponent<PlayerAttack>().attackTarget = transform.parent;//("Space to kill");
		}
	}

	void OnTriggerExit (Collider col){
		if (col.transform.tag == "Player" || col.transform.tag == "PlayerShadow") {
		//	player = col.transform;
			col.transform.root.GetComponent<PlayerTextBubble>().SetText("");
			col.transform.root.GetComponent<PlayerAttack>().attackTarget = null;//
		}
	}

	void OnDisable(){
		if (player) {
			player.GetComponent<PlayerTextBubble> ().SetText ("");
			player.GetComponent<PlayerAttack> ().attackTarget = null;//
		}
	}
}
