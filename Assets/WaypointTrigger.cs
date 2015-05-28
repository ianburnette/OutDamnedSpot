using UnityEngine;
using System.Collections;

public class WaypointTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider col) {
		//print ("hit");
		if (col.transform.tag == "macbeth") {
			//	col.transform.parent.GetComponent<MacbethWander> ().HitTrigger ();
		} else if (col.transform.parent != null) {
			if (col.transform.parent.tag == "guard"){
			col.transform.parent.SendMessage("HitTrigger", SendMessageOptions.DontRequireReceiver);//.GetComponent<GuardWander> ().HitTrigger ();
			}
		}
	}
}
