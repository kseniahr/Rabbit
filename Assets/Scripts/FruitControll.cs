using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitControll : MonoBehaviour {

	public static FruitControll current;

	public HashSet<int> collectedFruits;

	public UILabel fruitsLabel;

	public int totalFruits = 6;

	public void addFruit(int fruitId){
		this.collectedFruits.Add (fruitId);
		Debug.Log ("added to list fruits with id" + fruitId.ToString());
	}



	void Start () {

		LevelStat stat = LevelStat.load (LevelController.current.mylevel);
		collectedFruits = new HashSet<int> (stat.collected_fruits);

	}
	
	// Update is called once per frame
	void Awake () {
		current = this;
	}

	void Update(){
		
		fruitsLabel.text = this.collectedFruits.Count.ToString () + " / 6";

	}


}
