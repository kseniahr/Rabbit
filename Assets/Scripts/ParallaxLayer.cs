using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxLayer : MonoBehaviour {


	public float[] slowdown;
	Vector3 last_position;
	private Transform cam;
	public Transform[] backgrounds;
	public float smoothing = 1f;



	void Awake () {
		cam = Camera.main.transform;
	}

	void Start (){
		last_position = cam.position;
		slowdown = new float [backgrounds.Length];

		for (int i = 0; i < backgrounds.Length; i++){
			slowdown[i] = backgrounds[i].position.z * -1;

		}


	}
	
	// Update is called once per frame
	void LateUpdate () {
		for (int i = 0; i < backgrounds.Length; i++){
			slowdown[i] = backgrounds[i].position.z * -1;
			float parallax = (last_position.x - cam.position.x) * slowdown[i];
			float background_pos_x = backgrounds[i].position.x + parallax;
			Vector3 backgroungTargetPos = new Vector3 (background_pos_x, backgrounds[i].position.y, backgrounds[i].position.z);
			backgrounds[i].position = Vector3.Lerp(backgrounds [i].position, backgroungTargetPos, smoothing * Time.deltaTime);

				}
		last_position = cam.position;



	}
}
