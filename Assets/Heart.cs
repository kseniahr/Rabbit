using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		
		if (other.tag == "Player") {
			GameControllScript.health += 1;
			Destroy(gameObject);
		}
	}
}
