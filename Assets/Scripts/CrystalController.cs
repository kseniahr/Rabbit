using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalController : MonoBehaviour {


	public HashSet<int> collectedCrystals;
	public int totalCrystals;

	public UILabel crystalLabel;
	public UILabel totalcrystalLabel;


	public GameObject blue, green, red;

	public static int crystals_blue;
	public static int crystals_red;
	public static int crystals_green;

	public static CrystalController current;


	void Awake () {
		current = this;
	}

	void Start () {
		
		LevelStat stat = LevelStat.load (LevelController.current.mylevel);


		collectedCrystals = new HashSet<int> (stat.collected_crystals);


		blue.gameObject.SetActive (true);
		green.gameObject.SetActive (true);
		red.gameObject.SetActive (true);
	}

	public void addCrystal(int crystalId){
		this.collectedCrystals.Add (crystalId);
	}
	// Update is called once per frame
	void Update () {
		if (crystals_red >= 1) {
			red.gameObject.SetActive (false);



		}

		if (crystals_blue >= 1) {
			blue.gameObject.SetActive (false);



		}
		if (crystals_green >= 1) {
			green.gameObject.SetActive (false);



		}
	}
}
