using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrownOrc : MonoBehaviour {


	public float speed = 1;
	Rigidbody2D myBody = null;
	public static BrownOrc lastOrc;

	Animator myanim;

	public Vector3 pointA;
	public Vector3 pointB;

	public Transform carrot;

	public float carrotDistance = 1f;
	public float timeBetweenFires = 2f;
	private float timeTillNextAttack = 2.0f; 

	void Awake (){

		lastOrc = this;

	}

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

	void Update(){
		Vector3 rabit_pos = MyRabit.lastRabit.transform.position;

		if (mode == Mode.Attack) {

			if (timeTillNextAttack < 0) {
				timeTillNextAttack = timeBetweenFires;
				if (this.transform.position.x > rabit_pos.x) {
					
					ShootCarrotLeft();
				} else {
					
					ShootCarrotRight();
			}
		}
		timeTillNextAttack -= Time.deltaTime;

		}
	}


	void ShootCarrotRight(){
		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
		float my_posX = this.transform.position.x + carrotDistance;
	
		float my_posY = this.transform.position.y + 0.5f;


			Instantiate (carrot, new Vector3 (my_posX, my_posY, 0), this.transform.rotation);

	}


	void ShootCarrotLeft(){
		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
		float my_posX = this.transform.position.x - carrotDistance;

		float my_posY = this.transform.position.y + 0.5f;


	
			Instantiate (carrot, new Vector3 (my_posX, my_posY, 0), this.transform.rotation);


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

		if (rabit_pos.x > Mathf.Min (pointA.x, pointB.x) && rabit_pos.x < Mathf.Max (pointA.x, pointB.x) && Mathf.Abs(rabit_pos.y - this.transform.position.y) < 1f) {
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
			SpriteRenderer sr = GetComponent<SpriteRenderer> ();
			if (my_pos.x < rabit_pos.x) {
				
				sr.flipX = true;
				return 1;
			} else {
				sr.flipX = false;
				return -1;
			}
		}


	}
}







