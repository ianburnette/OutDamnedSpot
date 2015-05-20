using UnityEngine;
using System.Collections;

public class MaintainIsometry : MonoBehaviour {

	public Transform parent; 

	// Use this for initialization
	void Start () {
		parent = transform.parent;
		transform.parent = null;

	}
	
	// Update is called once per frame
	void Update () {
		transform.position = parent.position + Vector3.up * 2;//.Euler (new Vector3 (transform.rotation.eulerAngles.x, targetY, transform.rotation.eulerAngles.z));
	}
}
