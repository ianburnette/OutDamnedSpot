using UnityEngine;
using System.Collections;

public class checkpointManager : MonoBehaviour {

	//playerprefs - levelNum, checkpointNum

	public GameObject[] checkpoints;
	public GameObject introText;
	GameController gc;

	// Use this for initialization
	void Start () {
		gc = GetComponent<GameController> ();
		int checkNum = PlayerPrefs.GetInt ("checkpointNum");
		Invoke ("HideIntro", 5f);
		if (checkNum > 0) {
			LoadCheckpoint(checkNum);
			if (introText != null) {
				introText.SetActive(false);
			}
			gc.FadeNow();
			CancelInvoke ("HideIntro");
		}if (Application.loadedLevel == 1) {
		//	print ("in loop");
			gc.FadeNow();
			CancelInvoke ("HideIntro");
		}

	}

	void HideIntro(){
		if (introText != null) {
			introText.SetActive (false);
		}
	}

	void LoadCheckpoint(int checkNum){
		checkpoints [checkNum - 1].GetComponent<checkpointScript> ().LoadThisCheckpoint ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha9)) {
			PlayerPrefs.SetInt ("checkpointNum", 0);
			Application.LoadLevel(Application.loadedLevel);
		}
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			print ("at checkpoint " + PlayerPrefs.GetInt("checkpointNum"));
			//PlayerPrefs.SetInt ("checkpointNum", 0);
			//Application.LoadLevel(Application.loadedLevel);
		}
	}

	public bool PassedCheckpoint(int checkpointPassed){
		bool newCheck = false;
		if (PlayerPrefs.GetInt ("checkpointNum") < checkpointPassed) {
			PlayerPrefs.SetInt ("checkpointNum", checkpointPassed);
			newCheck = true;
		}
		print ("set new checkpoint");
		return newCheck;
	}
}
