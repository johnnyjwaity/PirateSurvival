using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class item : MonoBehaviour {
    private PlayerPrefManager ppm;
    private bool unlocked;
    public int cost;
    public bool defaultUnlocked;
    public Text buttonText;
    public bool equiped;
    public string type;
	// Use this for initialization
	void Start () {
        ppm = FindObjectOfType<PlayerPrefManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (equiped)
        {
            buttonText.text = "Equiped";
            gameObject.GetComponent<Image>().color = Color.green;
            if(ppm.currentEquip(type) != gameObject.name)
            {
                equiped = false;
            }
        }
        else if(unlocked || defaultUnlocked)
        {
            buttonText.text = "Equip";
            gameObject.GetComponent<Image>().color = Color.white;
        }
        else if (!unlocked || !defaultUnlocked)
        {
            buttonText.text = "Pay "+cost;
            gameObject.GetComponent<Image>().color = Color.red;
        }
	}
    public void changeSatus()
    {
        if (!equiped)
        {
            equiped = true;
            ppm.ChangeSkin(gameObject.name);
        }
        else if(!unlocked || !defaultUnlocked)
        {
            purchase();
        }
    }
    private void purchase()
    {

    }
}
