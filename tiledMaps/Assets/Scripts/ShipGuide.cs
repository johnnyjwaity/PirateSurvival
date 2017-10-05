using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipGuide : MonoBehaviour {
    public GameObject[] waypoints;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public GameObject nextPoint(GameObject current)
    {
        var index = 0;
        for(int i =0; i<waypoints.Length; i++)
        {
            if(current == waypoints[i])
            {
                index = i;
            }
        }
        index++;
        if(index == 4)
        {
            index = 0;
        }
        return waypoints[index];
    }
}
