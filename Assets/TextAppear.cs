using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextAppear : MonoBehaviour {

	public Transform player;
	public float distance, alphaIncrement;
	public Text myText1, myText2;
	public Color targetColor;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").transform;
		myText2 = transform.GetChild (0).GetComponent<Text>();
		myText1 = transform.GetChild (1).GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		float distAway = Vector3.Distance (player.position, transform.position);
	//	print ("dist away is " + distAway);
		if (distAway < distance && myText1.color.a != 1 && myText2.color.a != 1) {
			myText1.color = Color.Lerp (myText1.color, new Color (1,1,1,1), alphaIncrement);
			myText2.color = Color.Lerp (myText2.color, new Color (0,0,0,1), alphaIncrement);
			//myText1.color = new Color (1,1,1,myText1.color.a + alphaIncrement);
		//	myText2.color = new Color (0,0,0,myText2.color.a + alphaIncrement);
		}
		if (distAway >= distance && myText1.color.a != 0 && myText2.color.a != 0) {
			myText1.color = Color.Lerp (myText1.color, new Color (1,1,1,0), alphaIncrement);
			myText2.color = Color.Lerp (myText2.color, new Color (0,0,0,0), alphaIncrement);
		}
	}
}
