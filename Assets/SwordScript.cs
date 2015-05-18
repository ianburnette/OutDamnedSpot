using UnityEngine;
using System.Collections;

public class SwordScript : MonoBehaviour {

	public Collider swordCollider;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ActivateSwordTrigger(){
		swordCollider.enabled = true;
		Invoke ("Deactivate", 1f);
	}

	void Deactivate(){
		swordCollider.enabled = false;
	}
}
