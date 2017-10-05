using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopItem : MonoBehaviour {

	private moneyManager mm;
	private PlayerHealthManager phm;
	private PlayerBuffManager bm;

	[Header("Objects")]
	public Text priceText;
	public Text durationDisplay;
	public Text mainDisplay;
	public Text upgradeText;
	public Button purchaseButton;
	public Button upgradeButton;
	public Text currentGoldText;

	[Header("Stats")]
	public string type;
	public float value;
	public int cost;
	public Vector2 duration;
	public int upgradeCost;
	public int level = 1;
	public float valueIncrease;
	public float durationIncrease;


	// Use this for initialization
	void Start () {
		mm = FindObjectOfType<moneyManager> ();
		phm = FindObjectOfType<PlayerHealthManager> ();
		bm = FindObjectOfType<PlayerBuffManager> ();
		priceText.text = "" + cost;
		if (durationDisplay != null) {
			var secondString = duration.y.ToString();

			if (secondString.Length < 2) {
				secondString = "0" + secondString;
			}
			durationDisplay.text = duration.x + ":" + secondString;
		}
		mainDisplay.text = "" + value;
		upgradeText.text = "" + upgradeCost;
	}
	
	// Update is called once per frame
	void Update () {
		upgradeCost = level * 50;

		updateInfo ();
		if (currentGoldText != null) {
			currentGoldText.text = "Current Gold: " + mm.currentGold;
		}

		if (mm.currentGold < cost) {
			purchaseButton.GetComponent<Image> ().color = Color.red;
			//priceText.color = Color.red;
		} else {
			purchaseButton.GetComponent<Image> ().color = Color.green;
			//priceText.color = Color.white;
		}

		if (mm.currentGold < upgradeCost) {
			upgradeButton.GetComponent<Image> ().color = Color.red;
			//upgradeText.color = Color.red;
		} else {
			upgradeButton.GetComponent<Image> ().color = Color.green;
			//upgradeText.color = Color.white;
		}
	}

	public void Purchase (){
		if (mm.currentGold <= cost) {
			mm.currentGold -= cost;
		} else {
			return;
		}
		Debug.Log ("Purchase " + type);

		if (type == "Health") {
			if (phm.playerCurrentHealth + value > phm.playerMaxHealth) {
				phm.playerCurrentHealth = phm.playerMaxHealth;
			} else {
				phm.playerCurrentHealth += (int) value;
			}
		}

		if (type == "Attack") {
			bm.attackBuff = (int) value;
			var ActualDuration = (duration.x * 60) + duration.y;
			bm.attackDuration += ActualDuration;
		}

		if (type == "Defense") {
			bm.DefenseBuff = (int) value;
			var ActualDuration = (duration.x * 60) + duration.y;
			bm.defenseDuration += ActualDuration;
		}

		if (type == "Speed") {
			bm.speedBuff = value;
			var ActualDuration = (duration.x * 60) + duration.y;
			bm.speedDuration += ActualDuration;
		}

	}
	public void Upgrade (){
		Debug.Log ("Upgrade " + type);
		if (upgradeCost <= mm.currentGold) {
			mm.currentGold -= upgradeCost;
		} else {
			return;
		}

		value += valueIncrease;
		duration.y += durationIncrease;
		if (duration.y >= 60) {
			duration.y -= 60;
			duration.x++;
		}
		cost += level*5;
		updateInfo ();
	}
	private void updateInfo(){
		priceText.text = "" + cost;
		if (durationDisplay != null) {
			var secondString = duration.y.ToString ();

			if (secondString.Length < 2) {
				secondString = "0" + secondString;
			}
			durationDisplay.text = duration.x + ":" + secondString;
		}
		mainDisplay.text = "" + value;
		upgradeText.text = "" + upgradeCost;
	}

}
