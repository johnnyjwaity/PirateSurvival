using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyStats : MonoBehaviour {

	public int attack;
	public int defense;
	public int speed;
	private GameManager gm;
	public int baseAtk;
	public int baseDef;
	private int baseSpd;

	// Use this for initialization
	void Start () {
		gm = FindObjectOfType<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		//float currentWaveHalf = gm.currentWave / 2;
		float modifier = gm.currentWave*0.1f;
		modifier *= modifier;



		//int currentWaveRounded = Mathf.RoundToInt (currentWaveHalf);

		int baseModifierAtk = Mathf.RoundToInt(baseAtk * modifier);
		attack = baseModifierAtk;

		int baseModifierDef = Mathf.RoundToInt(baseDef * modifier);
		defense = baseModifierDef;

		int baseModifierSpd = Mathf.RoundToInt(baseSpd * modifier);
		speed = baseModifierSpd;

	}
}
