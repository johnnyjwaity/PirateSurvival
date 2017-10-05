using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleDabloonDisplay : MonoBehaviour {

	public bool openCommand;
	public GameObject dabloonDisplay;



	// Use this for initialization
	void Start () {
		if (openCommand) {
			dabloonDisplay.SetActive (true);
			openCommand = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
