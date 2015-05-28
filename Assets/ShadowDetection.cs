using UnityEngine;
using System.Collections;

public class ShadowDetection : MonoBehaviour {

	public Transform[] lightsInLevel;
	public float distance, transitionSpeed, viewDistance;
	public bool inShadow;
	public Material litMat, shadowMat;

	string normalTag = "Player";
	string hiddenTag = "PlayerShadow";

	public Renderer myRenderer;

	void Start(){
		//myRenderer = GetComponent<Renderer> ();
	}

	void Update(){
		CheckForLights ();
		SetMaterial ();
	}

	void CheckForLights(){
		bool lightInRange = false;
		foreach (Transform light in lightsInLevel) {
			if (Vector3.Distance (transform.position, light.position) < distance)
				lightInRange = true;
			if (Vector3.Distance (transform.position, light.position) > viewDistance && light.parent.gameObject.activeSelf){
				light.parent.gameObject.SetActive(false);
			} else if (Vector3.Distance (transform.position, light.position) < viewDistance && !light.parent.gameObject.activeSelf){
				light.parent.gameObject.SetActive(true);
			}

		}
		inShadow = !lightInRange;
	}

	void SetMaterial(){
		if (myRenderer.material != litMat && !inShadow) {
			myRenderer.material.Lerp (myRenderer.material, litMat, transitionSpeed * Time.deltaTime);
			transform.tag = normalTag;
		} else if (myRenderer.material != shadowMat && inShadow) {
			myRenderer.material.Lerp (myRenderer.material, shadowMat, transitionSpeed * Time.deltaTime);
			transform.tag = hiddenTag;
		}
	}


//	public Transform player;
//	public LayerMask sunMask;
//	public PlayerShadow playerShadowScript;
//	Vector3 hitPoint;
//
//	// Use this for initialization
//	void Start () {
//		player = GameObject.Find ("Player").transform;
//		playerShadowScript = player.GetComponent<PlayerShadow> ();
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		Debug.DrawRay (transform.position, (player.position - transform.position), Color.yellow);
//		CastSunRay ();
//	}
//
//	void CastSunRay(){
//		RaycastHit sunHit;
//		Physics.Raycast (transform.position, (player.position - transform.position), out sunHit, Mathf.Infinity, sunMask);
////		print (sunHit.transform);
//		if (sunHit.transform != null) {
//			if (sunHit.transform.tag == "Player" || sunHit.transform.tag == "PlayerShadow"){
//				playerShadowScript.hidden = false;
//			}else{
//				playerShadowScript.hidden = true;
//			}
//			hitPoint = sunHit.point;
//		}
//	}
//
//	void OnDrawGizmos(){
//		Gizmos.color = Color.yellow;
//		Gizmos.DrawSphere (hitPoint, .3f);
//	}
}
