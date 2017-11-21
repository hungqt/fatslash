using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public void ToGame() {
		SceneManager.LoadScene ("Fatslash");
	}

	public void ToMenu() {
		SceneManager.LoadScene ("Menu");
	}

	public void ToNextLvl() {
		SceneManager.LoadScene ("Lvl2");
	}
}
