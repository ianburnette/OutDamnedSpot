using UnityEngine;
using System.Collections;

public class TransparencyMasker : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider col) {
		col.GetComponent<meshSwapper> ().hidden = true;
	}

	void OnTriggerStay (Collider col) {
		
		col.GetComponent<meshSwapper> ().hidden = true;
	}

	void OnTriggerExit (Collider col){
		col.GetComponent<meshSwapper> ().hidden = false;
	}
}
