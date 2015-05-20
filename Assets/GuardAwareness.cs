using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GuardAwareness : MonoBehaviour {

	public float eyeHeight;
	public float nearDistance, peripheralDistance, peripheralMargin;
	public Transform player, macbeth;
	public int canSeePlayer, canSeeMacbeth;

	public Sprite questionMark, exclamationMark;
	public LayerMask seeMask;

	public float seeInDarkDist;

	public Image suspicionMark;
	public float suspicion = 0;
	public float suspicionRiseBase = .001f;
	public float seekSpeed;
	public bool lineOfSight;

	public int behavior;
	//behavior scripts
	GuardWander wanderScript; 			//behavior 1
	GuardInvestigate investigateScript; //behavior 2
	GuardChase chaseScript; 			//behavior 3

	// Use this for initialization
	void Start () {
		investigateScript = GetComponent<GuardInvestigate> ();
		wanderScript = GetComponent<GuardWander> ();
		chaseScript = GetComponent<GuardChase> ();
	}
	
	// Update is called once per frame
	void Update () {
		canSeePlayer = CheckFor (player);
		canSeeMacbeth = CheckFor (macbeth);
		CheckLineOfSight ();

		if ((canSeePlayer == 1 && suspicion < 1) || (canSeeMacbeth == 1 && suspicion < 1)) {
			UpdateSuspicion ();
			behavior = 2;
			print ("in loop");
		} else if (canSeePlayer == 2 && chaseScript.target != player && player.tag == "Player") {
			SeeTarget (player);
			behavior = 3;
		} else if (canSeePlayer == 2 && chaseScript.target != player && player.tag == "PlayerShadow"){
			bool tooClose = CheckDistance();
			if (tooClose){
				SeeTarget (player);
				behavior = 3;
			}
		}else if (canSeeMacbeth == 2 && chaseScript.target != macbeth) {
			SeeTarget (macbeth);
			behavior = 3;
		} else if (chaseScript.target == player && !lineOfSight) {
			Seek (chaseScript.target);
			behavior = 2;
			//suspicion -= suspicionRiseBase;
		} else if (behavior == 2 && suspicion <= 0) {
			ResumeWandering ();

		} else if (suspicion == 1) {

			if (canSeePlayer == 1){
				SeeTarget(player);
			}else if (canSeeMacbeth == 1){
				SeeTarget(macbeth);
			}
		}


		else{
			behavior = 1;
			if (suspicion>0)
				suspicion -= suspicionRiseBase;
			UpdateSuspicion();
		}
	
	}

	public void HideMark(){
		suspicionMark.enabled = false;
	}

	bool CheckDistance(){
		bool tooClose = false;
		if (Vector3.Distance (transform.position, player.position) < seeInDarkDist)
			tooClose = true;
		return tooClose;
	}

	void CheckLineOfSight(){
		RaycastHit hit;
		Physics.Raycast (transform.position + (Vector3.up * eyeHeight), (player.position - (transform.position - (Vector3.down * eyeHeight))), out hit, 30f, seeMask);
		//Debug.DrawRay (new Vector3 (transform.position.x, transform.position.y + eyeHeight, transform.position.y), transform.position - player.position, Color.green);
		if (hit.transform != null) {
		//	print ("guard sees " + hit.transform);
			if (hit.transform.tag == "Player" || hit.transform.tag == "PlayerShadow" || hit.transform.tag == "macbeth"){
				lineOfSight = true;
			}else{
				lineOfSight = false;
			}
		}
		Debug.DrawRay (transform.position + (Vector3.up * eyeHeight), (player.position - (transform.position - (Vector3.down * eyeHeight))), Color.green);
	}

	void Seek(Transform target){
		suspicionMark.sprite = questionMark;
		chaseScript.target = null;
		chaseScript.enabled = false;
		wanderScript.enabled = false;
		investigateScript.enabled = true;
		print ("Seek");
		investigateScript.SetNewDestination (target.position, seekSpeed);
	}

	void SeeTarget (Transform target){
		suspicionMark.sprite = exclamationMark;
		suspicion = 1;
		UpdateSuspicionMark ();
		//suspicionMark.color = new Color (suspicionMark.color.r, suspicionMark.color.g, suspicionMark.color.b, suspicion);
		chaseScript.enabled = true;
		investigateScript.enabled = false;
		wanderScript.enabled = false;
		if (chaseScript.target != target) {
			chaseScript.target = target;
		}

	}

	void UpdateSuspicion(){
		if (canSeePlayer == 1 && suspicion<1) 
			suspicion += suspicionRiseBase;// / Vector3.Distance (transform.position, player.position);
		if (canSeeMacbeth == 1 && suspicion<1) 
			suspicion += suspicionRiseBase;// / Vector3.Distance (transform.position, player.position);
		if (suspicion > 0 && canSeePlayer != 1 && canSeeMacbeth!=1 && !lineOfSight)
			suspicion -= suspicionRiseBase;
		if (suspicion > 0 && suspicion < 1) {
			if (wanderScript.enabled == true)
				wanderScript.enabled = false;
			if (investigateScript.enabled == false){
				investigateScript.enabled = true;
				if (canSeePlayer == 1)
					investigateScript.SetNewDestination(player.position, investigateScript.investigateSpeed);
				if (canSeeMacbeth == 1)
					investigateScript.SetNewDestination(macbeth.position, investigateScript.investigateSpeed);
				//print ("Suspicious");
			}
		}

		UpdateSuspicionMark ();
	}

	void UpdateSuspicionMark(){
		suspicionMark.color = new Color (suspicionMark.color.r, suspicionMark.color.g, suspicionMark.color.b, suspicion);
	}

	int CheckFor(Transform whoToCheckFor){
		int canSeeTarget = 0;
		Vector3 relativePoint = transform.InverseTransformPoint (whoToCheckFor.position);
		string relativeString;
		bool inSightCone;
		bool inPeripheral;

		if (relativePoint.x > 0) 
			relativeString = "right";
		else 
			relativeString = "left";

		if (relativePoint.z > 0) { //player in front of enemy
			if (relativePoint.z >= Mathf.Abs (relativePoint.x)) { //inside cone
				inSightCone = true;
			}  else {
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

		if (inSightCone && Vector3.Distance (transform.position, whoToCheckFor.position) < nearDistance) {
			canSeeTarget = 2;
		} else if ((inPeripheral || inSightCone) && Vector3.Distance (transform.position, whoToCheckFor.position) < peripheralDistance) {
			canSeeTarget = 1;
		} else {
			canSeeTarget = 0;
		}
		return canSeeTarget;
		//print ("player is to the " + relativePoint);
	}

	public void ResumeWandering(){
		investigateScript.enabled = false;
		chaseScript.enabled = false;
		wanderScript.enabled = true;
	}

	public void OnDisable(){
		chaseScript.enabled = false;
		investigateScript.enabled = false;
		wanderScript.enabled = false;
	}
}
