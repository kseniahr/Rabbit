using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class MainMenu : MonoBehaviour {

	public void ChangeScene (string sceneName ){

		Application.LoadLevel (sceneName);
	}


	/*
	public MyButton playbutton;
	public MyButton setbutton;

	// Use this for initialization
	void Start () {
		MyButton btn = playbutton.GetComponent<MyButton> ();
		btn.signalOnClick.AddListener (this.onPlay);
	}

	void onPlay(){
		
		SceneManager.LoadScene ("3");
	}

	void onSettings(){



	} 
// play?on click method */
}
