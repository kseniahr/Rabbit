using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : Collectable {


	public UILabel fruitLabel;
	public float fruits_quantity = 0f;
	public float fruits_am = 10f;


	void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "Player") {
			fruits_quantity = fruits_quantity + 1; 
			fruitLabel.text = fruits_quantity.ToString() + "/" + "10" ;
		}
	}

}