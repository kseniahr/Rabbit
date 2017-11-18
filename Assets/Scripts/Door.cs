using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

	public GameObject winPopUpPrefab;


	public int level = 1;


	public void whatLevelIs(){


	}


	void OnTriggerEnter2D (Collider2D col){




		if (col.tag == "Player") {

			LevelStat stats = LevelController.current.getStats();

			WinnerPopUp.current.SetStats (stats);
		
			stats.Save ();

			if (level == 1 || LevelStat.load (level - 1).levelpassed) {
				LevelController.current.Win ();


			}

			if (level == 2 || LevelStat.load (level - 1).levelpassed) {
				LevelController.current.Win ();


			}

		}

	}




}
