using UnityEngine;
using System.Collections;

public class SwordTrigger : MonoBehaviour {

	bool sent = false;
	
	public void OnTriggerEnter(Collider col){
		if (!sent) {
			if (col.transform.tag == "Player" || col.transform.tag == "PlayerShadow") {
				col.GetComponent<PlayerDie> ().Sliced (transform.parent);
				sent = true;
			}
		}
	}

	public void OnTriggerStay(Collider col){
		if (!sent) {
			if (col.transform.tag == "Player" || col.transform.tag == "PlayerShadow") {
				col.GetComponent<PlayerDie> ().Sliced (transform.parent);
				sent = true;
			}
		}
	}
}
