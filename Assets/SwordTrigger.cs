using UnityEngine;
using System.Collections;

public class SwordTrigger : MonoBehaviour {

	bool sent = false;
	public Transform target;
	
	public void OnTriggerEnter(Collider col){
	//	print (col.transform);
		if (!sent) {
			if (col.transform.tag == "Player" || col.transform.tag == "PlayerShadow") {
				col.GetComponent<PlayerDie> ().Sliced (transform.parent);
				sent = true;
			}
			if (col.transform.tag == "macbeth"){
				col.transform.root.GetComponent<MacbethDie>().Sliced(transform.parent);
			}
			target = col.transform;
		}
	}

	public void OnTriggerStay(Collider col){
	//	print (col.transform);
		if (!sent) {
			if (col.transform.tag == "Player" || col.transform.tag == "PlayerShadow") {
				col.GetComponent<PlayerDie> ().Sliced (transform.parent);
				sent = true;
			}
			if (col.transform.tag == "macbeth"){
				col.transform.root.GetComponent<MacbethDie>().Sliced(transform.parent);
			}
			target = col.transform;
		}
	}
}
