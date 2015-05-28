using UnityEngine;
using System.Collections;

public class ParticleHandler : MonoBehaviour {

	public GameObject smokePrefab;

	// Use this for initialization
	void OnEnable () {
		Invoke ("Poof", 1f);//	Instantiate(smokePrefab, transform.position, Quaternion.identity);
	}

	public void Poof(){
		Instantiate(smokePrefab, transform.position, Quaternion.identity);
	}

	// Update is called once per frame

}
