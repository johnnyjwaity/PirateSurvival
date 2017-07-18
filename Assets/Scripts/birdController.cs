using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdController : MonoBehaviour {
    private GameObject player;
    private Rigidbody2D rb;
    public float moveSpeed;
    public float overShoot;
    private float overShootCounter;
    private Vector3 direction;
    private bool reachedOverShoot = true;
    private bool reachedPlayer;
    private float distanceAwayLast;
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>().gameObject;
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (reachedOverShoot)
        {
            Vector3 fromPosition = transform.position;
            Vector3 toPosition = player.transform.position;
            direction = toPosition - fromPosition;
            //direction = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed);
            reachedOverShoot = false;
            direction = direction.normalized;
            float slope = direction.y / direction.x;

            float rotationZ = Mathf.Atan(slope);
            float modifier = 90;
            if (transform.position.x < player.transform.position.x)
            {
                modifier = 270;
            }
            transform.rotation = Quaternion.Euler(0f, 0f, rotationZ * 100 + modifier);
            if (Mathf.Abs(transform.position.x - player.transform.position.x) < 3)
            {
                if (transform.position.y > player.transform.position.y)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 180);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }
            
        }
        rb.velocity = direction*moveSpeed;
        if(reachedPlayer == true)
        {
            overShootCounter -= Time.deltaTime;
            if (overShootCounter <= 0)
            {
                reachedPlayer = false;
                reachedOverShoot = true;
            }
        }
        else
        {
            var distanceAway = Vector3.Distance(transform.position, player.transform.position);
            distanceAwayLast = distanceAway;
            if (distanceAwayLast < distanceAway)
            {
                reachedPlayer = true;
            }

        }
        

	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "player")
        {
            reachedPlayer = true;
            overShootCounter = overShoot;
        }
        else if (collision.name == "Bounds")
        {
            reachedOverShoot = true;
        }
    }
    private void OnBecameInvisible()
    {
        reachedOverShoot = true;
    }
}
