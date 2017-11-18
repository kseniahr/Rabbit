using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : Collectable {

	public int fruitid;

	public bool iscollected = false;

	void Start(){
		LevelStat stats = LevelStat.load (LevelController.current.mylevel);
		iscollected = stats.collected_fruits.Contains(fruitid);
		if (iscollected) {
			EatFruit ();
		}

	}

	void OnTriggerEnter2D(Collider2D collision){
		if (collision.tag == "Player") {
			if (!iscollected) {
				Debug.Log ("Collected");
				LevelController.current.addFruit(fruitid);
				EatFruit ();


			}

		}

	}



	public void EatFruit(){
		
		iscollected = true;
		SpriteRenderer spr = this.GetComponent<SpriteRenderer> ();
		Color col = spr.color;
		col.a = 0.8f;
		spr.color = col;

	}

}