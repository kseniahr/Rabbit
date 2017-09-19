using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHere : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider) {
		MyRabit rabit = collider.GetComponent<MyRabit>();


		if (rabit != null){			
			LevelController.current.RabitOnDeath(rabit);
	}

}
}