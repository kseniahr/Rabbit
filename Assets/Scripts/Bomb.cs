using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D collider) {

		MyRabit rabit = collider.GetComponent<MyRabit>();
		Animator rabit_an = rabit.GetComponent<Animator>();

		if (collider.tag == "Player") {

			if (collider.transform.localScale == new Vector3 (1.0f, 1.0f, 1.0f)) {
				
				rabit_an.SetBool ("die", true);

				Destroy (gameObject);

				if (rabit != null){		
					

					LevelController.current.RabitOnDeath(rabit);
					rabit_an.SetBool ("die", false);

				}





			} else {

				collider.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
				Destroy (gameObject);


			}

		}
	}
}
