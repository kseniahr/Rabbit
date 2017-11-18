using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : Collectable {


	public int  id;
	public bool iscollected = false;



	void Start(){
		LevelStat stats = LevelStat.load (LevelController.current.mylevel);
		iscollected = stats.collected_crystals.Contains (id);
		if (iscollected) {
			SaveCrystal ();
		}

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			if (!iscollected) {
				Debug.Log ("saved crystal with id" + id);

				LevelController.current.addCrystal (id);


				if (gameObject.tag == "blue") {
					SaveCrystal ();

					CrystalController.crystals_blue += 1;

				}
				if (other.tag == "Player" && gameObject.tag == "green") {

					SaveCrystal ();
					CrystalController.crystals_green += 1;

				}

				if (other.tag == "Player" && gameObject.tag == "red") {

					SaveCrystal ();
					CrystalController.crystals_red += 1;

				}

			}
		}
	}

	public void SaveCrystal(){

		iscollected = true;
		SpriteRenderer spr = this.GetComponent<SpriteRenderer> ();
		Color col = spr.color;
		col.a = 0.5f;
		spr.color = col;

	}
}
