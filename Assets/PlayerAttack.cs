using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public Transform attackTarget;
	PlayerAnimation animationScript;
	public float timeToStab;

	// Use this for initialization
	void Start () {
		animationScript = GetComponent<PlayerAnimation> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (attackTarget != null) {
			if (Input.GetButtonDown ("Fire1") && attackTarget.transform != null) {
				Attack (attackTarget.transform);
			}
		}
	}

	void Attack(Transform targetToAttack){
		Transform guardGettingAttacked = targetToAttack;
		guardGettingAttacked = targetToAttack;
		guardGettingAttacked.GetComponent<RagdollScript> ().Stop ();
		Invoke ("KillGuard", timeToStab);
		animationScript.Attack (guardGettingAttacked);
		attackTarget = guardGettingAttacked;
	}

	void KillGuard(){
		attackTarget.GetComponent<RagdollScript> ().Die ();
	}
}
