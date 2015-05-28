using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public Transform attackTarget;
	PlayerAnimation animationScript;
	public float timeToStab;
	PlayerWash washScript;
	bool canAttack = true;

	// Use this for initialization
	void Start () {
		animationScript = GetComponent<PlayerAnimation> ();
		washScript = GetComponent<PlayerWash> ();
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
		//Invoke ("KillGuard", timeToStab);
		StartCoroutine ("KillGuard", targetToAttack);
		canAttack = false;
		attackTarget = targetToAttack;
		Transform guardGettingAttacked = targetToAttack;
		guardGettingAttacked = targetToAttack;
		guardGettingAttacked.GetComponent<RagdollScript> ().Stop ();

		animationScript.Attack (guardGettingAttacked);

		Invoke ("GetDirty", 1f);
	}

	IEnumerator KillGuard(Transform guardToKill){
		yield return new WaitForSeconds (1f);
		print (guardToKill);
		guardToKill.GetComponent<RagdollScript> ().Die ();
		canAttack = true;
	}
//	void KillGuard(){
//		attackTarget.GetComponent<RagdollScript> ().Die ();
//	}

	void GetDirty(){
		washScript.dirty = true;
	}
}
