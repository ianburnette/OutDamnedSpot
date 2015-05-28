using UnityEngine;
using System.Collections;

public class FrameGuards : MonoBehaviour {

	public Transform player;
	public Material sleepingGuard;
	public Texture bloodyGuard;
	public Texture normalGuard;
	bool canFrame, done;

	// Use this for initialization
	void Start () {
		sleepingGuard.mainTexture = normalGuard;
	}
	
	// Update is called once per frame
	void Update () {
		if (canFrame && !done && Input.GetButtonDown("Fire1")) {
			canFrame = false;
			done = true;
			player.GetComponent<PlayerTextBubble>().SetText("");
			sleepingGuard.mainTexture = bloodyGuard;
			player.GetComponent<PlayerWash>().dirty = true;
			transform.GetChild(0).gameObject.SetActive(true);
		}
	}

	void OnTriggerEnter (Collider col){
		if (col.transform.tag == "Player" || col.transform.tag == "PlayerShadow" && !done) {
			//player = col.transform;
		
				col.transform.root.GetComponent<PlayerTextBubble>().SetText("Frame Guards");
				canFrame = true;
		
		}
	}
	
	void OnTriggerExit (Collider col){
		if (col.transform.tag == "Player" || col.transform.tag == "PlayerShadow") {
			//player = col.transform;
			col.transform.root.GetComponent<PlayerTextBubble>().SetText("");
			canFrame = false;
		}
	}
	
	void OnDisable(){
		if (player) {
			player.GetComponent<PlayerTextBubble> ().SetText ("");
		}
	}

}
