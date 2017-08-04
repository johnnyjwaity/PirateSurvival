using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneyDrop : MonoBehaviour {
	public GameObject coin;
	public bool test;
	public Transform trans;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (test) {
			drop (trans);
			test = false;
		}
	}
	public void drop(Transform pos){
		var rnum = Random.Range (0, 100);
		int value = 1;
		if (rnum > 95) {
			value = 5;
		} else if (rnum > 85f) {
			value = 4;
		} else if (rnum > 65f) {
			value = 3;
		} else if (rnum > 45f) {
			value = 2;
		}

		GameObject drpCoin = Instantiate (coin ,pos.position, Quaternion.Euler(Vector3.zero));
		drpCoin.GetComponent<GoldPickup> ().value = value;
			
	}
			
}
