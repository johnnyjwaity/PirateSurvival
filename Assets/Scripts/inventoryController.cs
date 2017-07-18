using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryController : MonoBehaviour {

    private Image slot;

	// Use this for initialization
	void Start () {
        slot = gameObject.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void clear()
    {
        slot = gameObject.GetComponent<Image>();
        var Color = slot.color;
        Color.a = 0;
        slot.color = Color;

        slot.sprite = null;
    }
    public void insert(Sprite image)
    {
        slot = gameObject.GetComponent<Image>();
        var Color = slot.color;
        Color.a = 1;
        slot.color = Color;

        slot.sprite = image;
    }
}
