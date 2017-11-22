using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public void ToGame() {
		PlayerPrefs.SetInt ("Score", 0);
		SceneManager.LoadScene ("Fatslash");
	}

	public void ToMenu() {
		PlayerPrefs.SetInt ("Score", 0);
		SceneManager.LoadScene ("Menu");
	}

	public void ToNextLvl() {
		PlayerPrefs.SetInt ("Score", 0);
		SceneManager.LoadScene ("Lvl2");
	}
}
