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
		float currentWaveHalf = gm.currentWave / 2;
		int currentWaveRounded = Mathf.RoundToInt (currentWaveHalf);

		int baseModifierAtk = baseAtk * currentWaveRounded;
		attack = gm.currentWave + baseModifierAtk;

		int baseModifierDef = baseDef * currentWaveRounded;
		defense = gm.currentWave + baseModifierDef;

		int baseModifierSpd = baseSpd * currentWaveRounded;
		speed = gm.currentWave + baseModifierSpd;

	}
}
