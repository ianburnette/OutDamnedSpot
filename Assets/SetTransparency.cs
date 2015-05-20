using UnityEngine;
using System.Collections;

public class SetTransparency : MonoBehaviour {

	public Transform player;
	public Transform toMakeTransparent;
	public float targetTransparency, currentTransparency;
	public LayerMask mask;
	public Material transparentMat;
	public Material placeholderMat;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Physics.Raycast(transform.position, (player.position - transform.position), out hit, Mathf.Infinity, mask);
		Material thisMaterial;
		if (hit.transform.tag == "pillar") {
			toMakeTransparent = hit.transform;
		} else if (toMakeTransparent != null){
			//thisMaterial = toMakeTransparent.GetComponent<Renderer>().material;
			//thisMaterial.color = new Color (thisMaterial.color.r, thisMaterial.color.g, thisMaterial.color.b, 1f);
			//print ("in loop");
			toMakeTransparent.GetComponent<Renderer>().material = placeholderMat;
			toMakeTransparent = null;
		}
		if (toMakeTransparent != null) {
			if (toMakeTransparent.transform.tag == "pillar"){
				//placeholderMat = toMakeTransparent.GetComponent<Renderer>().material;
				toMakeTransparent.GetComponent<Renderer>().material = transparentMat;
//				thisMaterial = toMakeTransparent.GetComponent<Renderer>().material;
//				currentTransparency = thisMaterial.color.a;
//				if (currentTransparency!= targetTransparency){
//					thisMaterial.color = new Color (thisMaterial.color.r, thisMaterial.color.g, thisMaterial.color.b, targetTransparency);
//				}
			}
		}
		Debug.DrawRay (transform.position, (player.position - transform.position), Color.red);
	}
}
