using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameCntrl : MonoBehaviour {
	
	public GameObject PauseUI;
	public bool isPaused;
	public bool muted = false;
	void Start () {
		PauseUI.SetActive (false);
		isPaused = false;

	}

	void Update(){
		
		if (isPaused) {
			PauseGame (true);
		} else {

			PauseGame (false);
		}

		if (muted) {

			AudioListener.volume = 0;
		} else {
			AudioListener.volume = 1;
		}

		if (Input.GetButtonDown ("Cancel")) {

			switchPause ();
		}

	}

	public void PauseGame(bool state){
		if (state) {
			
			PauseUI.SetActive (true);
			Time.timeScale = 0.0f;
		} else {

			Time.timeScale = 1.0f;
			PauseUI.SetActive (false);
		}
	}

	public void switchPause (){
		if (isPaused) {

			isPaused = false;
		} else {
			isPaused = true;
		}

	}

	public void Mute(){
		
		muted = !muted;
	}

	public void Reload(){

		Application.LoadLevel (Application.loadedLevel);
	}

	public void Menu(){

		SceneManager.LoadScene("MainMenu");
	}

}