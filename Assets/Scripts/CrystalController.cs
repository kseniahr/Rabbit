using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalController : MonoBehaviour {


	public GameObject blue, green, red;

	public static int crystals_blue;
	public static int crystals_red;
	public static int crystals_green;

	void Start () {
		blue.gameObject.SetActive (true);
		green.gameObject.SetActive (true);
		red.gameObject.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		if (crystals_red >= 1) {
			red.gameObject.SetActive (false);



		}

		if (crystals_blue >= 1) {
			blue.gameObject.SetActive (false);



		}
		if (crystals_green >= 1) {
			green.gameObject.SetActive (false);



		}
	}
}
