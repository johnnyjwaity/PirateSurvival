using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealthManager : MonoBehaviour
{

    public int MaxHealth;
	private int originalMaxHealth;
    public int CurrentHealth;

    private playerStats theStats;

    public int expToGive;

    public string enemyQuestName;
    private QuestManager theQM;
    private GameManager gm;

    public bool bulletImmune;

	public bool isBoss;
	private moneyDrop md;


    public GameObject dieAnim;


    // Use this for initialization
    void Start()
    {
        CurrentHealth = MaxHealth;
		originalMaxHealth = MaxHealth;
        theStats = FindObjectOfType<playerStats>();
        theQM = FindObjectOfType<QuestManager>();
        gm = FindObjectOfType<GameManager>();
		md = FindObjectOfType<moneyDrop> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealth <= 0)
        {
            theQM.enemyKilled = enemyQuestName;
            Destroy(gameObject);
            theStats.AddExperience(expToGive);
            gm.enemiesKilled += 1;
			if (isBoss) {
				gm.killedBoss = true;
			}
			gm.enemiesLoaded -= 1;
			md.drop (transform);
            Instantiate(dieAnim);

			Debug.Log("Killed enemy: "+gameObject.name+" Health Left: "+ CurrentHealth);
        }

		float modifier = gm.currentWave*0.1f;
		modifier *= modifier;
		MaxHealth = Mathf.RoundToInt (modifier * originalMaxHealth) + originalMaxHealth;
    }

    public void HurtEnemy(int damage, GameObject type)
    {
        if (bulletImmune)
        {
            if(type.tag != "bullet")
            {
                CurrentHealth -= damage;
				Debug.Log ("Damage Taken: "+  damage);
            }
            
        }
        else
        {
			
				
            CurrentHealth -= damage;
			Debug.Log ("Damage Taken: "+  damage);
        }
        
    }

    public void SetMaxHealth()
    {
        CurrentHealth = MaxHealth;
    }
}
