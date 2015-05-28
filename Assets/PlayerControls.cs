using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

	public float h, v;
	PlayerMovement movementScript;

	// Use this for initialization
	void Start () {
		movementScript = GetComponent<PlayerMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
		h = Input.GetAxis ("Horizontal");
		v = Input.GetAxis ("Vertical");
		movementScript.Move(h,v);
		if (h != 0 || v != 0) {
			//movementScript.Move(h,v);
		}
	}
}
