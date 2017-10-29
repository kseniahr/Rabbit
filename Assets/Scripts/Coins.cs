using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : Collectable {

	public UILabel coinsLabel;
	public float coins_quantity = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "Player") {
			coins_quantity = coins_quantity + 1; 
			coinsLabel.text ="000" + coins_quantity.ToString();
			//Destroy (this.gameObject);
		}
	}


}
