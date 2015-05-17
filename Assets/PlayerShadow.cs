using UnityEngine;
using System.Collections;

public class PlayerShadow : MonoBehaviour {

	string normalTag = "Player";
	string hiddenTag = "PlayerShadow";
	public bool hidden;
	public Material normalMat, shadowedMat, myMat;
	public Renderer myRenderer;

	void Start(){
		myRenderer = transform.GetChild (1).GetComponent<Renderer> ();
		//myMat = myRenderer.material;
	}

	void Update () {
		if (hidden && myRenderer.material != shadowedMat) {
			myRenderer.material = shadowedMat;
			transform.tag = hiddenTag;
		} else if (!hidden && myRenderer.material != normalMat) {
			myRenderer.material = normalMat;
			transform.tag = normalTag;
		}
	}
}
