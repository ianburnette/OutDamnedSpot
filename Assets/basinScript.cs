using UnityEngine;
using System.Collections;

public class basinScript : MonoBehaviour {
	
	Transform player;
	public Material bloodyWater;
	public Transform water;

	public void SetUsed(){
		water.gameObject.GetComponent<Renderer> ().material = bloodyWater;
		Destroy (this);
	}
	
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter (Collider col){
		if (col.transform.tag == "Player" || col.transform.tag == "PlayerShadow") {
			//player = col.transform;
			if (col.transform.root.GetComponent<PlayerWash>().dirty == true){
				col.transform.root.GetComponent<PlayerTextBubble>().SetText("Wash Hands");
				col.transform.root.GetComponent<PlayerWash>().basin = transform;//("Space to kill");
			}
		}
	}
	
	void OnTriggerExit (Collider col){
		if (col.transform.tag == "Player" || col.transform.tag == "PlayerShadow") {
			//player = col.transform;
			col.transform.root.GetComponent<PlayerTextBubble>().SetText("");
			col.transform.root.GetComponent<PlayerWash>().basin = null;//("Space to kill");
		}
	}
	
	void OnDisable(){
		if (player) {
			player.GetComponent<PlayerTextBubble> ().SetText ("");
			player.GetComponent<PlayerWash> ().basin = null;//("Space to kill");
		}
	}
}
