using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreUpdate : MonoBehaviour {

	public Text scoreTxt;

	void Start() {
		Debug.Log(PlayerPrefs.GetInt("Score"));
		scoreTxt.text = "Your score: " + PlayerPrefs.GetInt("Score");
	}
}
