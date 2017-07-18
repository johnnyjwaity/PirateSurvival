using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Interact : MonoBehaviour {
    public string type;
    private GameManager theGM;
	// Use this for initialization
	void Start () {
        theGM = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (CrossPlatformInputManager.GetButtonUp("interact"))
        {
            if(type == "shop")
            {
                theGM.ToggleShop();
            }
            
            

        }
    }
}
