using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Transform joystick, aButton, mouseButton, wkey, akey, skey, dkey;
	bool joystickB, aButtonB, mouseButtonB, wkeyB, akeyB, skeyb, dkeyB;
	public int progress;
	public float mult;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("HorizontalB") != 0 && !joystickB) {
			progress+=4;
			joystickB = true;
			joystick.GetComponent<Rigidbody>().isKinematic = false;
			joystick.GetComponent<Rigidbody>().AddTorque(new Vector3 (1,1,1) * mult);
		}
		if (Input.GetMouseButtonDown (0) && !mouseButtonB) {
			progress++;
			mouseButtonB = true;
			mouseButton.GetComponent<Rigidbody>().isKinematic = false;
			mouseButton.GetComponent<Rigidbody>().AddTorque(new Vector3 (1,1,1) * mult);
		}
		if (Input.GetButtonDown ("Fire1Alt") && !aButtonB) {
			progress++;
			aButtonB = true;
			aButton.GetComponent<Rigidbody>().isKinematic = false;
			aButton.GetComponent<Rigidbody>().AddTorque(new Vector3 (1,1,1) * mult);
		}
		if (Input.GetKeyDown (KeyCode.W) && !wkeyB) {
			progress++;
			wkeyB = true;
			wkey.GetComponent<Rigidbody>().isKinematic = false;
			wkey.GetComponent<Rigidbody>().AddTorque(new Vector3 (1,1,1) * mult);
		}if (Input.GetKeyDown (KeyCode.A) && !akeyB) {
			progress++;
			akeyB = true;
			akey.GetComponent<Rigidbody>().isKinematic = false;
			akey.GetComponent<Rigidbody>().AddTorque(new Vector3 (1,1,1) * mult);
		}if (Input.GetKeyDown (KeyCode.S) && !skeyb) {
			progress++;
			skeyb = true;
			skey.GetComponent<Rigidbody>().isKinematic = false;
			skey.GetComponent<Rigidbody>().AddTorque(new Vector3 (1,1,1) * mult);
		}if (Input.GetKeyDown (KeyCode.D) && !dkeyB) {
			progress++;
			dkeyB = true;
			dkey.GetComponent<Rigidbody>().isKinematic = false;
			dkey.GetComponent<Rigidbody>().AddTorque(new Vector3 (1,1,1) * mult);
		}
		if (progress == 5) {
			Invoke ("StartGame", 1f);
		}
	}

	void StartGame(){
		Application.LoadLevel (1);
	}
}
