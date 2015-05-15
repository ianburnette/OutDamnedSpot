using UnityEngine;
using System.Collections;

public class PlayerShadow : MonoBehaviour {

	public bool hidden;
	public Material normalMat, shadowedMat, myMat;
	public Renderer myRenderer;

	void Start(){
		myRenderer = transform.GetChild (0).GetComponent<Renderer> ();
		//myMat = myRenderer.material;
	}

	void Update () {
		if (hidden && myRenderer.material != shadowedMat) {
			myRenderer.material = shadowedMat;
		} else if (!hidden && myRenderer.material != normalMat) {
			myRenderer.material = normalMat;
		}
	}
}
