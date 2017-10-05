using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moneyManager : MonoBehaviour {

    public Text moneyText;
    public int currentGold;

	// Use this for initialization
	void Start () {

		currentGold = 0;

        moneyText.text = "Gold: " + currentGold;

	}
	
	// Update is called once per frame
	void Update () {
		moneyText.text = "Gold: " + currentGold;
	}
    public void AddMoney (int goldToAdd)
    {
        currentGold += goldToAdd;
        moneyText.text = "Gold: " + currentGold;
    }
    public void SubtractMoney(int goldToLose)
    {
        currentGold -= goldToLose;
        moneyText.text = "Gold: " + currentGold;
    }
}
