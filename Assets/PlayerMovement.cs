﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	float hInput, vInput;
	Rigidbody rb;
	public float walkSpeed, runSpeed;
	public bool run;
	float currentSpeed;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (run)
			currentSpeed = runSpeed;
		else
			currentSpeed = walkSpeed;

		///rb.velocity = new Vector3 (hInput * right.x * forward.x, 0, vInput * forward.z * right.z) * currentSpeed * Time.deltaTime;
		rb.velocity = (hInput * transform.right * currentSpeed) + (vInput * transform.forward * currentSpeed);
	//	rb.velocity = (vInput * transform.forward * currentSpeed);

	}

	public void Move(float h, float v){
		hInput = h;
		vInput = v;
	}
}
