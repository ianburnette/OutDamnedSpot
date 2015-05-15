using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GuardDetection : MonoBehaviour {

	public Vector3 eyePosition;
	public Transform player;
	public float sightDistance;
	public LayerMask rayMask;
	Vector3 rayHitPosition;
	GuardWander wanderScript;
	bool inSightCone, inPeripheral;
	public Text enemyTextBubble;
	Vector3 relativePoint;
	public float nearSightDist, farSightDist;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		DrawSightRay ();
		CastDetectionRay ();
		DetectPlayerPosition ();
		DrawText ();
	}

	void DetectPlayerPosition(){
		relativePoint = transform.InverseTransformPoint (player.position);
		string relativeString;
		if (relativePoint.x > 0) 
			relativeString = "right";
		else 
			relativeString = "left";

		if (relativePoint.z > 0) { //player in front of enemy
			if (relativePoint.z >= Mathf.Abs (relativePoint.x)) { //inside cone
				inSightCone = true;
			} else {
				inSightCone = false;
			}
		} else {
			inSightCone = false;
		}




		//print ("player is to the " + relativePoint);
	}

	void DrawText(){
		if (inSightCone && relativePoint.z < nearSightDist) {
			enemyTextBubble.text = "!";
		} else if (inSightCone && relativePoint.z < farSightDist) {
			enemyTextBubble.text = "?";
		} else {
			enemyTextBubble.text = "";
		}
	}

	void CastDetectionRay(){
		RaycastHit rayHit;
		Physics.Raycast (transform.position + eyePosition, (player.position - transform.position), out rayHit, sightDistance, rayMask); 
		if (rayHit.transform != null) {
			if (rayHit.transform.tag == "Player"){

			}
			rayHitPosition = rayHit.point;
		}
		print (rayHit.transform);
	}

	void DrawSightRay(){
		Debug.DrawRay (transform.position + eyePosition, (player.position - transform.position), Color.green);
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere (rayHitPosition, .5f);
	}
}
