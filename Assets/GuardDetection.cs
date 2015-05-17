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
	GuardChase chaseScript;
	bool inSightCone, inPeripheral;
	public Text enemyTextBubble;
	Vector3 relativePoint;
	public float nearSightDist, farSightDist, darkSightDistance;
	public float peripheralMargin;

	public bool sightBlocked;
	

	public int currentBehavior = 0;
	/*
	 * 0=wander
	 * 1=suspicious
	 * 2=aware
	 * */

	// Use this for initialization
	void Start () {
		wanderScript = GetComponent<GuardWander> ();
		chaseScript = GetComponent<GuardChase> ();
	}
	
	// Update is called once per frame
	void Update () {
		DrawSightRay ();
		CastDetectionRay ();
		DetectPlayerPosition ();
		DrawText ();

		if (currentBehavior == 2) {
			//if ((relativePoint.z < sightDistance && inSightCone && player.tag == "Player") || (relativePoint.z < sightDistance && inPeripheral && player.tag == "Player") ){
			if (sightBlocked){
//				if (player.tag == "Player"){
//					chaseScript.UpdatePlayerLocation (player.position);
//				}else if (relativePoint.z < darkSightDistance && inSightCone){
//					chaseScript.UpdatePlayerLocation (player.position);
//				}
//
//				chaseScript.aware = true;
			}else{
				chaseScript.UpdatePlayerLocation (player.position);
			}
		}

		if (currentBehavior == 1) {
			if (player.tag == "Player"){
				chaseScript.UpdatePlayerLocation (player.position);
			}else if (relativePoint.z < darkSightDistance && inSightCone){
				chaseScript.UpdatePlayerLocation (player.position);
			}
			chaseScript.suspicious = true;
		}


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
			if (relativePoint.z >= Mathf.Abs (relativePoint.x) - peripheralMargin){
				inPeripheral = true;
			} else {
				inPeripheral = false;
			}
		} else {
			inSightCone = false;
			inPeripheral = false;
		}

		SetBehavior ();


		//print ("player is to the " + relativePoint);
	}

	void ChangeBehavior(int newBehavior){
		if (newBehavior == 2) {
			wanderScript.enabled = false;
			chaseScript.enabled = true;
		}
	}

	void SetBehavior(){
		if (inSightCone && relativePoint.z < nearSightDist && player.tag == "Player") { //in front of, close, and in light
			if (currentBehavior!=2){
				currentBehavior = 2;
				ChangeBehavior(2);
			}
		} else if (inSightCone && relativePoint.z < farSightDist && player.tag == "Player") { //in front of, far, and in light
			if (currentBehavior!=1 && currentBehavior != 2){
				currentBehavior = 1;
				ChangeBehavior(1);
			}
		} else if (inPeripheral && relativePoint.z < farSightDist && player.tag == "Player") {
			if (currentBehavior!=1 && currentBehavior != 2){
				currentBehavior = 1;
				ChangeBehavior(1);
			}
		} else {
			
		}

	}

	void DrawText(){
		if (inSightCone && relativePoint.z < nearSightDist && player.tag == "Player") {
			enemyTextBubble.text = "!";
		} else if (inSightCone && relativePoint.z < farSightDist && player.tag == "Player") {
			enemyTextBubble.text = "?";
		} else if (inPeripheral && relativePoint.z < farSightDist && player.tag == "Player") {
			enemyTextBubble.text = ">";
		} else {
			enemyTextBubble.text = "";
		}
	}

	void CastDetectionRay(){
		RaycastHit rayHit;
		Physics.Raycast (transform.position + eyePosition, (player.position - transform.position), out rayHit, sightDistance, rayMask); 
		if (rayHit.transform != null) {
			if (rayHit.transform.tag == "Player" || rayHit.transform.tag == "PlayerShadow"){
				sightBlocked = false;
			}else{
				sightBlocked = true;
			}
			rayHitPosition = rayHit.point;
		}
//		print (rayHit.transform);
	}

	void DrawSightRay(){
		Debug.DrawRay (transform.position + eyePosition, (player.position - transform.position), Color.green);
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere (rayHitPosition, .5f);
	}
}
