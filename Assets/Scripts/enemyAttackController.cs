using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttackController : MonoBehaviour {

	private Animator anim;
	public string type;
	[Space(10)]
	[Header("Attack Properties")]
	[Space(7)]
	public float rateOfAttack;
	private float rateCounter;
	[Space(10)]
	[Header("Shooting Prefabs")]
	[Space(7)]
	public GameObject gunSmoke;
	public GameObject gunBarrel;
	public GameObject gunFire;
	public GameObject bulletObj;


	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		rateCounter -= Time.deltaTime;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.name == "player")
		{
			if (rateCounter <= 0) {
				anim.SetTrigger ("Attack");
				rateCounter = rateOfAttack;
			}

		}



	}
	public void shoot()
	{
		if (type == "gun")
		{
			GameObject smoke = Instantiate(gunSmoke, gunBarrel.transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
			var lastX = anim.GetFloat("moveX");
			var lastY = anim.GetFloat("moveY");
			if (lastX >= 0.5)
			{
				GameObject fire = Instantiate(gunFire, gunBarrel.transform.position, Quaternion.Euler(new Vector3(0, 90, -90)));

			}
			else if (lastX <= -0.5)
			{
				GameObject fire = Instantiate(gunFire, gunBarrel.transform.position, Quaternion.Euler(new Vector3(-180, 90, -90)));

			}
			else if (lastY >= 0.5)
			{
				GameObject fire = Instantiate(gunFire, gunBarrel.transform.position, Quaternion.Euler(new Vector3(-90, 180, -180)));

			}
			else if (lastY <= -0.5)
			{
				GameObject fire = Instantiate(gunFire, gunBarrel.transform.position, Quaternion.Euler(new Vector3(-270, -90, -270)));

				Debug.Log("Fired Down");


			}

			var clone = Instantiate(bulletObj, transform.position, transform.rotation);
			var cloneRigid = clone.GetComponent<Rigidbody2D>();
			cloneRigid.velocity = (GameObject.Find("player").transform.position - transform.position).normalized * 20;



		}
	}
}
