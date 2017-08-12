using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class NewAI : MonoBehaviour {

    [Header("Movement")]

    // Where Object Is Going
    public Transform target;

    // Rigidbody for Movement
    private Rigidbody2D rb;

    // Move Speed
    public float speed;

    // Movement Based On Position And Not PathFinding Good For Close Range
    private bool simpleMovement;

    // Refrence To Get New Paths
    private Seeker seeker;

    // Reference To Animator
    private Animator anim;

    // Layers To Ignore
    private int ignore = ~(1 << 10) + ~(1 << 11) + ~(1 << 8) + ~(1 << 12);

    // The path to follow
    public Path path;
	public bool hasPath;
    public float pathRefeshRate;
    private float pathCounter;
    private float counterOffset;

    // Waypoints To Go To
    public int nextPoint;

    [Header("Height Offsets")]

    public float Head;
    public float Feet;

	// Finds To See If can copy path
	private NewAI[] enemies;


	//public ForceMode2D fmode;

	private float LastNodeDistance;
	private float SecondLastDistance;

    // For Lag Management
	//private pathManager pathMan;
    //private bool waitingForPath;



    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        seeker = GetComponent<Seeker>();
        anim = GetComponent<Animator>();
		target = FindObjectOfType<PlayerController> ().gameObject.transform;
		//pathMan = FindObjectOfType<pathManager> ();
        counterOffset = Random.Range(0f, 0.5f);
        pathRefeshRate += counterOffset;
        pathCounter = pathRefeshRate;
        


        enemies = FindObjectsOfType<NewAI> ();
		var closestDistance = 99999999f;
		NewAI closestEnemy = null;
		foreach (NewAI enemy in enemies) {
			if (enemy.gameObject.name != gameObject.name) {
				var playerDistanceFromEnemy = Vector3.Distance (enemy.gameObject.transform.position, target.transform.position);
				var playerDistance = Vector3.Distance (gameObject.transform.position, target.transform.position);
				var enemyDistance = Vector3.Distance (gameObject.transform.position, enemy.gameObject.transform.position);
				if (playerDistanceFromEnemy <= playerDistance && enemy.hasPath && enemyDistance < closestDistance) {
					var hit = Physics2D.Linecast(transform.position, enemy.gameObject.transform.position, ignore);
					if (!hit) {
						closestDistance = enemyDistance;
						closestEnemy = enemy;
					}
				}
			}
		}
		if (closestEnemy != null) {
			path = closestEnemy.path;
			nextPoint = closestEnemy.nextPoint;
			hasPath = true;
			Debug.Log ("Path Came From Existing");
		} else {
			newPath ();
		}
	}
	
	// Update is called once per frame
	void Update () {
        pathCounter -= Time.deltaTime;
        var playerCast = Physics2D.Linecast(transform.position, target.transform.position, ignore);
        if (!playerCast)
        {
            simpleMovement = true;
        }
        else
        {
            simpleMovement = false;
        }

        if (simpleMovement)
        {
            Vector3 fromPosition = transform.position;
            Vector3 toPosition = target.transform.position;
            Vector3 direction = toPosition - fromPosition;
            direction = direction.normalized;
            rb.velocity = direction * speed;
            anim.SetFloat("moveX", direction.x);
            anim.SetFloat("moveY", direction.y);
            return;
        }

        // Only makes One be calculaed at a Time
        if(pathCounter <= 0)
        {
            //waitingForPath = true;
			newPath();
            pathCounter = pathRefeshRate;
            
        }
        //if (waitingForPath)
        //{
		//	if (!pathMan.calculating)
        //    {
		//		pathMan.calculating = true;
        //        newPath();
        //    }
		//	return;
        //}



        // Checks To See If There Is A Next Point. Removes Index Out Of Range Errors
        if(path == null)
        {
            return;
        }


        if(nextPoint >= path.vectorPath.Count)
        {
            rb.velocity = Vector3.zero;
			hasPath = false;
			Debug.Log ("Hit Return");
            return;
        }


		var playerDistanceToLastNode = Vector3.Distance (target.transform.position, path.vectorPath [path.vectorPath.Count-1]);
		var playerDistanceSecondToLastNode = Vector3.Distance (target.transform.position, path.vectorPath [path.vectorPath.Count-2]);
		if (playerDistanceToLastNode - LastNodeDistance >= 1) {
			var wayCast = Physics2D.Linecast (path.vectorPath [path.vectorPath.Count - 1], target.transform.position, ignore);
			if (!wayCast) {
				path.vectorPath.Add (target.transform.position);
			}
		}
		LastNodeDistance = playerDistanceToLastNode;
		SecondLastDistance = playerDistanceSecondToLastNode;

        Vector3 footPosition = transform.position;
        footPosition.y -= Feet;
        Vector3 dir = (path.vectorPath[nextPoint] - footPosition).normalized;
        rb.velocity = dir * speed;
		anim.SetFloat("moveX", dir.x);
		anim.SetFloat("moveY", dir.y);
        if(Vector3.Distance(footPosition, path.vectorPath[nextPoint]) < 0.5f)
        {
            if(nextPoint+1 <= path.vectorPath.Count)
            {
				
                nextPoint++;
            }
        }

        

    }
    private void newPath()
    {
        seeker.StartPath(transform.position, target.position, OnPathComplete);
    }
    private void OnPathComplete(Path p)
    {
		if (path == null) {
			nextPoint = 0;
		} else {
			nextPoint = 1;
		}
		path = p;
		hasPath = true;
		//pathMan.calculating = false;
		Debug.Log ("Path Came From New");
        pathCounter = pathRefeshRate;
    }
}