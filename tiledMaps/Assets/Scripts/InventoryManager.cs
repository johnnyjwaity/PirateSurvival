using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {

    public Dictionary<string, int> inventory = new Dictionary<string, int>();
    public GameObject[] images;

    public inventoryController[] slots;
    public inventoryText[] InvTxt;

	// Use this for initialization
	void Start () {
        //slots = FindObjectsOfType<inventoryController>();
        //InvTxt = FindObjectsOfType<inventoryText>();
        for(int i =0; i<slots.Length; i++)
        {
            slots[i].clear();
            InvTxt[i].clear();
        }
        //inventory.Add("potion", 5);
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(inventory["potion"]);
	}
    public void addToInventory(string key, int addOn)
    {
        if (!inventory.ContainsKey(key))
        {
            inventory.Add(key, 0);
        }

        inventory[key] += addOn;
        Debug.Log(inventory[key]);

    }
    public void TakeFromInventory(string key, int lose)
    {
        if (inventory.ContainsKey(key))
        {
            inventory[key] -= lose;
            Debug.Log(inventory[key]);
            if(inventory[key] <= 0)
            {
                inventory.Remove(key);
            }
        }

        

    }

    public void displayInventory()
    {
        //slots = FindObjectsOfType<inventoryController>();
        //InvTxt = FindObjectsOfType<inventoryText>();
        for (int p = 0; p<slots.Length; p++)
        {
            slots[p].clear();
            InvTxt[p].clear();
        }
        var inventoryLength = inventory.Count;
        List<string> keys = new List<string>(inventory.Keys);
        for (int i = 0; i<inventoryLength; i++)
        {
            for(int r = 0; r<images.Length; r++)
            {
                if(keys[i] == images[r].name)
                {
                    slots[i].insert(images[r].GetComponent<SpriteRenderer>().sprite);
                    InvTxt[i].show(inventory[keys[i]]);
                }
            }
        }
    }
}
