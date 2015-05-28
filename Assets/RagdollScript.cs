using UnityEngine;
using System.Collections;

public class RagdollScript : MonoBehaviour {

	public Transform canvas, bloodSpreadPrefab, bloodSpatterPrefab;
	public Vector3 particleStart;
	public GameObject ghostPrefab;
	public Rigidbody[] rbs;
	GuardAwareness awarenessScript;	
	public GuardAnimation animScript;
	public LayerMask deadMask;
	public Transform trigger;
	public Rigidbody sword;
	NavMeshAgent nav;
	public float ghostTime = 3f;

	// Use this for initialization
	void Start () {
		animScript = GetComponent<GuardAnimation> ();
		awarenessScript = GetComponent <GuardAwareness> ();
		nav = GetComponent<NavMeshAgent> ();
	}

	public void Stop(){
		animScript.StopToDie ();
		foreach (Rigidbody rb in rbs) {
			rb.GetComponent<Collider>().isTrigger=true;
		}
		nav.enabled = false;
	}

	public void Die(){
		if (canvas)
			Destroy (canvas.gameObject);
		if (animScript!=null)
			animScript.DisableSelf ();// = false;
		if (awarenessScript!=null)
			awarenessScript.enabled = false;
		trigger.gameObject.SetActive (false);
		foreach (Rigidbody rb in rbs) {
			rb.GetComponent<Collider>().isTrigger=false;
			rb.isKinematic=false;
			rb.gameObject.layer = 10;
		}
		Transform blood = (Transform)Instantiate (bloodSpatterPrefab, transform.position + particleStart, Quaternion.Euler(transform.forward));
		blood.transform.parent = rbs [1].transform;
		Invoke ("Spread", 2f);
		sword.transform.parent = null;
		Invoke ("CreateGhost", ghostTime);
	}

	void Spread(){
		Transform blood = (Transform)Instantiate (bloodSpreadPrefab,transform.position + particleStart, Quaternion.Euler(new Vector3(270,0,0)));
		//blood.transform.parent = rbs [1].transform;
	}

	public void JustRagdoll(){

		if (canvas)
			Destroy (canvas.gameObject);
		//if (animScript)
		//animScript.DisableSelf ();// = false;
		GetComponentInChildren<Animator> ().enabled = false;
		GetComponent<NavMeshAgent> ().enabled = false;
		if (awarenessScript!=null)
			awarenessScript.enabled = false;
		trigger.gameObject.SetActive (false);
		foreach (Rigidbody rb in rbs) {
			rb.GetComponent<Collider>().isTrigger=false;
			rb.isKinematic=false;
			rb.gameObject.layer = 10;
		}
		sword.transform.parent = null;
	}

	void CreateGhost(){
		GameObject myGhost = (GameObject)Instantiate (ghostPrefab, transform.position, transform.rotation);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
