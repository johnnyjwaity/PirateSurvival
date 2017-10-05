using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour {
    public GameObject[] Windows;
    // Use this for initialization
    public string currentSkin;
	public string currentMeelee;
	public string currentRanged;
    public GameObject skinsPanel;
	public GameObject meeleePanel;
	public GameObject rangedPanel;

	void Start () {
        
        currentSkin = PlayerPrefs.GetString("skin");
		currentMeelee = PlayerPrefs.GetString ("meelee");
		currentRanged = PlayerPrefs.GetString ("ranged");
        skinsPanel.transform.Find(currentSkin).GetComponent<item>().equiped = true;
		meeleePanel.transform.Find (currentMeelee).GetComponent<item> ().equiped = true;
		rangedPanel.transform.Find (currentRanged).GetComponent<item> ().equiped = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ChangeWindow(string windowToOpen)
    {
        skinsPanel.SetActive(false);
		if (windowToOpen == "Skins") {
			skinsPanel.SetActive (true);
			meeleePanel.SetActive (false);
			rangedPanel.SetActive (false);
		} else if (windowToOpen == "Meelee") {
			meeleePanel.SetActive (true);
			rangedPanel.SetActive (false);
			skinsPanel.SetActive (false);
		} else if (windowToOpen == "Ranged") {
			rangedPanel.SetActive (true);
			skinsPanel.SetActive (false);
			meeleePanel.SetActive (false);
		}

    }
}
