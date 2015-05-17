using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerTextBubble : MonoBehaviour {

	public Text bubbleText;

	// Use this for initialization
	void Start () {
	
	}

	public void SetText(string textToSet){
		bubbleText.text = textToSet;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
