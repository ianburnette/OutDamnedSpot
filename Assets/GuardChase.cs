﻿using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class GuardChase : MonoBehaviour {

	public Animator anim;
	public float chaseSpeed, attackDistance, attackCooldown, attackStoppingDist;
	public Transform target;
	public bool readyToAttack = true;
	NavMeshAgent nav;

	void Start(){
		nav = GetComponent<NavMeshAgent> ();
		//anim = GetComponent<Animator> ();
	}

	void Update(){
		if (target) {
			nav.destination = target.position;
			nav.stoppingDistance = attackStoppingDist;
			nav.speed = chaseSpeed;
			if (readyToAttack && Vector3.Distance (transform.position, target.position) < attackDistance){
				Attack();
				readyToAttack = false;
			}
			//print (Vector3.Distance(transform.position, target.position));
		}
	}

	void Attack(){
		anim.SetTrigger ("swing");
		Invoke ("ReadyAttack", attackCooldown);
	}

	void ReadyAttack(){
		readyToAttack = true;
	}
}
