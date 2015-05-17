using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

	Animator anim;
	Rigidbody rb;
	public Transform model;
	public Transform armature;
	public float height, margin, speed, attackTime;
	public float attackOffset;
	PlayerMovement movementScript;
	public Transform guardPosition;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		anim = model.GetChild (0).GetComponent<Animator> ();
		movementScript = GetComponent<PlayerMovement> ();
	}

	void FaceDirection(){
		Vector3 lookVector = new Vector3 (rb.velocity.x, height, rb.velocity.z);
		Vector3 targetVector = Vector3.Lerp (model.transform.rotation.eulerAngles, lookVector, speed);
		if (rb.velocity.magnitude > margin) {
			model.LookAt (transform.position + lookVector, Vector3.up);
		}
	}

	// Update is called once per frame
	void Update () {
		FaceDirection ();
		PlayAnimations ();
	}

	void PlayAnimations(){
		if (rb.velocity.magnitude > margin) {
			anim.SetBool ("moving", true);
		} else {
			anim.SetBool ("moving", false);
		}
	}

	public void Attack(Transform targetToAttack){
		Transform guardGettingAttacked = targetToAttack;
		ToggleMovement ();
		rb.velocity = new Vector3 (0, rb.velocity.y, 0);
		Invoke ("ToggleMovement", attackTime);
		targetToAttack.position = guardPosition.position;
	//	transform.position = guardGettingAttacked.position - guardGettingAttacked.forward/2;
		model.transform.rotation = guardGettingAttacked.GetChild(1).rotation;
		anim.SetTrigger ("attack");
	}

	public void Wash(){
		anim.SetTrigger ("wash");
	}

	public void Possess(){
		anim.SetTrigger ("possess");
	}

	public void ToggleMovement(){
		if (movementScript.enabled) {
			movementScript.enabled = false;
		} else {
			movementScript.enabled = true;
		}
	}
}
