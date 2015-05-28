using UnityEngine;
using System.Collections;

public class SetTransparency : MonoBehaviour {

	public Transform player;
	public Transform toMakeTransparent;
	public float targetTransparency, currentTransparency;
	public LayerMask mask;
	public Material transparentMat;
	public Material placeholderMat;
	public float counterTime;
	public float horizontalDistance, verticalDistance, forwardDistance;

	// Use this for initialization
	void Start () {
	
	}

	void CheckRay (RaycastHit hit){
		if (hit.transform) {
			print ("hitting " + hit.transform);
		}
		if (hit.transform.tag == "wall") {
			hit.transform.SendMessage("Hide");
			//meshSwapper swapScript = hit.transform.GetComponent<meshSwapper>();
			//swapScript.hiddenCount = counterTime;
		}
	//	return true;
	}

	// Update is called once per frame
	void Update () {
		RaycastHit hit1;
		Physics.Raycast(transform.position, (player.position - transform.position), out hit1, Mathf.Infinity, mask);
		RaycastHit hit2;
		Physics.Raycast(transform.position + (transform.right * horizontalDistance) + (transform.up * verticalDistance) + (transform.forward * forwardDistance), (player.position - transform.position), out hit2, Mathf.Infinity, mask);		
		RaycastHit hit3;
		Physics.Raycast(transform.position - (transform.right * horizontalDistance) + (transform.up * verticalDistance)+ (transform.forward * forwardDistance), (player.position - transform.position), out hit3, Mathf.Infinity, mask);
		CheckRay (hit1);
		CheckRay (hit2);
		CheckRay (hit3);




//		Material thisMaterial;
//		if (hit.transform.tag == "pillar") {
//			toMakeTransparent = hit.transform;
//		} else if (toMakeTransparent != null){
//			//thisMaterial = toMakeTransparent.GetComponent<Renderer>().material;
//			//thisMaterial.color = new Color (thisMaterial.color.r, thisMaterial.color.g, thisMaterial.color.b, 1f);
//			//print ("in loop");
//			toMakeTransparent.GetComponent<Renderer>().material = placeholderMat;
//			toMakeTransparent = null;
//		}
//		if (toMakeTransparent != null) {
//			if (toMakeTransparent.transform.tag == "pillar"){
//				//placeholderMat = toMakeTransparent.GetComponent<Renderer>().material;
//				toMakeTransparent.GetComponent<Renderer>().material = transparentMat;
//				thisMaterial = toMakeTransparent.GetComponent<Renderer>().material;
//				currentTransparency = thisMaterial.color.a;
//				if (currentTransparency!= targetTransparency){
//					thisMaterial.color = new Color (thisMaterial.color.r, thisMaterial.color.g, thisMaterial.color.b, targetTransparency);
//				}
			

		Debug.DrawRay (transform.position, (player.position - transform.position), Color.red);
		Debug.DrawRay (transform.position + (transform.right * horizontalDistance) + (transform.up * verticalDistance)+ (transform.forward * forwardDistance), (player.position - transform.position), Color.red);
		Debug.DrawRay (transform.position - (transform.right * horizontalDistance) + (transform.up * verticalDistance)+ (transform.forward * forwardDistance), (player.position - transform.position), Color.red);
	}
}
