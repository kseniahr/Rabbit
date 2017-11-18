using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpBase : MonoBehaviour {
	public MyButton closeButton;
	public MyButton backgroundButton;



	public void Close () {
		NGUITools.Destroy (this.gameObject);
	}
	

	void Start () {
		closeButton.signalOnClick.AddListener (this.Close);
		backgroundButton.signalOnClick.AddListener (this.Close);

	}


}
