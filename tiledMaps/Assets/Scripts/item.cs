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
	private dabloonManager dm;
	//public bool unlocked;
	// Use this for initialization
	void Start () {
        ppm = FindObjectOfType<PlayerPrefManager>();
		dm = FindObjectOfType<dabloonManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!ppm.CheckUnlock (gameObject.name)) {
			unlocked = false;
		} else {
			unlocked = true;
		}
		if (defaultUnlocked) {
			unlocked = true;
		}


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
		if (!equiped && unlocked)
        {
            equiped = true;
            ppm.ChangeSkin(type, gameObject.name);
        }
        else if(!unlocked || !defaultUnlocked)
        {
            purchase();
        }
    }
    private void purchase()
    {
		if (dm.dabloons >= cost) {
			unlocked = true;
			dm.SubtractMoney (cost);
			ppm.unlock(gameObject.name);
			changeSatus ();
		}
    }
}
