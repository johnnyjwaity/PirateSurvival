using UnityEngine;
using System.Collections;

public class MovingShuriken6 : MonoBehaviour {

	public float _x, _y, _z;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (_x,_y,_z);
	}
}
