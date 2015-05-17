using UnityEngine;
using System.Collections;

public class GuardAnimation : MonoBehaviour {

	public Animator anim;

	public void StopWalking(){
		anim.SetBool ("moving", false);
	}

	public void StartWalking(){
		anim.SetBool ("moving", true);
	}

	public void StopToDie(){
		anim.SetBool ("moving", false);
	}

	public void DisableSelf(){
		anim.enabled = false;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
