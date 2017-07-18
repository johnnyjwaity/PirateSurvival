using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicSwitch : MonoBehaviour {

    private musicController mc;
    public int newTrack;

    public bool switchOnStart;

	// Use this for initialization
	void Start () {
        mc = FindObjectOfType<musicController>();

        if (switchOnStart)
        {
            mc.switchTrack(newTrack);
            gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "player")
        {
            mc.switchTrack(newTrack);
            gameObject.SetActive(false);
        }
    }
}
