using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class LevelController : MonoBehaviour {
	
	public static LevelController current;
	public GameObject settingsPrefab;
	public MyButton pauseButton;
	Vector3 start_position;

	public Text coinsLabel;

	public bool isPaused;
	public bool muted = false;

	public int mylevel;
	public int fruit;
	public int coins;

	public GameObject WinUI;
	public GameObject LoseUI;
	public GameObject PauseUI;
	public GameObject NoMusic;


	public AudioClip winSound = null;
	AudioSource winSource = null;

	public AudioClip loseSound = null;
	AudioSource loseSource = null;

	void Awake() {
		current = this;
	}

	void Start() {	
		NoMusic.SetActive (false);	
		PauseUI.SetActive(false);
		isPaused = false;
		WinUI.SetActive (false);
		LoseUI.SetActive (false);
		winSource = gameObject.AddComponent<AudioSource> ();
		winSource.clip = winSound;
		loseSource = gameObject.AddComponent<AudioSource> ();
		loseSource.clip = loseSound;

	}

	public void Lose() {
		Destroy (MyRabit.lastRabit);
		LoseUI.SetActive (true);
		Time.timeScale = 0.0f;
		loseSource.Play ();


	}

	public void Win(){
		
		winSource.Play ();
		Time.timeScale = 0.0f;
		WinUI.SetActive (true);

	}


	public void addFruit(int fruitid){
		FruitControll.current.addFruit(fruitid);

	}

	public void addCrystal(int crystal){
		CrystalController.current.addCrystal(crystal);

	}

	public void addCoin (){

		coins++;

	}

	public LevelStat getStats(){
		
		LevelStat stats = new LevelStat {
			mylevel = mylevel,
			levelpassed = true,
			collected_fruits = new List<int> (FruitControll.current.collectedFruits),
			totalfruits = FruitControll.current.totalFruits,
			allFruitsCollected = FruitControll.current.collectedFruits.Count >= FruitControll.current.totalFruits,
			collected_crystals = new List<int> (CrystalController.current.collectedCrystals),
			allCrystalsCollected = CrystalController.current.collectedCrystals.Count <= 3,
			collectedCoins = coins
		};

		return stats;

		}
		

	void Update(){

		coinsLabel.text = "000" + coins.ToString ();

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


	public void SetStartingPosition (Vector3 pos){
		this.start_position = pos;
	}


	public void RabitOnDeath (MyRabit rabit) { 
		rabit.transform.position = this.start_position;
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
		if (muted)
			NoMusic.SetActive (true);
		if (!muted)
			NoMusic.SetActive (false);
	}







}




