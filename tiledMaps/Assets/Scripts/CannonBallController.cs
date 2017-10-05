using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallController : MonoBehaviour {
    public Vector3 direction;
    public float speed;
    private Animator anim;
    private bool move = true;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        
        
	}
	
	// Update is called once per frame
	void Update () {
        if (move)
        {
            transform.position += direction*Time.deltaTime*speed;
        }
        
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
		if(collision.gameObject.name != "Collision" && collision.gameObject.name != "Bounds" && collision.gameObject.tag != "radius" && collision.gameObject.tag != "cannonBall")
        {
            anim.SetTrigger("Explode");
            move = false;
            Destroy(gameObject, 0.5f);
            Debug.Log("Cannon Hit: " + collision.gameObject.name);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.gameObject.name != "Collision" && collision.gameObject.name != "Bounds" && collision.gameObject.tag != "radius" && collision.gameObject.tag != "cannonBall")
        {
            anim.SetTrigger("Explode");
            move = false;
            Destroy(gameObject, 0.5f);
            Debug.Log("Cannon Hit: "+collision.gameObject.name);

        }
    }
}
