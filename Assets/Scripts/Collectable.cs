using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

	public AudioClip pickupSound = null;
	AudioSource pickupSource = null;

	void Start () {
		pickupSource = gameObject.AddComponent<AudioSource> ();
		pickupSource.clip = pickupSound;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other){

	}

}
