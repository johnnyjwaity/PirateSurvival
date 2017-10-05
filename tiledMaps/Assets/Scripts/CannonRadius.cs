using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CannonRadius : MonoBehaviour {
    public CannonController cc;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            if (CrossPlatformInputManager.GetButtonUp("interact"))
            {
                Debug.Log("Cannon Fired");
                cc.Attack();

            }
        }
    }
}
