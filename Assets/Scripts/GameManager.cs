using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject pauseMenu;
    private bool paused;

    public GameObject player;
    public float respawnTime;
    private float respawnCounter;

    

    

    public GameObject inventoryPanel;
    private InventoryManager im;
    private bool inventoryOpen;
    public GameObject wavePanel;
    public Text waveText;

    public int currentWave;
    public int[] waveEnemies;
    public int types;
    public int enemiesKilled;
    private bool waveBox;

    private float waveBoxCounter;
    public float waveBoxTime;

	public Slider inputType;
	public GameObject dPad;
	public GameObject joystick;

    private spawner[] spawners;
    private bool bossForRoundSpawned;

	public bool killedBoss;

	public Text enemyCounter;
	public Text bossDisplay;
	private string bossForRound;


	public int enemiesLoaded;
	public int MaxEnemies;

	public GameObject shopMenu;

	// Use this for initialization
	void Start () {
        respawnCounter = respawnTime;
        im = FindObjectOfType<InventoryManager>();
        spawners = FindObjectsOfType<spawner>();
	}
	
	// Update is called once per frame
	void Update () {
		if (currentWave * 5 <= enemiesKilled && bossForRoundSpawned == false) {
			enemiesKilled = 0;
			currentWave += 1;
			//waveBox = true;
			waveText.text = "Wave: " + currentWave;
			//waveBoxCounter = waveBoxTime;
			//wavePanel.SetActive(true);
			bossForRoundSpawned = false;
		} else if (currentWave * 5 <= enemiesKilled && bossForRoundSpawned == true) {
			if (killedBoss) {
				enemiesKilled = 0;
				currentWave += 1;
				//waveBox = true;
				waveText.text = "Wave: " + currentWave;
				//waveBoxCounter = waveBoxTime;
				//wavePanel.SetActive(true);
				bossForRoundSpawned = false;
				killedBoss = false;
			}
		}


        if (waveBox)
        {
            waveBoxCounter -= Time.deltaTime;
            if (waveBoxCounter <= 0)
            {
                wavePanel.SetActive(false);
                waveBox = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (!paused)
            {
                PauseGame();
            
            }
            else
            {
                PlayGame();
            }
        }

        if(player.activeSelf == false)
        {
            respawnCounter -= Time.deltaTime;
            if (respawnCounter <= 0f)
            {
                
                player.GetComponent<PlayerHealthManager>().playerCurrentHealth = player.GetComponent<PlayerHealthManager>().playerMaxHealth;
                player.SetActive(true);
                gameObject.GetComponent<moneyManager>().AddMoney(-1*(gameObject.GetComponent<moneyManager>().currentGold = gameObject.GetComponent<moneyManager>().currentGold / 2));
                respawnCounter = respawnTime;
            }
        }
		if (inputType.value == 0) {
			dPad.SetActive (true);
			joystick.SetActive (false);
			player.GetComponent<PlayerController> ().joystick = false;
		} else {
			dPad.SetActive (false);
			joystick.SetActive (true);
			player.GetComponent<PlayerController> ().joystick = true;
		}

        var currentWaveFloat = (float)currentWave;
        if(currentWaveFloat%2 == 0 && bossForRoundSpawned == false)
        {
            var rnum = Random.Range(0f, spawners.Length);
            var rnumInt = (int)rnum;
            spawners[rnumInt].SpawnBoss(0);
			bossForRound = spawners [rnumInt].bosses [0].name;
            bossForRoundSpawned = true;
        }
		else if(currentWaveFloat%5 == 0 && bossForRoundSpawned == false)
		{
			var rnum = Random.Range(0f, spawners.Length);
			var rnumInt = (int)rnum;
			spawners[rnumInt].SpawnBoss(1);
			bossForRound = spawners [rnumInt].bosses [1].name;
			bossForRoundSpawned = true;
		}

		enemyCounter.text = "Killed " + enemiesKilled + "/" + currentWave * 5;
		if (bossForRoundSpawned == false) {
			bossDisplay.text = "No Bosses";
		} else {
			bossDisplay.text = "Kill " + bossForRound;
		}

    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        paused = true;
        
    }
    public void PlayGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        paused = false;
    }
    public void TogglePause()
    {
        if (paused)
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            paused = false;
        }
        else
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            paused = true;
        }
    }
    

    public void ToggleInventory()
    {
        if (inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(false);
            inventoryOpen = false;
        }
        else
        {
            
            inventoryPanel.SetActive(true);
            inventoryOpen = true;
            im.displayInventory();
        }
    }
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            PauseGame();
        }
    }
	public void toggleShop(){
		if (shopMenu.activeSelf) {
			shopMenu.SetActive (false);
		} else {
			shopMenu.SetActive (true);
		}
	}
}
