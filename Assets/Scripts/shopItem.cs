using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopItem : MonoBehaviour {
    public int levelAccesed;
    public int cost;

    public string key;
    

    private playerStats stats;
    private moneyManager mm;
    private InventoryManager im;

	// Use this for initialization
	void Start () {
        stats = FindObjectOfType<playerStats>();
        mm = FindObjectOfType<moneyManager>();
        im = FindObjectOfType<InventoryManager>();
        if (stats.currentLevel < levelAccesed)
        {
            //gameObject.SetActive(false);
            gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            //gameObject.SetActive(true);
            gameObject.GetComponent<Button>().interactable = true;
        }

	}
	
	// Update is called once per frame
	void Update () {
        /*if (stats.currentLevel < levelAccesed)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }*/
    }
    public void BuyItem()
    {
        if (mm.currentGold >= cost)
        {
            mm.SubtractMoney(cost);
            im.addToInventory(key, 1);
        }
        

        
    }
    public void checkItem()
    {
        stats = FindObjectOfType<playerStats>();
        if (stats.currentLevel < levelAccesed)
        {

            //gameObject.SetActive(false);
            gameObject.GetComponent<Button>().interactable = false;
            Debug.Log("Set to false");
        }
        else
        {
            //gameObject.SetActive(true);
            gameObject.GetComponent<Button>().interactable = true;
            Debug.Log("Set To True");
        }
    }
}
