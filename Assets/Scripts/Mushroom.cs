using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Collectable {
	
	void Start () {
		
	}

	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			other.transform.localScale = new Vector3 (1.2f, 1.2f, 1.2f); //increase the size of the rabbit
			Destroy (gameObject);
		}

	}
		
}
