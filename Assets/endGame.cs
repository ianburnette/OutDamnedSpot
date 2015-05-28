using UnityEngine;
using System.Collections;

public class endGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("checkpointNum", 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")){
			Application.LoadLevel(0);
		}
	}
}
