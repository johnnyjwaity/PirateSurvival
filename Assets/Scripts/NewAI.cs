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

    // Waypoints To Go To
    private int nextPoint;

    [Header("Height Offsets")]

    public float Head;
    public float Feet;






    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        seeker = GetComponent<Seeker>();
        anim = GetComponent<Animator>();
        newPath();
	}
	
	// Update is called once per frame
	void Update () {
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

        // Checks To See If There Is A Next Point. Removes Index Out Of Range Errors
        if(nextPoint >= path.vectorPath.Count)
        {
            rb.velocity = Vector3.zero;
            return;
        }

        Vector3 footPosition = transform.position;
        footPosition.y -= Feet;
        Vector3 dir = (path.vectorPath[nextPoint] - footPosition).normalized;
        rb.velocity = dir * speed;

        if(Vector3.Distance(footPosition, path.vectorPath[nextPoint]) < 0.02f)
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
        path = p;
        nextPoint = 0;
    }
}