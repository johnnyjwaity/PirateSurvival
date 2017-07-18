using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurtPlayer : MonoBehaviour {

    public int attackPower;
    public GameObject damageNumber;
    private int currentDamage;
    public string effect;
    public float time;
    public int power;
    public float interval;

    private float hitX;
    private float hitY;
    public float knockBackPower;

    private playerStats theStats;
    public bool continuous;
    public float continueMax;
    private float continueCount;

	// Use this for initialization
	void Start () {
        theStats = FindObjectOfType<playerStats>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D other)
    {

        if(other.gameObject.name == "player" && !continuous)
        {

            
            hitX = 0f;
            hitY = 0f;

            hitX = other.transform.position.x - transform.position.x;
            hitY = other.transform.position.y - transform.position.y;
            if (hitX > 0)
            {
                hitX = 1;
            }
            else
            {
                hitX = -1;
            }

            if (hitY > 0)
            {
                hitY = 1;
            }
            else
            {
                hitY = -1;
            }

            other.gameObject.GetComponent<PlayerController>().HitX = hitX;
            other.gameObject.GetComponent<PlayerController>().HitY = hitY;
            other.gameObject.GetComponent<PlayerController>().knockbackCounter = other.gameObject.GetComponent<PlayerController>().KnockbackPower;


            currentDamage = attackPower - theStats.currentDefense;
            if(currentDamage < 0)
            {
                currentDamage = 0;
            }

            other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(currentDamage, effect, time, power, interval);


            var clone = (GameObject)Instantiate(damageNumber, other.transform.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<floatingNumbers>().damageNum = currentDamage;


            if(gameObject.tag == "bullet")
            {
                Destroy(gameObject);
            }


        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.name == "player" && !continuous)
        {


            hitX = 0f;
            hitY = 0f;

            hitX = other.transform.position.x - transform.position.x;
            hitY = other.transform.position.y - transform.position.y;
            if (hitX > 0)
            {
                hitX = 1;
            }
            else
            {
                hitX = -1;
            }

            if (hitY > 0)
            {
                hitY = 1;
            }
            else
            {
                hitY = -1;
            }

            other.gameObject.GetComponent<PlayerController>().HitX = hitX;
            other.gameObject.GetComponent<PlayerController>().HitY = hitY;
            other.gameObject.GetComponent<PlayerController>().knockbackCounter = other.gameObject.GetComponent<PlayerController>().KnockbackPower;


            currentDamage = attackPower - theStats.currentDefense;
            if (currentDamage < 0)
            {
                currentDamage = 0;
            }

            other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(currentDamage, effect, time, power, interval);


            var clone = (GameObject)Instantiate(damageNumber, other.transform.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<floatingNumbers>().damageNum = currentDamage;
            Debug.Log("Hit");

            if (gameObject.tag == "bullet")
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if(collision.name == "player" && continuous)
        {

            if(continueCount <= 0)
            {
                currentDamage = attackPower - theStats.currentDefense;
                collision.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(currentDamage, effect, time, power, interval);
                var clone = (GameObject)Instantiate(damageNumber, collision.transform.position, Quaternion.Euler(Vector3.zero));
                clone.GetComponent<floatingNumbers>().damageNum = currentDamage;
                continueCount = continueMax;
            }
            else
            {
                continueCount -= Time.deltaTime;
            }
            
        }
    }
}
