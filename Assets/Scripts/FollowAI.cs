using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAI : MonoBehaviour
{

    public GameObject target;
    public GameObject player;

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

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
        target = player;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(target == null)
        {
            if(player == null)
            {
                return;
            }
            else
            {
                target = player;
            }
            
        }
        moveX = 0;
        moveY = 0;

        if (target.transform.position.x > gameObject.transform.position.x)
        {
            moveX = 1;

        }
        else if (target.transform.position.x < gameObject.transform.position.x)
        {
            moveX = -1;
        }

        
        if (target.transform.position.y > gameObject.transform.position.y)
        {
           moveY = 1;

        }
        else if (target.transform.position.y < gameObject.transform.position.y)
        {
            moveY = -1;
        }

        if(Mathf.Abs(target.transform.position.x - gameObject.transform.position.x) > Mathf.Abs(target.transform.position.y - gameObject.transform.position.y))
        {
            anim.SetFloat("moveX", 1*moveX);
            anim.SetFloat("moveY", 0);
        }
        else
        {
            anim.SetFloat("moveX", 0);
            anim.SetFloat("moveY", 1*moveY);
        }

        //anim.SetFloat("moveX", moveX);
        //anim.SetFloat("moveY", moveY);
        rb.velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);

        Vector3 fromPosition = transform.position;
        Vector3 toPosition = player.transform.position;
        Vector3 direction = toPosition - fromPosition;
        var UseOldScript = false;
        Debug.DrawLine(transform.position, player.transform.position, Color.blue);
        var ignore = ~(1 << 10) + ~(1 << 11) + ~(1 << 8) + ~(1 << 12);
        var hit = Physics2D.Linecast(transform.position, player.transform.position, ignore);
        if (hit)
        {
            UseOldScript = true;
        }
        if (UseOldScript)
        {
            gameObject.GetComponent<PathFinderAIPirate>().enabled = true;
            gameObject.GetComponent<PathFinderAIPirate>().changePath();
            this.enabled = false;
            rb.bodyType = RigidbodyType2D.Kinematic;
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
