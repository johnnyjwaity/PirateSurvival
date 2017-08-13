using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class freeChestManager : MonoBehaviour {
    public bool check;
    private DateTime past;
    private DateTime current;
    private bool chestReady;
    public Text buttonText;
    private TimeSpan timeTill;

	public GameObject DabloonPanel;
	public Text display;

	//public Animation shakeAnim;
	public GameObject chestAnim;

	public bool openDisplayCount;
	private float displayCounter;

	private dabloonManager dm;
	private int moneyToAdd;
   
	// Use this for initialization
	void Start () {
        //past = DateTime.Now;
        Debug.Log(past.ToString());
		dm = FindObjectOfType<dabloonManager> ();
        if (!PlayerPrefs.HasKey("pastTime"))
        {
            DateTime temp = new DateTime(1990, 01, 01, 12, 12, 12);
            PlayerPrefs.SetString("pastTime", temp.ToString());
        }



        var pastString = PlayerPrefs.GetString("pastTime");
        pastString.Replace('_', ':');
        pastString.Replace('-', '/');
        past = Convert.ToDateTime(pastString);
        
	}
	
	// Update is called once per frame
	void Update () {
        if (!chestReady)
        {
            

            current = DateTime.Now;
        
			DateTime wantedTime = past.AddHours(12);
            timeTill = wantedTime.Subtract(current);
            var seconds = timeTill.Seconds;
            var minutes = timeTill.Minutes;
            var hours = timeTill.Hours;
            string strSec = "" + seconds;
            string strMin = "" + minutes;
            string strHrs = "" + hours;

            if(seconds < 10)
            {
                strSec = "0" + strSec;
            }
            if(minutes < 10)
            {
                strMin = "0" + strMin;
            }
            if(hours < 10)
            {
                strHrs = "0" + strHrs;
            }

            buttonText.text = strHrs + ":" + strMin + ":" + strSec;
        }
        
        if(timeTill.Ticks <= 0)
        {
            chestReady = true;
            buttonText.text = "OPEN!";
        }

		if (openDisplayCount) {
			displayCounter -= Time.deltaTime;
			if (displayCounter <= 0) {
				openDisplayCount = false;
				DabloonPanel.SetActive (true);
				dm.AddMoney (moneyToAdd);
			}
		}

        
    }
    public void openChest()
    {
        chestReady = false;
        past = DateTime.Now;
        PlayerPrefs.SetString("pastTime", past.ToString());
        scheduleNotif();
		chestAnim.GetComponent<Animator> ().SetTrigger ("open");
		//float animationTime = shakeAnim.clip.length;
		var randInt = UnityEngine.Random.Range (1f, 100f);
		randInt = (int) randInt;
		moneyToAdd = (int)randInt;

		display.text = "+" + randInt;
		//Debug.Log (animationTime);
		//yield return WaitForSeconds (3);
		//DabloonPanel.SetActive (true);

        //gameObject.GetComponent<Image>().sprite = opened;
		openDisplayCount = true;
		displayCounter = 2.3f;
    }
    private void scheduleNotif()
    {
        var notif = new UnityEngine.iOS.LocalNotification();
        notif.fireDate = past.AddHours(12);
        notif.alertBody = "Your Free Chest Is Ready To Open!";
        UnityEngine.iOS.NotificationServices.ScheduleLocalNotification(notif);
    }
    
}
