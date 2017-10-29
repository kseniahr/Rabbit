using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : Collectable {


	void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "Player" && gameObject.tag == "blue") {

			Destroy (this.gameObject);
			CrystalController.crystals_blue += 1;

		}
		if (other.tag == "Player" && gameObject.tag == "green") {

			Destroy (this.gameObject);
			CrystalController.crystals_green += 1;

		}

		if (other.tag == "Player" && gameObject.tag == "red") {

			Destroy (this.gameObject);
			CrystalController.crystals_red += 1;

		}

	}
}
