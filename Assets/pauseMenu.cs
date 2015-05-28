using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class pauseMenu : MonoBehaviour {

	bool paused;
	public Text pauseText;

	void Update(){
		if (Input.GetButtonDown ("Fire2")) {
			Pause ();

			//print ("pressed");
			if (paused){
				pauseText.enabled = true;
			}else{
				pauseText.enabled = false;
			}
		}
	}

	void Pause(){
		paused = !paused;
		Time.timeScale = 1 - Time.timeScale;
	}

//
//	public bool paused = false;
//	public AudioSource[] sources;
//	//public FirstPersonController controller;
//	//public Texture2D tex;
//	public Slider volSlider;
//	public bool ending;
//
//	public GameObject pauseCanvas, main, sureQuit, sureRestart, sound;
//
//	// Use this for initialization
//	void Start () {
//		Time.timeScale = 1f;
//		Cursor.visible = false;
//		Cursor.lockState = CursorLockMode.Locked;
//	}
//
//	void OnLevelWasLoaded(int level){
//		if (level == 1) {
//			ending = false;
//		}
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		if (paused) {
//			Cursor.visible = true;
//
//			Cursor.lockState = CursorLockMode.None;
//		} else {
//			Cursor.visible = false;
////			Cursor.SetCursor(tex);
//			Cursor.lockState = CursorLockMode.Locked;
//		}
//		if (Input.GetButtonDown ("Fire2") && !ending) {
//			//print ("pressed");
//			if (paused){
//				Unpause();
//			}else{
//				Pause ();
//			}
//		}
//	}
//
//	void Pause(){
//
//		Time.timeScale = 0f;
//		Cursor.visible = true;
//		Cursor.lockState = CursorLockMode.None;
//		paused = true;
//		foreach (AudioSource source in sources) {
//			source.Pause();
//		}
//		pauseCanvas.SetActive (true);
//		controller.StopLook ();
//	}
//
//	public void Unpause(){
//		foreach (AudioSource source in sources) {
//			source.UnPause();
//		}
//		Cursor.visible = false;
//		Cursor.lockState = CursorLockMode.Locked;
//		ResetCanvas ();
//		paused = false;
//		pauseCanvas.SetActive (false);
//		ResetScale ();
//		controller.ResumeLook ();
//	}
//
//	void ResetScale(){
//		Time.timeScale = 1f;
//	}
//
//	public void ResetCanvas(){
//		main.SetActive (true);
//		sound.SetActive (false);
//		sureQuit.SetActive (false);
//		sureRestart.SetActive (false);
//	}
//
//	public void Quit1 (){
//		main.SetActive (false);
//		sound.SetActive (false);
//		sureQuit.SetActive (true);
//		sureRestart.SetActive (false);
//	}
//
//	public void Quit2 () {
//		ResetScale ();
//		controller.ResumeLook ();
//		Application.LoadLevel (0);
//	}
//
//	public void Restart1(){
//		main.SetActive (false);
//		sound.SetActive (false);
//		sureQuit.SetActive (false);
//		sureRestart.SetActive (true);
//	}
//
//	public void Restart2(){
//		ResetScale ();
//		controller.ResumeLook ();
//		Application.LoadLevel (1);
//	}
//
//	public void Sound(){
//		audioManager audioMan = GameObject.Find ("_gm").GetComponent<audioManager> ();
//		audioMan.slide = volSlider;
//		volSlider.value = audioMan.masterAudio;
//		main.SetActive (false);
//		sound.SetActive (true);
//		sureQuit.SetActive (false);
//		sureRestart.SetActive (false);
//	}
}
