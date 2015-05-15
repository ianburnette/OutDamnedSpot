using UnityEngine;
using System.Collections;

public class MaintainIsometry : MonoBehaviour {

	public float targetY; 

	// Use this for initialization
	void Start () {
		targetY = 0;
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler (new Vector3 (transform.rotation.eulerAngles.x, targetY, transform.rotation.eulerAngles.z));
	}
}
