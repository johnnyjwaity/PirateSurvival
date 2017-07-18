using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour {

    public int playerMaxHealth;
    public int playerCurrentHealth;
    private Rigidbody2D myRigidBody;

    public bool burning;
    private float burnTime;
    private float burnCounter;
    private int burnPower;
    private float burnInterval;
    private float burnIntervalCounter;

    public GameObject fireEffect;

    private SFXManager sfx;
	// Use this for initialization
	void Start () {
        playerCurrentHealth = playerMaxHealth;
        myRigidBody = GetComponent<Rigidbody2D>();
        sfx = FindObjectOfType<SFXManager>();
    }
	
	// Update is called once per frame
	void Update () {
		if (playerCurrentHealth <= 0)
        {
            sfx.playerDead.Play();
            gameObject.SetActive(false);

        }

        if (burning)
        {
            burnCounter -= Time.deltaTime;
            if (burnCounter <= 0)
            {
                burning = false;
                fireEffect.SetActive(false);
            }
            burnIntervalCounter -= Time.deltaTime;
            if (burnIntervalCounter <= 0)
            {
                HurtPlayer(burnPower, null, 0, 0, 0);
                burnIntervalCounter = burnInterval;
            }
            
        }
	}

    public void HurtPlayer(int damage, string effect, float time, int power, float interval)
    {
        playerCurrentHealth -= damage;
        
        GetComponent<PlayerController>().knockback = true;
        sfx.playerHurt.Play();

        if(effect == "burn")
        {
            burning = true;
            fireEffect.SetActive(true);
            burnCounter += time;
            burnPower = power;
            burnInterval = interval;
            burnIntervalCounter = burnInterval;
        }

    }

    public void SetMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;
    }
    
}
