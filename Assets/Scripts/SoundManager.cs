using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager {
	bool is_sound_on = true;

	public bool isSoundOn(){
		return this.is_sound_on;

	}


	public void SetSoundOn(bool val){

		this.is_sound_on = val;
		PlayerPrefs.SetInt ("background_music", this.is_sound_on ? 1 : 0);
		PlayerPrefs.Save();

	}

	SoundManager (){
		is_sound_on = PlayerPrefs.GetInt ("background_music", 1) == 1;

	}

	public static SoundManager Instance = new SoundManager();
}
