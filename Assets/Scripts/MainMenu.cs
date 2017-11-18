using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class MainMenu : MonoBehaviour {

	public void ChangeScene (string sceneName ){

		SceneManager.LoadScene (sceneName);
	}

}
