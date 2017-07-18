using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickup : MonoBehaviour {

    public int value;
    private moneyManager mm;

	// Use this for initialization
	void Start () {
        mm = FindObjectOfType<moneyManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "player")
        {
            mm.AddMoney(value);
            Destroy(gameObject);
        }
    }
}
