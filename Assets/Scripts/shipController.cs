using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipController : MonoBehaviour {
    public GameObject currentWaypoint;
    private ShipGuide shipManager;
    public GameObject start;
    private Rigidbody2D rb;
    public float speed;
    private Vector3 fromPosition;
    private Vector3 toPosition;
    private Vector3 direction;
    private bool FindNewDirection;
    public GameObject cannonball;
    public GameObject cannonSpawn;
    public float attackRate;
    private float attackRateCounter;

    // Use this for initialization
	void Start () {
        currentWaypoint = start;
        shipManager = FindObjectOfType<ShipGuide>();
        
        rb = GetComponent<Rigidbody2D>();
        FindNewDirection = true;
        attackRateCounter = attackRate;
	}
	
	// Update is called once per frame
	void Update () {
        if (FindNewDirection)
        {
            currentWaypoint = shipManager.nextPoint(currentWaypoint);
            fromPosition = transform.position;
            toPosition = currentWaypoint.transform.position;
            direction = toPosition - fromPosition;
            direction = direction.normalized;
            FindNewDirection = false;
            if(currentWaypoint.name == "Way0")
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
            }
            else if (currentWaypoint.name == "Way1")
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
            }
            else if (currentWaypoint.name == "Way2")
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 270));
            }
            else if (currentWaypoint.name == "Way3")
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            }




        }


        rb.velocity = direction * speed;
        attackRateCounter -= Time.deltaTime;
        if(attackRateCounter < 0)
        {
            attackRateCounter = attackRate;
            Attack();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "waypoint")
        {
            FindNewDirection = true;
            Debug.Log("ShipHasLanded");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "waypoint")
        {
            FindNewDirection = true;
            Debug.Log("ShipHasLanded");
        }
    }
    private void Attack()
    {
        GameObject ball = Instantiate(cannonball, cannonSpawn.transform.position, transform.rotation);
        
        if (currentWaypoint.name == "Way0")
        {
            ball.GetComponent<CannonBallController>().direction = Vector3.down;
        }
        else if (currentWaypoint.name == "Way1")
        {
            ball.GetComponent<CannonBallController>().direction = Vector3.right;
        }
        else if (currentWaypoint.name == "Way2")
        {
            ball.GetComponent<CannonBallController>().direction = Vector3.up;
        }
        else if (currentWaypoint.name == "Way3")
        {
            ball.GetComponent<CannonBallController>().direction = Vector3.left;
        }
    }
}
