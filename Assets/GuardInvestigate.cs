using UnityEngine;
using System.Collections;

public class GuardInvestigate : MonoBehaviour {

	NavMeshAgent nav;
	GuardAwareness awarenessScript;
	GuardAnimation animScript;

	public float waitAtPointTime, wanderDist, investigateSpeed;
	bool waiting;
	public Vector3 destination;
	public float margin;
	public Vector3[] investigatePoints;
	public float maxDist;
	public int pointIndex;
	
	// Use this for initialization
	void Start () {
		investigatePoints = new Vector3[3];
		nav = GetComponent<NavMeshAgent> ();
		animScript = GetComponent<GuardAnimation> ();
		awarenessScript = GetComponent<GuardAwareness> ();
		SetNewDestination (destination);
	}

	void SetNewDestination(Vector3 dest){

//		nav.destination = dest;
//		investigatePoints [0] = dest;
		CreateSamplePoints (dest);
	}

	void CreateSamplePoints(Vector3 sampleOrigin){
		NavMeshHit hit;

		if (NavMesh.SamplePosition (new Vector3 
		                            (sampleOrigin.x, sampleOrigin.y, sampleOrigin.z), out hit, maxDist, NavMesh.AllAreas)){
			investigatePoints[0] = hit.position;
		}
		nav.destination = investigatePoints [0];
		nav.speed = investigateSpeed;
		if (NavMesh.SamplePosition (new Vector3 
		                            (sampleOrigin.x + Random.Range (3f, 4f), sampleOrigin.y, sampleOrigin.z + Random.Range (3f, 4f)), out hit, maxDist, NavMesh.AllAreas)){
			investigatePoints[1] = hit.position;
		}
		if (NavMesh.SamplePosition (new Vector3 
		                            (sampleOrigin.x + Random.Range (-3f, -4f), sampleOrigin.y, sampleOrigin.z + Random.Range (-3f, -4f)), out hit, maxDist, NavMesh.AllAreas)){
			investigatePoints[2] = hit.position;
		}
	}

	void Update () {
		if (Vector3.Distance (transform.position, investigatePoints[pointIndex]) < margin && !waiting) {
			Wait();
			waiting = true;
		}
	}

	void Wait(){
		waiting = true;
		nav.speed = 0;
		animScript.StopWalking ();
		Invoke ("NextPoint", waitAtPointTime);
	}

	void NextPoint(){
		if (pointIndex < investigatePoints.Length-1){
			pointIndex++;
			nav.destination = investigatePoints[pointIndex];
			nav.speed = investigateSpeed;
			animScript.StartWalking ();
		}else{
			ResumeWander();
		}
		waiting = false;
	}

	void ResumeWander(){
		awarenessScript.ResumeWandering ();
	}
}
