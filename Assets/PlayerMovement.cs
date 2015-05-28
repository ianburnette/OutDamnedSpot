using UnityEngine;
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

		if (hInput == 0) {

		}
		///rb.velocity = new Vector3 (hInput * right.x * forward.x, 0, vInput * forward.z * right.z) * currentSpeed * Time.deltaTime;
		Vector3 unadjustedVelocity = (hInput * transform.right * currentSpeed) + (vInput * transform.forward * currentSpeed);
//		if (hInput == 0) {
//			unadjustedVelocity.x = 0;	
//		}if (vInput == 0) {
//			unadjustedVelocity.z = 0;
//		}
		rb.velocity = new Vector3 (unadjustedVelocity.x, rb.velocity.y, unadjustedVelocity.z);
			//new Vector3 (vInput * currentSpeed * transform.right.x * transform.right.z, rb.velocity.y, hInput * currentSpeed * transform.right.z);
		//print (transform.right);
	//		(hInput * transform.right * currentSpeed) + (vInput * transform.forward * currentSpeed);
	//	rb.velocity = (vInput * transform.forward * currentSpeed);

	}

	public void Move(float h, float v){
		hInput = h;
		vInput = v;
	}
}
