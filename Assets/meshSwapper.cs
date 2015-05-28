using UnityEngine;
using System.Collections;

public class meshSwapper : MonoBehaviour {

	public Transform player;
	public MeshRenderer childMesh;
	public MeshRenderer originalMesh;
	public bool hidden;
	public int hiddenCount;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").transform;
		originalMesh = GetComponent<MeshRenderer> ();
		childMesh = transform.GetChild (0).GetComponent<MeshRenderer> ();
		//originalMesh = filter.mesh;

	}
	
	// Update is called once per frame
	void Update () {
		if (player.position.x > transform.position.x) {
			//print ("greater x");
		}
		if (player.position.z > transform.position.z) {
		//	print ("greater z");
		}
		if (player.position.x > transform.position.x && player.position.z > transform.position.z ) {
			originalMesh.enabled = true;
			childMesh.enabled = false;
			//print ("in first");
		}else if ((player.position.x < transform.position.x || player.position.z < transform.position.z ) ){
			originalMesh.enabled = false;
			childMesh.enabled = true;
		//	print ("in second");
		}
//		if (hidden && originalMesh.enabled) {
//			originalMesh.enabled = false;
//			childMesh.enabled = true;
//		} else if (!hidden && !originalMesh.enabled) {
//			originalMesh.enabled = true;
//			childMesh.enabled = false;
//		}
//		if (hiddenCount > 0) {
//			hidden = true;
//			hiddenCount--;
//		} else {
//			hidden = false;
//		}
		
	}

	public void Hide(){
		hiddenCount = 100;
	}
}
