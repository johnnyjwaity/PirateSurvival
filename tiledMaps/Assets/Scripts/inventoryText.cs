using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryText : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void clear()
    {
        var Color = gameObject.GetComponent<Text>().color;
        Color.a = 0;
        gameObject.GetComponent<Text>().color = Color;
    }
    public void show(int quantity)
    {
        var Color = gameObject.GetComponent<Text>().color;
        Color.a = 1;
        gameObject.GetComponent<Text>().color = Color;
        gameObject.GetComponent<Text>().text = "x" + quantity;

    }
}
