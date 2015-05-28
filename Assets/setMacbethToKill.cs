using UnityEngine;
using System.Collections;

public class setMacbethToKill : MonoBehaviour {

	bool sent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if (col.transform.tag == "macbeth" && !sent){
			col.transform.root.GetComponent<killDuncan>().StartKilling();
			sent = true;
		}
		if (col.transform.tag == "Player" || col.transform.tag == "PlayerShadow") {
			ActivateEndZone();
		}
	}

	void ActivateEndZone(){
		transform.GetChild (0).gameObject.SetActive (true);
	}
}
