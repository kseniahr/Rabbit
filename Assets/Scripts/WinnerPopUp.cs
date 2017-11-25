using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinnerPopUp : MonoBehaviour {

	public Text fruit;

	public static WinnerPopUp current;


	void Awake() {
		current = this;
	}

	public void SetStats (LevelStat stat){
		fruit.text = (stat.collected_fruits.Count) + " from " + stat.totalfruits;

	}

	public void Reload(){

		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	public void Menu(){

		SceneManager.LoadScene("MainMenu");
	}

	public void NextLevel(){

		SceneManager.LoadScene("2");
	}

	public void ChooseLevel(){

		SceneManager.LoadScene("ChooseLevel");
	}

}
