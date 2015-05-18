using UnityEngine;
using System.Collections;

public class DropDagger : MonoBehaviour {

	public Transform dagger;

	public void Drop () {
		dagger.parent = null;
		dagger.GetComponent<BoxCollider> ().isTrigger = false;
		dagger.GetComponent<Rigidbody> ().isKinematic = false;
	}
}
