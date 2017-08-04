using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour {
	public GameObject loadingScreen;
	private AsyncOperation asyncLoad = null;
	public Slider progress;
	public Text percent;
	private bool loading;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (loading) {
			progress.value = asyncLoad.progress;
			percent.text = asyncLoad.progress * 100 + "%";
		}

	}
    public void PlayGame ()
    {
		loadingScreen.SetActive (true);
		asyncLoad = SceneManager.LoadSceneAsync ("map1");
		loading = true;
        
    }

    
}
