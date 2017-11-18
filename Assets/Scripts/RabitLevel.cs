using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RabitLevel : MonoBehaviour {
	
	public float speed = 3;
	Rigidbody2D myBody = null;
	bool isGrounded = true;
	bool JumpActive = false;
	float JumpTime = 0f;
	public float MaxJumpTime = 2f;
	public float JumpSpeed = 3f;

	Animator myanim;
	public LayerMask playerMask;

	public float hurtTime = 2;


	// Use this for initialization
	void Start () {
		
		LevelController.current.SetStartingPosition (transform.position);
		myBody = this.GetComponent<Rigidbody2D>();
		myanim = this.GetComponent<Animator> ();
		
	}

	// Update is called once per frame
	void Update () {
		Jump ();

	}

	public void Jump() {

		Vector3 from = transform.position + Vector3.up * 0.3f;
		Vector3 to = transform.position + Vector3.down * 0.1f;
		int layer_id = 1 << LayerMask.NameToLayer ("Ground");

		RaycastHit2D hit = Physics2D.Linecast(from, to, layer_id);

		Debug.DrawLine (from, to, Color.red);

		if (hit) {
			isGrounded = true;

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



	void OnCollisionEnter2D (Collision2D collision){

		if (collision.collider.tag == "door1") {
			SceneManager.LoadScene ("1");
		}

		if (collision.collider.tag == "door2") {
			SceneManager.LoadScene ("2");
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




