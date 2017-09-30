using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
	public static LevelController current;
	Vector3 start_position;


	void Awake() {
		current = this;

	}

	public void SetStartingPosition (Vector3 pos){
		this.start_position = pos;

	}


	public void RabitOnDeath(MyRabit rabit) {


		rabit.transform.position = this.start_position;
	}




}
