using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerBuffManager : MonoBehaviour {

	[Header("Values")]

	public int attackBuff;
	public float attackDuration;

	public int DefenseBuff;
	public float defenseDuration;

	public float speedBuff;
	public float speedDuration;

	[Header("Objects")]

	public GameObject Attack;
	public GameObject Defense;
	public GameObject Speed;

	public Text AtkText;
	public Text DefText;
	public Text SpdText;


	// Use this for initialization
	void Start () {
		Attack.SetActive (false);
		Defense.SetActive (false);
		Speed.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		speedDuration -= Time.deltaTime;
		defenseDuration -= Time.deltaTime;
		attackDuration -= Time.deltaTime;

		AtkText.text = "" + Mathf.RoundToInt (attackDuration);
		DefText.text = "" + Mathf.RoundToInt (defenseDuration);
		SpdText.text = "" + Mathf.RoundToInt (speedDuration);

		if (speedDuration <= 0) {
			speedDuration = 0;
			speedBuff = 1;
			Speed.SetActive (false);
		} else {
			Speed.SetActive (true);

		}

		if (defenseDuration <= 0) {
			defenseDuration = 0;
			DefenseBuff = 0;
			Defense.SetActive (false);
		} else {
			Defense.SetActive (true);

		}

		if (attackDuration <= 0) {
			attackDuration = 0;
			attackBuff = 0;
			Attack.SetActive (false);
		} else {
			Attack.SetActive (true);

		}


	}
}
