using UnityEngine;
using System.Collections;

public class SwordScript : MonoBehaviour {

	public float swordTime;
	public Collider swordCollider;

	public AudioSource source;
	public AudioClip slice;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SliceDuncanSound(){
		source.PlayOneShot (slice);
	}

	public void ActivateSwordTrigger(){
		swordCollider.enabled = true;
		Invoke ("Deactivate", swordTime);
	}

	void Deactivate(){
		swordCollider.enabled = false;
	}
}
