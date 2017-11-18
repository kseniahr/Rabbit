using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


[System.Serializable]
public class LevelStat { 

	public int mylevel;
	public bool levelpassed = false;
	public int totalfruits = -1;
	public int collectedCoins = 0;
	public List<int> collected_fruits = new List<int>();
	public List<int> collected_crystals = new List<int>();
	public bool allFruitsCollected;
	public bool allCrystalsCollected;

	public void Save(){

		GameStatistics stats = GameStatistics.load ();
		LevelStat found = stats.levelStats.Find (p => p.mylevel == mylevel);
		if (found != null) {
			stats.levelStats.Remove (found);
			stats.levelStats.Add (this);
			stats.collectedCoins = collectedCoins;
			stats.save ();


		}
	}

	public static LevelStat load(int level){
		GameStatistics stats = GameStatistics.load ();
		int templevel = level;
		LevelStat found = stats.levelStats.Find (p => p.mylevel == templevel);
		found = found != null ? found : new LevelStat { mylevel = templevel };
		found.collectedCoins = stats.collectedCoins;

		return found;


	}


}
