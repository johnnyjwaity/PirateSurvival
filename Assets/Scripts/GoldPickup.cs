using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickup : MonoBehaviour {

    public int value;
    private moneyManager mm;
	private Animator anim;
	// Use this for initialization
	void Start () {
        mm = FindObjectOfType<moneyManager>();
		anim = GetComponent<Animator> ();
		anim.SetInteger ("value", value);
	}
	
	// Update is called once per frame
	void Update () {
		//anim.SetInteger ("value", value);
	}
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "player")
        {
            mm.AddMoney(value);
            Destroy(gameObject);
        }
    }
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "player") {
			mm.AddMoney (value);
			Destroy (gameObject);
		}
	}
}
