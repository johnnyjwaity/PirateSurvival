using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour {
    private Rigidbody2D myRigidbody;
    public float bulletSpeed;
    public string direction;
    private GameObject player;

    public bool enemyBullet;
    private float bulletX;
    private float bulletY;
    public float customX;
    public float customY;

    [Header("Rotation")]
    public bool rotateWhileMoving;
    public float rotationSpeed;

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>().gameObject;
        var lastX = player.GetComponent<Animator>().GetFloat("LastMoveX");
        var lastY = player.GetComponent<Animator>().GetFloat("LastMoveY");
        PlayerController playerCont = player.GetComponent<PlayerController>();

        if(lastX != 0)
        {
            if (lastX > 0)
            {
                direction = "right";
            }
            else
            {
                direction = "left";
            }
        }
        else
        {
            if(lastY > 0)
            {
                direction = "up";
            }
            else
            {
                direction = "down";
            }
        }

        if(playerCont.playerMoving && playerCont.joystick)
        {
            direction = "custom";
        }

        if (enemyBullet)
        {
            bulletX = player.transform.position.x - gameObject.transform.position.x;
            bulletY = player.transform.position.y - gameObject.transform.position.y;

            if (bulletX >= bulletY)
            {
                
                bulletY = bulletY / bulletX;
                bulletX = bulletX / bulletX;
            }
            else
            {
                bulletX = bulletX / bulletY;
                bulletY = bulletY / bulletY;
            }

            direction = "player";
        }
    }
	
	// Update is called once per frame
	void Update () {
		/*if(transform.rotation == Quaternion.Euler(new Vector3(0, 0, 0))) //Right
        {
            myRigidbody.velocity = new Vector2(bulletSpeed, 0);
        }
        else if (transform.rotation == Quaternion.Euler(new Vector3(0, 0, 90))) //Up
        {
            myRigidbody.velocity = new Vector2(0, bulletSpeed);
        }
        else if (transform.rotation == Quaternion.Euler(new Vector3(0, 0, 200))) //Left
        {
            myRigidbody.velocity = new Vector2(-bulletSpeed, 0);
            Debug.Log("Left");
        }
        else if (transform.rotation == Quaternion.Euler(new Vector3(0, 0, 270))) //Down
        {
            myRigidbody.velocity = new Vector2(0, -bulletSpeed);
            Debug.Log("Down");
        }*/

        if (direction == "right") //Right
        {
            myRigidbody.velocity = new Vector2(bulletSpeed, 0);
        }
        else if (direction == "up") //Up
        {
            myRigidbody.velocity = new Vector2(0, bulletSpeed);
        }
        else if (direction == "left") //Left
        {
            myRigidbody.velocity = new Vector2(-bulletSpeed, 0);
            
        }
        else if (direction == "down") //Down
        {
            myRigidbody.velocity = new Vector2(0, -bulletSpeed);
            
        }
        else if(direction == "player")
        {
            //myRigidbody.velocity = new Vector2(bulletX * bulletSpeed, bulletY * bulletSpeed);

        }
        else if(direction == "custom")
        {
            myRigidbody.velocity = new Vector2(customX * bulletSpeed, customY * bulletSpeed);
        }

        if (rotateWhileMoving)
        {
            transform.Rotate(0, 0, rotationSpeed);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag!="Enemy" && collision.name != "player" && collision.tag != "radius" && enemyBullet && collision.name != "Collision")
        {
            Destroy(gameObject);
            Debug.Log("Destroyed By " + collision.name);
           
            
        }
    }
}
