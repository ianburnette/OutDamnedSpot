using UnityEngine;
using System.Collections;

public class RestartIfBelow : MonoBehaviour {

	public Transform player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (player.position.y < -15) {
			GetComponent<GameController>().EndLevel(0);
		}
	}
}
