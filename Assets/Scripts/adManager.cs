using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Advertisements;


public class adManager : MonoBehaviour {

	private dabloonManager dm;

	void Start(){
		Advertisement.Initialize ("1510127", false);
		Debug.Log ("Unity Ads initialized: " + Advertisement.isInitialized);
		Debug.Log ("Unity Ads is supported: " + Advertisement.isSupported);

		dm = FindObjectOfType<dabloonManager> ();

	}

	public void ShowRewardedAd()
	{
		if (Advertisement.IsReady("rewardedVideo"))
		{
			var options = new ShowOptions { resultCallback = HandleShowResult };
			Advertisement.Show("rewardedVideo", options);
		}
	}

	private void HandleShowResult(ShowResult result)
	{
		switch (result)
		{
		case ShowResult.Finished:
			Debug.Log ("The ad was successfully shown.");
			dm.AddMoney (20);
			//
			// YOUR CODE TO REWARD THE GAMER
			// Give coins etc.
			break;
		case ShowResult.Skipped:
			Debug.Log("The ad was skipped before reaching the end.");
			break;
		case ShowResult.Failed:
			Debug.LogError("The ad failed to be shown.");
			break;
		}
	}

}
