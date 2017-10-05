using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tracker : MonoBehaviour {
    public GameObject player;
    public bool playerHere;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.name == "player")
        {
            playerHere = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.name == "player")
        {
            playerHere = false;
        }
    }
}
