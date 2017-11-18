using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAdds : MonoBehaviour {

	public static DoorAdds current;

	public int mylevel;
	public GameObject Locker;
	public GameObject FruitImage;
	public GameObject CrystalImage;
	public GameObject CheckImage;


	void Start () {
		
		LevelStat stat = LevelStat.load (mylevel);

		if (mylevel == 1 || LevelStat.load (mylevel - 1).levelpassed) {

			Locker.SetActive (false);
		}

		if (stat.allFruitsCollected) {
			FruitImage.SetActive (true);
		}

		if (stat.allCrystalsCollected) {
			CrystalImage.SetActive (true);
		}

		if (!stat.levelpassed) {

			CheckImage.SetActive (false);

		}
	}



	
	void Awake() {
		current = this;
	}
}
