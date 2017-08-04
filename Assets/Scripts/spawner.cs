using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

    public GameObject[] Pirates;
    public GameObject[] bosses;
    

    private GameManager gm;
    private int currentWave;
    private int types;

    public float frequency;
    private float currentTime;

    Random random = new Random();

	// Use this for initialization
	void Start () {
        gm = FindObjectOfType<GameManager>();
        currentTime = frequency;




    }
	
	// Update is called once per frame
	void Update () {
        currentTime -= Time.deltaTime;
		if (currentTime <= 0 && gm.enemiesLoaded <= gm.MaxEnemies)
        {
            //if (!gameObject.GetComponent<spawner>().isVisible)
            //{
            currentWave = gm.currentWave;
            types = gm.types;
            var rnum = Random.Range(0, types);
            GameObject pirate = Instantiate(Pirates[rnum], gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            currentTime = frequency;
			gm.enemiesLoaded += 1;
            //}
            
        }
	}
    public void SpawnBoss(int id)
    {
        Instantiate(bosses[id], gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
		gm.enemiesLoaded += 1;
    }
}
