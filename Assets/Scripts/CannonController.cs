using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CannonController : MonoBehaviour {
    public GameObject CannonBall;
    public GameObject barrel;
    public GameObject CannonTip;
    private Animator anim;
    public GameObject explosion;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    public void Attack()
    {
        GameObject Ball = Instantiate(CannonBall, barrel.transform.position, Quaternion.Euler(Vector3.zero));
        Vector3 direction = transform.up;
        Ball.GetComponent<CannonBallController>().direction = direction * -1;
        anim.SetTrigger("Attack");
        GameObject explos =  Instantiate(explosion, CannonTip.transform.position, Quaternion.Euler(new Vector3(transform.rotation.z+90, -90, -90)));
        var directionRotate = transform.rotation.z;
        directionRotate*=100;
        directionRotate += 90;
        Debug.Log(directionRotate);
        explos.transform.rotation = Quaternion.Euler(directionRotate,-90,-90);
    }

}
