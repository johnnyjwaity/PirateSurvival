using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurtEnemy : MonoBehaviour {

    public int damageToGive;
    private int currentDamage;
    public GameObject damageBurst;
    public Transform hitPoint;
    public GameObject damageNumber;

    private playerStats theStats;

	// Use this for initialization
	void Start () {
        theStats = FindObjectOfType<playerStats>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            //Destroy(other.gameObject);
            currentDamage = damageToGive + theStats.currentAttack;

            other.gameObject.GetComponent<enemyHealthManager>().HurtEnemy(currentDamage, gameObject);
            Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);
            var clone = (GameObject) Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<floatingNumbers>().damageNum = currentDamage;

            if(gameObject.tag == "bullet")
            {
                Destroy(gameObject);
            }

        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //Destroy(other.gameObject);
            currentDamage = damageToGive + theStats.currentAttack;

            other.gameObject.GetComponent<enemyHealthManager>().HurtEnemy(currentDamage, gameObject);
            Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);
            var clone = (GameObject)Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<floatingNumbers>().damageNum = currentDamage;

            if (gameObject.tag == "bullet")
            {
                Destroy(gameObject);
            }

        }
    }
}
