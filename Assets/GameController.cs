using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject finalDuncan;
	public Image blackScreen;
	public Text failureText, startOverText, endText1, endText2;
	public float fadeIncrement;
	public bool fade, readyToStartOver, beatGameFade, hitEndScreen, starting;
	string failureTextString;
	public GameObject[] physicalEndTexts;

	// Use this for initialization
	void Start () {
		if (Application.loadedLevel != 1) {
			fade = true;
			starting = true;
		}

		Invoke ("FadeNow", 5f);
	}

	public void FadeNow(){
		print ("fading");
		CancelInvoke ("FadeNow");
		fade = false;
		starting = false;
	}

	// Update is called once per frame
	void Update () {
		if (!starting) {
			FadeForFailure ();
		}
		ListenToStartOver ();
		BeatGameFade ();
	}

	void BeatGameFade(){
		if (beatGameFade) {
			if (blackScreen.color.a < 1) {
				//print ("first loop");
				blackScreen.color = new Color (0, 0, 0, blackScreen.color.a + fadeIncrement * 2 * Time.deltaTime);
			} else if (blackScreen.color.a >= 1 && !hitEndScreen) {
				//print ("second loop");
				Invoke("StartEnding", .5f);

			}
		}
	}

	void StartEnding(){
		hitEndScreen = true;
		endText1.enabled = true;
		endText2.enabled = true;
		foreach (GameObject text in physicalEndTexts){
			Destroy(text);//.SetActive (false);
		}
		Invoke ("SpawnDuncan", 6f);
		Invoke ("FinalMoment", 7f);
		Invoke ("EndGame", 10f);
	}

	void SpawnDuncan(){
		finalDuncan.SetActive (true);
	}

	void FinalMoment(){
		endText1.enabled = false;
		endText2.enabled = false;
		blackScreen.enabled = false;//color = new Color (0, 0, 0, 0);
	}

	void EndGame(){
		blackScreen.enabled = true;
		Invoke ("ShowCredits", 2f);

		//blackScreen.color = new Color (0, 0, 0, 1);
	}

	void ShowCredits(){
		Application.LoadLevel (Application.loadedLevel+1);
	}

	void ListenToStartOver(){
		if (readyToStartOver && Input.GetButtonDown("Fire1")) {
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	void FadeForFailure(){
		if (fade && blackScreen.color.a < 1) {

			blackScreen.color = new Color (0, 0, 0, blackScreen.color.a + fadeIncrement * Time.deltaTime);
		} else if (!fade && blackScreen.color.a > 0) {
			blackScreen.color = new Color (0, 0, 0, blackScreen.color.a - fadeIncrement * Time.deltaTime);
		} else if (fade && blackScreen.color.a >= 1) {
			failureText.enabled = true;
			failureText.text = failureTextString;
			startOverText.enabled = true;
			readyToStartOver = true;
		}
	}

	public void BeatGame(){
		Invoke ("StartFinalFade", 2f);
	
	}

	void StartFinalFade(){
		beatGameFade = true;
	}

	public void EndLevel(int reason){
		fade = true;
		if (reason == 0) {
			failureTextString = "You were killed.";
		} else if (reason == 1){
			failureTextString = "Macbeth was killed.";
		}
	}
}
