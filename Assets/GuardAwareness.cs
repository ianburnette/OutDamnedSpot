using UnityEngine;
using System.Collections;

public class GuardAwareness : MonoBehaviour {

	GuardInvestigate investigateScript;
	GuardWander wanderScript;


	// Use this for initialization
	void Start () {
		investigateScript = GetComponent<GuardInvestigate> ();
		wanderScript = GetComponent<GuardWander> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ResumeWandering(){
		investigateScript.enabled = false;
		wanderScript.enabled = true;
	}
}
