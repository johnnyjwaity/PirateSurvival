using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPrefManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (!PlayerPrefs.HasKey("skin"))
        {
            PlayerPrefs.SetString("skin", "male");

        }

		if (!PlayerPrefs.HasKey ("meelee")) {
			PlayerPrefs.SetString ("meelee", "basicSword");
		}
		if (!PlayerPrefs.HasKey ("ranged")) {
			PlayerPrefs.SetString ("ranged", "basicPistol");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ChangeSkin(string type, string name)
    {
		PlayerPrefs.SetString(type, name);
        PlayerPrefs.Save();
    }
    public bool CheckUnlock(string key)
    {
        if (!PlayerPrefs.HasKey(key))
        {
            PlayerPrefs.SetInt(key, 0);
        }

        var unlocked = PlayerPrefs.GetInt(key);
        if(unlocked == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public string currentEquip(string type)
    {
        return PlayerPrefs.GetString(type);
    }
}
