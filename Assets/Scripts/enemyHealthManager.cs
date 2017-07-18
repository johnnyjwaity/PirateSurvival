using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealthManager : MonoBehaviour
{

    public int MaxHealth;
    public int CurrentHealth;

    private playerStats theStats;

    public int expToGive;

    public string enemyQuestName;
    private QuestManager theQM;
    private GameManager gm;

    public bool bulletImmune;

    // Use this for initialization
    void Start()
    {
        CurrentHealth = MaxHealth;

        theStats = FindObjectOfType<playerStats>();
        theQM = FindObjectOfType<QuestManager>();
        gm = FindObjectOfType<GameManager>();
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


        }
    }

    public void HurtEnemy(int damage, GameObject type)
    {
        if (bulletImmune)
        {
            if(type.tag != "bullet")
            {
                CurrentHealth -= damage;
            }
            
        }
        else
        {
            CurrentHealth -= damage;
        }
        
    }

    public void SetMaxHealth()
    {
        CurrentHealth = MaxHealth;
    }
}
