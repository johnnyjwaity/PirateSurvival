using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponManager : MonoBehaviour {
	public GameObject[] meelee;
	public GameObject[] ranged;

	private string meeleeChosen = "basicSword";
	private string rangedChosen = "star1";
	// Use this for initialization
	void Start () {
		meeleeChosen = PlayerPrefs.GetString ("meelee");
		rangedChosen = PlayerPrefs.GetString ("ranged");

		foreach (GameObject weaponM in meelee) {
			weaponM.SetActive (false);
		}

		foreach (GameObject weaponR in ranged) {
			weaponR.SetActive (false);
		}

		foreach (GameObject weaponM in meelee) {
			if (weaponM.name == meeleeChosen) {
				
				weaponM.SetActive (true);
			}
		}

		foreach (GameObject weaponR in ranged) {
			if (weaponR.name == rangedChosen) {
				
				weaponR.SetActive (true);
                gameObject.GetComponent<PlayerController>().bulletObj = weaponR.GetComponent<projectileToUse>().projectile;
                gameObject.GetComponent<PlayerController>().useSmoke = weaponR.GetComponent<projectileToUse>().gunSmoke;
                gameObject.GetComponent<PlayerController>().useFire = weaponR.GetComponent<projectileToUse>().gunFire;
            }
		}


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
