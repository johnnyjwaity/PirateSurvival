using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour {
    public GameObject[] Windows;
    // Use this for initialization
    public string currentSkin;
    public GameObject skinsPanel;

	void Start () {
        
        currentSkin = PlayerPrefs.GetString("skin");
        skinsPanel.transform.Find(currentSkin).GetComponent<item>().equiped = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ChangeWindow(string windowToOpen)
    {
        skinsPanel.SetActive(false);
        if(windowToOpen == "Skins")
        {
            skinsPanel.SetActive(true);
        }

    }
}
