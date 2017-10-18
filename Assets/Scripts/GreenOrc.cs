using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenOrc : MonoBehaviour {


	public float speed = 1;
	Rigidbody2D myBody = null;

	Animator myanim;

	public Vector3 pointA;
	public Vector3 pointB;

	void Start () {
		myBody = this.GetComponent<Rigidbody2D>();
		myanim = this.GetComponent<Animator> ();
		myanim.speed = 0.3f;

	}

	void FixedUpdate () {

		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
		float value = this.getDirection();

		if (Mathf.Abs (value) > 0) {
			Vector2 vel = myBody.velocity;
			vel.x = value * speed;
			myBody.velocity = vel;

		}
		if (value < 0) {
			sr.flipX = false;
		} else sr.flipX = true;

	}

	public void Die(){

		Debug.Log ("dead");


		myBody.isKinematic = true;
		this.GetComponent<BoxCollider2D> ().enabled = true;

		StartCoroutine (hideMeLater());


	}

	IEnumerator hideMeLater(){

		yield return new WaitForSeconds (2);
		Destroy (this.gameObject);
	}


	Mode mode = Mode.GoToA;



	public enum Mode{
		GoToA,
		GoToB,
		Attack

	}






	bool isArrived (Vector3 my_pos, Vector3 p) {

		if (p == pointA) {
			if (my_pos.x < p.x) {
				return true;
			} else {
				return false;
			}
		} else 
			if (my_pos.x > p.x) {
				return true;
			} else {
				return false;
			}

	}

	bool ShouldPatrolAB(){

		Vector3 rabit_pos = MyRabit.lastRabit.transform.position;

		if (rabit_pos.x > Mathf.Min (pointA.x, pointB.x) && rabit_pos.x < Mathf.Max (pointA.x, pointB.x)) {

			mode = Mode.Attack;
			return false;

		} else {
			return true;
		}

	}

	float getDirection() {

		Vector3 my_pos = this.transform.position;
		Vector3 rabit_pos = MyRabit.lastRabit.transform.position;


		if (ShouldPatrolAB ()) {
			if (mode == Mode.GoToA) {
				if (isArrived (my_pos, pointA)) {
					mode = Mode.GoToB;
					return 1;
				} else {
					return -1;
				}
			} else if (mode == Mode.GoToB) {
				if (isArrived (my_pos, pointB)) {
					mode = Mode.GoToA;
					return -1;
				} else {
					return 1;
				}
			} else
				return 0;


		} else {

			if (my_pos.x < rabit_pos.x) {

				return 1;
			} else {
				return -1;
			}
		}


	}
}







