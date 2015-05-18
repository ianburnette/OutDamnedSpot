using UnityEngine;
using System.Collections;

public class ShadowDetection : MonoBehaviour {

	public Transform player;
	public LayerMask sunMask;
	PlayerShadow playerShadowScript;
	Vector3 hitPoint;

	// Use this for initialization
	void Start () {
		playerShadowScript = player.GetComponent<PlayerShadow> ();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawRay (transform.position, (player.position - transform.position), Color.yellow);
		CastSunRay ();
	}

	void CastSunRay(){
		RaycastHit sunHit;
		Physics.Raycast (transform.position, (player.position - transform.position), out sunHit, Mathf.Infinity, sunMask);
		print (sunHit.transform);
		if (sunHit.transform != null) {
			if (sunHit.transform.tag == "Player" || sunHit.transform.tag == "PlayerShadow"){
				playerShadowScript.hidden = false;
			}else{
				playerShadowScript.hidden = true;
			}
			hitPoint = sunHit.point;
		}
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere (hitPoint, .3f);
	}
}
