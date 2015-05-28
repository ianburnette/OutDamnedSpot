using UnityEngine;
using System.Collections;

public class killDuncan : MonoBehaviour {

	public Transform duncan;
	public float minDist;
	GuardAnimation animationScript;
	MacbethFollow followScript;
	NavMeshAgent nav;
	public 	bool killing = false;
	public Renderer duncanRenderer, myRenderer;
	public Animator duncanAnimator;
	public Texture duncanBloody, macbethBloody;

	// Use this for initialization
	void Start () {
		animationScript = GetComponent<GuardAnimation> ();
		followScript = GetComponent<MacbethFollow> ();
		nav = GetComponent <NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (killing && Vector3.Distance (transform.position, duncan.position) < minDist) {
			animationScript.KillDuncan();
		
			Invoke ("TextureSet", 2f);
			Invoke ("ResetDestination", 3.3f);
			killing = false;
			transform.LookAt(duncan.position);
		}
	}

	void TextureSet(){
		//duncanRenderer.material.mainTexture = duncanBloody;
		duncanAnimator.SetTrigger("die");
		myRenderer.material.mainTexture = macbethBloody;
	}

	public void StartKilling(){
		followScript.player = duncan;
		killing = true;
		nav.stoppingDistance = 0;
	}

	public void ResetDestination(){
		followScript.player = GameObject.Find ("Player").transform;
		animationScript.StartWalking ();
		nav.stoppingDistance = 1f;
	}
}
