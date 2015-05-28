using UnityEngine;
using System.Collections;

public class MacbethStopTrigger : MonoBehaviour {

	public NavMeshAgent nav;
	public Transform player;
	public GuardAnimation animScript;
	float walkSpeed;

	void Start(){
		if (animScript == null) {
			animScript = transform.parent.GetComponent<GuardAnimation> ();
		}
		walkSpeed = nav.speed;
	}

//	void OnTriggerEnter (Collider col) {
//		//print (col + " entered");
//		if (col.transform.tag == "Player" || col.transform.tag == "PlayerShadow") {
//			nav.speed = 0;
//			//nav.enabled = false;
//			animScript.StopWalking();
//		}
//	}
//
//	void OnTriggerExit (Collider col){
//		if (col.transform.tag == "Player" || col.transform.tag == "PlayerShadow") {
//			nav.speed = walkSpeed;
//			animScript.StartWalking();
//		}
//	}

	public void Toggle(){
		if (nav.speed == 0)
			StartWalking ();
		else
			StopWalking ();
	}

	void StopWalking(){
		nav.speed = 0;
		animScript.StopWalking();
		player.GetComponent<PlayerTextBubble>().SetText("Resume Walking");
	}

	void StartWalking(){
		nav.speed = walkSpeed;
		//animScript.StartWalking();
		player.GetComponent<PlayerTextBubble>().SetText("Stop Walking");
	}

	void OnTriggerEnter (Collider col){
		if (col.transform.tag == "Player" || col.transform.tag == "PlayerShadow") {
			if (nav.speed == 0){
				col.transform.root.GetComponent<PlayerTextBubble>().SetText("Resume Walking");
			}else {
				col.transform.root.GetComponent<PlayerTextBubble>().SetText("Stop Walking");
			}
			col.transform.root.GetComponent<StopMacbeth>().canStop = true;// = transform;//("Space to kill");
		}
	}
	
	void OnTriggerExit (Collider col){
		if (col.transform.tag == "Player" || col.transform.tag == "PlayerShadow") {
			//player = col.transform;
			col.transform.root.GetComponent<PlayerTextBubble>().SetText("");
			col.transform.root.GetComponent<StopMacbeth>().canStop = false;//("Space to kill");
		}
	}

}
