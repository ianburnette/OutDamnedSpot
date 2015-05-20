using UnityEngine;
using System.Collections;

public class RagdollScript : MonoBehaviour {

	public Transform canvas;
	public GameObject ghostPrefab;
	public Rigidbody[] rbs;
	GuardAwareness awarenessScript;	
	GuardAnimation animScript;
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
		sword.transform.parent = null;
		Invoke ("CreateGhost", ghostTime);
	}

	void CreateGhost(){
		GameObject myGhost = (GameObject)Instantiate (ghostPrefab, transform.position, transform.rotation);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
