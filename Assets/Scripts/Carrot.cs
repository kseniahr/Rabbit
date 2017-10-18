using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour {
	
	public float speed = 1.0f;
	public float lifetime = 2.0f;
	public int damage = 1;


	// Use this for initialization
	void Start () {
		Destroy (gameObject, lifetime);

	}



	// Update is called once per frame
	void Update () {
		Vector3 rabit_pos = MyRabit.lastRabit.transform.position;
		SpriteRenderer sr = GetComponent<SpriteRenderer> ();

			Vector3 orc_pos = BrownOrc.lastOrc.transform.position;
		

		if (rabit_pos.x < orc_pos.x) {
			
			sr.flipX = true;
			transform.Translate (Vector3.left * Time.deltaTime * speed);
		}

		if (orc_pos.x < rabit_pos.x) {
			
			sr.flipX = false;
			transform.Translate (Vector3.right * Time.deltaTime * speed);
		}
	}

	void FixedUpdate () {



	}
		

}
