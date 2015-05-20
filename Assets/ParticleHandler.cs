using UnityEngine;
using System.Collections;

public class ParticleHandler : MonoBehaviour {

	public GameObject smokePrefab;

	// Use this for initialization
	void OnEnable () {
		Instantiate(smokePrefab, transform.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void OnDisable () {
		Instantiate(smokePrefab, transform.position, Quaternion.identity);
	}
}
