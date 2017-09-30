using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	public float speed;
	public Vector3 moveBy;
	Vector3 pointA;
	Vector3 pointB;
	public bool reverse;
	private float start_time;
	private float distance;
	public float timetowait;
	Vector3 target;


	// Use this for initialization
	void Start () {
		start_time = Time.time;
		this.pointA = this.transform.position;
		this.pointB = this.pointA + moveBy;
		distance = Vector3.Distance (pointA, pointB);
	}


	// Update is called once per frame
	void Update ()
	{
		/*	Vector3 my_pos = this.transform.position;



		Vector3 destination = target - my_pos;
		destination.z = 0;
		timetowait -= Time.deltaTime;

		float distCovered = (Time.time - start_time) * speed;
		float fracJourney = distCovered / distance;

		if (timetowait <= 0) {
			if (arrived) {
				target = this.pointA;

			} else {
				target = this.pointB;


			}

			transform.position = Vector3.Lerp (target, my_pos, fracJourney);


		}
			*/



















	 float distCovered = (Time.time - start_time) * speed;
		float fracJourney = distCovered / distance;

	
		if (reverse) {
			transform.position = Vector3.Lerp (pointB, pointA, fracJourney);
				

		} else {
			transform.position = Vector3.Lerp (pointA, pointB, fracJourney);
		}
				

		
		if ((Vector3.Distance (transform.position, pointB) < 0.02f || Vector3.Distance (transform.position, pointA) < 0.02f)) {	
				
			if (reverse) {
				reverse = false;
			} else {
				
				reverse = true;
			}

			start_time = Time.time;
		} 
	
				
			

	
	}
}