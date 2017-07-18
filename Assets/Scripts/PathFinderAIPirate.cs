using UnityEngine;
using System.Collections;
//Note this line, if it is left out, the script won't know that the class 'Path' exists and it will throw compiler errors
//This line should always be present at the top of scripts which use pathfinding
using Pathfinding;

public class PathFinderAIPirate : MonoBehaviour
{
    //The point to move to
    public Transform target;

    private Seeker seeker;

    //The calculated path
    public Path path;

    //The AI's speed per second
    public float speed = 2;

    //The max distance from the AI to a waypoint for it to continue to the next waypoint
    public float nextWaypointDistance = 3;

    //The waypoint we are currently moving towards
    private int currentWaypoint = 0;

    public float pathRefreshRate;
    public float closeRefreshRate;
    private float currentRefresh;
    private float pathCounter;

	private GameObject player;
	private Rigidbody2D rb;
	public float moveSpeed;
	public float rateOfAttack;

	private float moveX;
	private float moveY;

	private Animator anim;

	public string type;
	public barrel gunBarrel;
	public GameObject gunSmoke;
	public GameObject gunFire;
	public GameObject bulletObj;

    public void Start()
    {
		player = FindObjectOfType<PlayerController>().gameObject;
        seeker = GetComponent<Seeker>();
		target = player.transform;
        //Start a new path to the targetPosition, return the result to the OnPathComplete function
        seeker.StartPath(transform.position, target.position, OnPathComplete);
        currentRefresh = pathRefreshRate;
        pathCounter = currentRefresh;



		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
    }

    public void OnPathComplete(Path p)
    {
        Debug.Log("Yay, we got a path back. Did it have an error? " + p.error);
        if (!p.error)
        {
            path = p;
            //Reset the waypoint counter
            currentWaypoint = 0;
        }
    }
    public void changePath()
    {
        seeker.StartPath(transform.position, target.position, OnPathComplete);
    }
    private void Update()
    {
        
        if(target == null)
        {
            target = FindObjectOfType<PlayerController>().gameObject.transform;
        }
    }
    public void FixedUpdate()
    {
        if (path == null)
        {
            //We have no path to move after yet
            return;
        }
        pathCounter -= Time.deltaTime;
        if (pathCounter <= 0)
        {
            //changePath();
            pathCounter = currentRefresh;
            
        }
        


        if (currentWaypoint >= path.vectorPath.Count)
        {
            Debug.Log("End Of Path Reached");
            changePath();
        }

        //Direction to the next waypoint
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        dir *= speed*Time.deltaTime;
        //this.gameObject.transform.Translate(dir);
        //rb.velocity = dir;
        rb.velocity = dir;

        //Check if we are close enough to the next waypoint
        //If we are, proceed to follow the next waypoint
        if (Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]) < nextWaypointDistance)
        {
            if (path.vectorPath[currentWaypoint + 1] != null)
            {
                
                currentWaypoint++;
            }
            
            

        }
		// Animations
		moveX = 0;
		moveY = 0;

		if (path.vectorPath[currentWaypoint].x > gameObject.transform.position.x)
		{
			moveX = 1;

		}
		else if (path.vectorPath[currentWaypoint].x < gameObject.transform.position.x)
		{
			moveX = -1;
		}


		if (path.vectorPath[currentWaypoint].y > gameObject.transform.position.y)
		{
			moveY = 1;

		}
		else if (path.vectorPath[currentWaypoint].y < gameObject.transform.position.y)
		{
			moveY = -1;
		}

		if(Mathf.Abs(target.transform.position.x - gameObject.transform.position.x) > Mathf.Abs(target.transform.position.y - gameObject.transform.position.y))
		{
			//anim.SetFloat("moveX", 1*moveX);
			//anim.SetFloat("moveY", 0);
		}
		else
		{
			//anim.SetFloat("moveX", 0);
			//anim.SetFloat("moveY", 1*moveY);
		}
        anim.SetFloat("moveX", dir.x);
        anim.SetFloat("moveY", dir.y);
        Vector3 fromPosition = transform.position;
        Vector3 toPosition = player.transform.position;
        Vector3 direction = toPosition - fromPosition;
        //RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, direction);
        
        //Debug.DrawRay(transform.position, direction, Color.green);
        var UseOldScript = false;
        Debug.DrawLine(transform.position, player.transform.position, Color.blue);
        var ignore = ~(1 << 10) + ~(1 << 11) + ~(1 << 8) + ~(1 << 12);
        var hit = Physics2D.Linecast(transform.position, player.transform.position, ignore);
        if(!hit)
        {
            UseOldScript = true;
            rb.bodyType = RigidbodyType2D.Dynamic;
            path = null;
        }
        
        //for(int i = 0; i<hit.Length; i++)
        //{
        //    if(hit[i].collider.tag == "obstacle")
        //    {
        //        UseOldScript = false;
        //        Debug.Log("False For: " + gameObject.name + " It Hit: " + hit[i].collider.gameObject.name, hit[i].collider.gameObject);
        //   }
        //}
        if (UseOldScript)
        {
            gameObject.GetComponent<FollowAI>().enabled = true;
            this.enabled = false;
        }






    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
        if(collision.name == "FasterRadius")
        {
            currentRefresh = closeRefreshRate;
            pathCounter = currentRefresh;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "FasterRadius")
        {
            currentRefresh = pathRefreshRate;
            pathCounter = currentRefresh;
        }

    }
	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.name == "player")
		{
			anim.SetTrigger("Attack");

		}



	}
	public void shoot()
	{
		if (type == "gun")
		{
			GameObject smoke = Instantiate(gunSmoke, gunBarrel.transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
			var lastX = anim.GetFloat("moveX");
			var lastY = anim.GetFloat("moveY");
			if (lastX >= 0.5)
			{
				GameObject fire = Instantiate(gunFire, gunBarrel.transform.position, Quaternion.Euler(new Vector3(0, 90, -90)));

			}
			else if (lastX <= -0.5)
			{
				GameObject fire = Instantiate(gunFire, gunBarrel.transform.position, Quaternion.Euler(new Vector3(-180, 90, -90)));

			}
			else if (lastY >= 0.5)
			{
				GameObject fire = Instantiate(gunFire, gunBarrel.transform.position, Quaternion.Euler(new Vector3(-90, 180, -180)));

			}
			else if (lastY <= -0.5)
			{
				GameObject fire = Instantiate(gunFire, gunBarrel.transform.position, Quaternion.Euler(new Vector3(-270, -90, -270)));

				Debug.Log("Fired Down");


			}

			var clone = Instantiate(bulletObj, transform.position, transform.rotation);
			var cloneRigid = clone.GetComponent<Rigidbody2D>();
			cloneRigid.velocity = (GameObject.Find("player").transform.position - transform.position).normalized * 20;


		}
	}
}