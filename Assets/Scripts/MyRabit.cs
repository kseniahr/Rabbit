using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRabit : MonoBehaviour {

// стрибки, зупинка платформи
	public static MyRabit lastRabit;

	public float speed = 1;
	Rigidbody2D myBody = null;
	bool isGrounded = true;
	bool JumpActive = false;
	float JumpTime = 0f;
	public float MaxJumpTime = 2f;
	public float JumpSpeed = 3f;
	Transform heroParent = null;
	Animator myanim;
	public LayerMask playerMask;

	public float hurtTime = 2;


	void Awake (){

		lastRabit = this;

	}
	// Use this for initialization
	void Start () {
		this.heroParent = this.transform.parent;
		LevelController.current.SetStartingPosition (transform.position);
		myBody = this.GetComponent<Rigidbody2D>();
		myanim = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		Jump ();
		
	}
	static void SetNewParent(Transform obj, Transform new_parent){
		if (obj.transform.parent != new_parent) {
			Vector3 pos = obj.transform.position;
			obj.transform.parent = new_parent;
			obj.transform.position = pos;
		}


	}

	public void Jump() {
		
		Vector3 from = transform.position + Vector3.up * 0.3f;
		Vector3 to = transform.position + Vector3.down * 0.1f;
		int layer_id = 1 << LayerMask.NameToLayer ("Ground");

		RaycastHit2D hit = Physics2D.Linecast(from, to, layer_id);

		Debug.DrawLine (from, to, Color.red);

		if (hit) {
			isGrounded = true;
			if (hit.transform.GetComponent<MovingPlatform> () != null) {
				SetNewParent (this.transform, hit.transform);
			} else {
				SetNewParent (this.transform, this.heroParent);
			}
		} else {
			isGrounded = false;
		}

		if (this.isGrounded) {
			myanim.SetBool ("jump", false);
		} else
			myanim.SetBool ("jump", true);
		 

		if (Input.GetButtonDown("Jump") && isGrounded) {
			this.JumpActive = true;
		}
			
		int i = 0;

		if (this.JumpActive) {



			if (Input.GetButton("Jump")) {
				
				while (i < 2) {
					i = i + 1;
					this.JumpTime += Time.deltaTime;
					if (this.JumpTime < this.MaxJumpTime) {
						Vector2 vel = myBody.velocity;
						vel.y = JumpSpeed * (1.0f - JumpTime / MaxJumpTime);
						myBody.velocity = vel;

					} else {
						this.JumpActive = false;
						this.JumpTime = 0;
					}

				}
					
				}

		} 

	}
	void Die(){

		GameControllScript.health -= 1;

		if (GameControllScript.health <= 0) {
		
			myanim.SetTrigger ("die");


			myBody.isKinematic = true;
			this.GetComponent<BoxCollider2D> ().enabled = true;


			StartCoroutine (hideMeLater ());
		}


	}

	IEnumerator hideMeLater(){

		yield return new WaitForSeconds (2);
		Application.LoadLevel (Application.loadedLevel);
	}











		/* Animator myanimator = GetComponent<Animator> ();

		myanimator.SetBool("die",true);
		myBody.velocity = Vector2.zero;
		LevelController.current.RabitOnDeath(this); 

*/



	

	void OnCollisionEnter2D (Collision2D collision){

		if (collision.collider.tag == "weapon") {
			Die ();
		}

		if (collision.gameObject.tag == "Orc1") {
			GreenOrc gr_enemy = collision.collider.GetComponent<GreenOrc> ();
			Animator an1 = gr_enemy.GetComponent<Animator> ();
			if (gr_enemy != null) {

				float orc_y = collision.transform.position.y;

				float rabit_y = this.transform.position.y;

				if (orc_y < rabit_y && rabit_y - orc_y > 0.5f) {
					Debug.Log ("Orc is Dead");
					an1.SetTrigger ("orc_die");
					gr_enemy.Die ();

				} else {


					an1.SetTrigger ("attack");
					Die ();


				}
			}
		}


		if (collision.gameObject.tag == "Orc2") {
			BrownOrc br_enemy = collision.collider.GetComponent<BrownOrc> ();
			Animator an2 = br_enemy.GetComponent<Animator> ();
			if (br_enemy != null) {

				float orc_y = collision.transform.position.y;

				float rabit_y = this.transform.position.y;

				if (orc_y < rabit_y && rabit_y - orc_y > 0.5f) {
					Debug.Log ("Orc is Dead");
					an2.SetTrigger ("die");
					br_enemy.Die ();

				} else {


					an2.SetTrigger ("attack2");
					Die ();


				}
			}
		}

	}

		
	void FixedUpdate (){
		
		float value = Input.GetAxis ("Horizontal");
		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
		Animator animatorrab = GetComponent<Animator> ();
	

		if (Mathf.Abs (value) > 0) {
			animatorrab.SetBool("run", true);
			Vector2 vel = myBody.velocity;
			vel.x = value * speed;
			myBody.velocity = vel;
		}
		if (Mathf.Abs (value) == 0) {
			animatorrab.SetBool ("run", false);
		}
		if (value < 0) {
			sr.flipX = true;
		} else if (value > 0) {
			sr.flipX = false;
		}
	}	
}




