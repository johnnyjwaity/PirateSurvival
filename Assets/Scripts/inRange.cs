using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inRange : MonoBehaviour {
	public PathFinderAIPirate pirate;
    private float Counter;

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
            if (Counter <= 0)
            {
                pirate.shoot();
                Counter = pirate.rateOfAttack;
            }
            Counter -= Time.deltaTime;
        }
        

    }
}
