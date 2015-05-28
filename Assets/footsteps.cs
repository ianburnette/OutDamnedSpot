using UnityEngine;
using System.Collections;

public class footsteps : MonoBehaviour {

	public AudioSource source;
	public AudioClip step, slash, wash, fall;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	public void Step () {
		source.PlayOneShot (step);
	}

	public void Slash(){
		source.PlayOneShot (slash);
		Invoke ("Fall", 1f);
	}

	public void Wash(){
		source.PlayOneShot (wash);
	}

	public void Fall(){
		source.PlayOneShot (fall);
	}
}
