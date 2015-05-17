using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class GuardChase : MonoBehaviour {

	AICharacterControl aiControl;
	public bool suspicious;
	public bool aware;
	public Vector3 lastKnown;
	public float suspiciousSpeed, awareSpeed;

	// Use this for initialization
	void Start () {
		aiControl = GetComponent<AICharacterControl> ();
	}
	
	// Update is called once per frame
	public void UpdatePlayerLocation (Vector3 location) {
		lastKnown = location;
	}

	void Update(){
		aiControl.target = null;
		aiControl.targetLocation = lastKnown;
		if (suspicious) {
			aiControl.desiredSpeed = suspiciousSpeed;
		}if (aware) {
			aiControl.desiredSpeed = awareSpeed;
		}
	}
	
}
