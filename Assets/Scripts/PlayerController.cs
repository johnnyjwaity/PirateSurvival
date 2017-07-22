using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {
	public float moveSpeed;
    private float currentMoveSpeed;
    //public float diaganolMove;

    public bool gun;
    public GameObject weapon;
    public GameObject GunObj;
    public barrel gunBarrel;
    public GameObject gunSmoke;
    public GameObject gunFire;
    public GameObject bulletObj;


	private Animator anim;
    public bool playerMoving;
    public Vector2 lastMove;

    private Vector2 moveInput;

    private Rigidbody2D myRigidbody;
    private static bool playerExists;

    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;

    public string startPoint;

    public bool knockback;
    public float knockbackCounter;
    public float KnockbackPower;
    public float knockbackSpeed;

    public float HitX;
    public float HitY;

    public bool canMove;

    private SFXManager sfx;

    public float xAxis;
    public float yAxis;

	public bool joystick;

    


	// Use this for initialization
	void Start () {
        lastMove = new Vector2(0, -1);
		anim = GetComponent<Animator> ();
        myRigidbody = GetComponent<Rigidbody2D>();
        sfx = FindObjectOfType<SFXManager>();

        if(!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        } else
        {
            Destroy(gameObject);
        }
        knockbackCounter = KnockbackPower;
        canMove = true;

        
	}
	
	// Update is called once per frame
	void Update () {

        transform.position += Vector3.zero;
        playerMoving = false;

        if (!canMove)
        {
            myRigidbody.velocity = Vector2.zero;
            
        }

        if (!attacking && !knockback && canMove)
        {

            /*if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                //transform.Translate (new Vector3 (Input.GetAxisRaw ("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
                myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * currentMoveSpeed, myRigidbody.velocity.y);
                playerMoving = true;
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            }

            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
                //transform.Translate (new Vector3 (0f, Input.GetAxisRaw ("Vertical") * moveSpeed * Time.deltaTime, 0f));
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * currentMoveSpeed);
                playerMoving = true;
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            }

            if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
            {
                myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);

            }

            if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);

            }*/

            moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
            //moveInput = new Vector2(CrossPlatformInputManager.GetAxisRaw("Horizontal"), CrossPlatformInputManager.GetAxisRaw("Vertical"));
			if (!joystick) {
				var up = false;
				var down = false;
				var left = false;
				var right = false;

				if (CrossPlatformInputManager.GetButton("up"))
				{
					yAxis = 1;
					up = true;
				}
				else
				{
					up = false;
				}

				if (CrossPlatformInputManager.GetButton("down"))
				{
					yAxis = -1;
					down = true;
				}
				else
				{
					down = false;
				}
				if (CrossPlatformInputManager.GetButton("left"))
				{
					xAxis = -1;
					left = true;
				}
				else
				{
					left = false;
				}
				if (CrossPlatformInputManager.GetButton("right"))
				{
					xAxis = 1;
					right = true;
				}
				else
				{
					right = false;
				}

				if(!right && !left)
				{
					xAxis = 0;
				}
				if(!up && !down)
				{
					yAxis = 0;
				}

				moveInput = new Vector2(xAxis, yAxis);
			}
			if (joystick) {
				var joyX = CrossPlatformInputManager.GetAxisRaw ("Horizontal1");
				var joyY = CrossPlatformInputManager.GetAxisRaw ("Vertical1");
				if (joyX > 0.5) {
					joyX = 1;
				} else if (joyX < -0.5) {
					joyX = -1;
				} else {
					joyX = 0;
				}
				if (joyY > 0.5) {
					joyY = 1;
				} else if (joyY < -0.5) {
					joyY = -1;
				} else {
					joyY = 0;
				}
				moveInput = new Vector2 (CrossPlatformInputManager.GetAxisRaw("Horizontal1"), CrossPlatformInputManager.GetAxisRaw("Vertical1")).normalized;

			}
				
            
            if (moveInput != Vector2.zero)
            {
                myRigidbody.velocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
                playerMoving = true;
                lastMove = moveInput;
            }
            else
            {
                myRigidbody.velocity = Vector2.zero;
                playerMoving = false;
            }


            if (CrossPlatformInputManager.GetButton("Swing"))
            {
                attackTimeCounter = attackTime;
                attacking = true;
                myRigidbody.velocity = Vector2.zero;
                anim.SetBool("Attack", true);
                sfx.playerAttack.Play();
            }

            if (CrossPlatformInputManager.GetButton("Shoot") || Input.GetKeyUp("f"))
            {
                //gunBarrel = FindObjectOfType<barrel>();
                attackTimeCounter = attackTime;
                attacking = true;
                myRigidbody.velocity = Vector2.zero;
                anim.SetBool("Gun", true);
                anim.SetTrigger("Gun 0");
            
                //anim.SetBool("Attack", true);
                GameObject smoke = Instantiate(gunSmoke, gunBarrel.transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
                var lastX = anim.GetFloat("LastMoveX");
                var lastY = anim.GetFloat("LastMoveY");
                if(!playerMoving || !joystick)
                {
                    if (lastX > 0.5)
                    {
                        GameObject fire = Instantiate(gunFire, gunBarrel.transform.position, Quaternion.Euler(new Vector3(0, 90, -90)));
                        GameObject bullet = Instantiate(bulletObj, gunBarrel.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                        bullet.GetComponent<bulletController>().direction = "right";
                    }
                    else if (lastX < -0.5)
                    {
                        GameObject fire = Instantiate(gunFire, gunBarrel.transform.position, Quaternion.Euler(new Vector3(-180, 90, -90)));
                        GameObject bullet = Instantiate(bulletObj, gunBarrel.transform.position, Quaternion.Euler(new Vector3(0, 0, 200)));
                        bullet.GetComponent<bulletController>().direction = "left";
                    }
                    else if (lastY > 0.5)
                    {
                        GameObject fire = Instantiate(gunFire, gunBarrel.transform.position, Quaternion.Euler(new Vector3(-90, 180, -180)));
                        GameObject bullet = Instantiate(bulletObj, gunBarrel.transform.position, Quaternion.Euler(new Vector3(0, 0, 90)));
                        bullet.GetComponent<bulletController>().direction = "up";
                    }
                    else if (lastY < -0.5)
                    {
                        GameObject fire = Instantiate(gunFire, gunBarrel.transform.position, Quaternion.Euler(new Vector3(-270, -90, -270)));
                        GameObject bullet = Instantiate(bulletObj, gunBarrel.transform.position, Quaternion.Euler(new Vector3(0, 0, 270)));
                        bullet.GetComponent<bulletController>().direction = "down";
                    }
                }
                else
                {
                    GameObject fire = Instantiate(gunFire, gunBarrel.transform.position, Quaternion.Euler(new Vector3(0, 90, -90)));
                    GameObject bullet = Instantiate(bulletObj, gunBarrel.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                    bullet.GetComponent<bulletController>().direction = "custom";
                    bullet.GetComponent<bulletController>().customX = moveInput.normalized.x;
                    bullet.GetComponent<bulletController>().customY = moveInput.normalized.y;
                }

                


                sfx.playerAttack.Play();
                anim.SetBool("Gun", false);
            }
            /*if (Mathf.Abs (Input.GetAxisRaw("Horizontal"))> 0.5f && Mathf.Abs(Input.GetAxisRaw("Vertical"))> 0.5f)
            {
                currentMoveSpeed = moveSpeed * diaganolMove;
            }
            else
            {
                currentMoveSpeed = moveSpeed;
            }*/
        }

        if (knockback)
        {
            myRigidbody.velocity = new Vector2(knockbackSpeed*HitX, knockbackSpeed*HitY);
            if (knockbackCounter <= 0)
            {
                knockback = false;
                knockbackCounter = KnockbackPower;
            }
            else
            {
                knockbackCounter -= Time.deltaTime;
            }
            
        }

        if (attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }

        if(attackTimeCounter <= 0)
        {
            attacking = false;
            anim.SetBool("Attack", false);
        }

        //anim.SetFloat ("MoveX", Input.GetAxisRaw ("Horizontal"));
		//anim.SetFloat ("MoveY", Input.GetAxisRaw ("Vertical"));
		anim.SetFloat("MoveX", moveInput.x);
		anim.SetFloat("MoveY", moveInput.y);
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);

        
			
	}
}
