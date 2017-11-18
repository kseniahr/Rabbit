using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameStatistics {

	public List<LevelStat> levelStats = new List<LevelStat>();
	public int collectedCoins = 0;

	public static GameStatistics load(){
		GameStatistics stats = JsonUtility.FromJson<GameStatistics>(PlayerPrefs.GetString ("stats", null));
		if (stats == null) {

			return new GameStatistics ();
		}
			return stats;
		

	}

	public void save(){
		string str = JsonUtility.ToJson (this);
		PlayerPrefs.SetString ("stats", str);

	}

}
