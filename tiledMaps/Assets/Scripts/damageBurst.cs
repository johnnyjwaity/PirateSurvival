using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageBurst : MonoBehaviour {
    private SFXManager sfx;
    // Use this for initialization
    void Start () {
        sfx = FindObjectOfType<SFXManager>();
        sfx.impact.Play();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
