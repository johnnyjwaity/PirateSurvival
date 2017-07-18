using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour {
	public GameObject loadingScreen;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    public void PlayGame ()
    {
		loadingScreen.SetActive (true);
		
        SceneManager.LoadScene("map1");
    }

    
}
