using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meeleeManager : MonoBehaviour {
    public int damage;
    public GameObject swing;
	// Use this for initialization
	void Start () {
        swing.GetComponent<hurtEnemy>().damageToGive = damage;
	}
	
	// Update is called once per frame
	void Update () {
        swing.GetComponent<hurtEnemy>().damageToGive = damage;
    }
}
