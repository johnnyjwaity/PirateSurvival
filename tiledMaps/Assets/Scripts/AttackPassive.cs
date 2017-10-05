using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPassive : MonoBehaviour {

    public float moveSpeed;

    private Rigidbody2D myRigidbody;

    public bool isWalking;

    public float walkTime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;

    private int WalkDirection;
    private int lastWalk;

    private Animator anim;

    public Collider2D walkZone;
    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;
    private bool hasZone;

    public bool canMove;
    private DialogueManager dManager;

    public GameObject attackPassive;
    public GameObject attackMain;
    private Vector3 rotationAttack;
    public GameObject MainCollider;
    public GameObject SecondaryCollider;


	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        dManager = FindObjectOfType<DialogueManager>();

        waitCounter = waitTime;
        walkCounter = walkTime;

        ChooseDirection();

        if(walkZone != null)
        {
            minWalkPoint = walkZone.bounds.min;
            maxWalkPoint = walkZone.bounds.max;
            hasZone = true;
        }

        canMove = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (!dManager.dialogueActive)
        {
            canMove = true;
        }

        if (!canMove)
        {
            myRigidbody.velocity = Vector2.zero;
            return;
        }
        if (isWalking)
        {
            walkCounter -= Time.deltaTime;
           


            switch (WalkDirection)
            {
                case 0:
                    myRigidbody.velocity = new Vector2(0, moveSpeed);
                    anim.SetFloat("MoveX", 0);
                    anim.SetFloat("MoveY", 1);
                    if(hasZone && transform.position.y > maxWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                        anim.SetBool("Walking", false);
                    }
                    break;
                case 1:
                    myRigidbody.velocity = new Vector2(moveSpeed, 0);
                    anim.SetFloat("MoveX", 1);
                    anim.SetFloat("MoveY", 0);
                    if (hasZone && transform.position.x > maxWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                        anim.SetBool("Moving", false);
                    }
                    break;
                case 2:
                    myRigidbody.velocity = new Vector2(0, -moveSpeed);
                    anim.SetFloat("MoveX", 0);
                    anim.SetFloat("MoveY", -1);
                    if (hasZone && transform.position.y < minWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                        anim.SetBool("Moving", false);
                    }
                    break;
                case 3:
                    myRigidbody.velocity = new Vector2(-moveSpeed,0);
                    anim.SetFloat("MoveX", -1);
                    anim.SetFloat("MoveY", 0);
                    if (hasZone && transform.position.x < minWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                        anim.SetBool("Moving", false);
                    }
                    break;
            }
            if (walkCounter < 0)
            {
                isWalking = false;
                waitCounter = waitTime;
                anim.SetBool("Moving", false);
                Instantiate(attackPassive, transform.position, transform.rotation);
                MainCollider.SetActive(false);
                SecondaryCollider.SetActive(true);

            }
        }
        else
        {
            waitCounter -= Time.deltaTime;

            myRigidbody.velocity = Vector2.zero;
            if (waitCounter < 0)
            {
                ChooseDirection();
            }
        }
	}

    public void ChooseDirection()
    {
        WalkDirection = Random.Range(0, 4);
        var sameDistance = true;
        while (sameDistance)
        {
            if(WalkDirection == lastWalk)
            {
                WalkDirection = Random.Range(0, 4);
            }
            else
            {
                sameDistance = false;
            }
        }
        lastWalk = WalkDirection;
        isWalking = true;
        anim.SetBool("Moving", true);
        walkCounter = walkTime;
        
        if(WalkDirection == 0)
        {
            rotationAttack = new Vector3(270, 90, -90);
        }
        else if(WalkDirection == 1)
        {
            rotationAttack = new Vector3(360, 90, -90);
        }
        else if (WalkDirection == 2)
        {
            rotationAttack = new Vector3(90, 90, -90);
        }
        else if (WalkDirection == 3)
        {
            rotationAttack = new Vector3(180, 90, -90);
        }
        (Instantiate(attackMain, transform.position, Quaternion.Euler(rotationAttack))).transform.parent = gameObject.transform;
        MainCollider.SetActive(true);
        SecondaryCollider.SetActive(false);


    }
}
