using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour {

	public int lastScore;
	public int highScore;

	public Text lastScoreText;
	public Text highScoreText;

	// Use this for initialization
	void Start () {
		if (!PlayerPrefs.HasKey ("lastScore")) {
			PlayerPrefs.SetInt ("lastScore", 0);
		}
		if (!PlayerPrefs.HasKey ("highScore")) {
			PlayerPrefs.SetInt ("highScore", 0);
		}

		lastScore = PlayerPrefs.GetInt ("lastScore");
		highScore = PlayerPrefs.GetInt ("highScore");

		if (lastScore > highScore) {
			PlayerPrefs.SetInt ("highScore", lastScore);
			highScore = lastScore;
		}


		lastScoreText.text = "Last Score: " + lastScore;
		highScoreText.text = "High Score: " + highScore;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
