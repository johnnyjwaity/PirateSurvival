using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dabloonManager : MonoBehaviour {

	public int dabloons;
	private Text dabloonDisplay;
	// Use this for initialization
	void Start () {
		dabloonDisplay = GetComponent<Text> ();
		if (!PlayerPrefs.HasKey ("dabloons")) {
			PlayerPrefs.SetInt ("dabloons", 0);
		}

		dabloons = PlayerPrefs.GetInt ("dabloons");
	}
	
	// Update is called once per frame
	void Update () {
		dabloonDisplay.text = "" + dabloons;
	}
	public void AddMoney(int amount){
		dabloons += amount;
		PlayerPrefs.SetInt ("dabloons", dabloons);
		PlayerPrefs.Save ();
	}
	public void SubtractMoney(int amount){
		dabloons -= amount;
		PlayerPrefs.SetInt ("dabloons", dabloons);
		PlayerPrefs.Save ();
	}
}
