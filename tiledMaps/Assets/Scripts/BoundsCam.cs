using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsCam : MonoBehaviour {

    private BoxCollider2D bounds;
    private CameraController theCam;

	// Use this for initialization
	void Start () {
        bounds = GetComponent<BoxCollider2D>();
        theCam = FindObjectOfType<CameraController>();
        theCam.Setbounds(bounds);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
