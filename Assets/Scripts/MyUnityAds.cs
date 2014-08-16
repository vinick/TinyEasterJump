using UnityEngine;
using System.Collections;

public class MyUnityAds : MonoBehaviour {
	
	private bool _campaignsAvailable = false;
	
	public GameObject freeEgg;
	
	bool canShowAd;
	
	void Awake() {
		UnityAds.setCampaignsAvailableDelegate(UnityAdsCampaignsAvailable);
		UnityAds.setHideDelegate(UnityAdsHide);
		UnityAds.setShowDelegate(UnityAdsShow);
		UnityAds.setCampaignsFetchFailedDelegate(UnityAdsCampaignsFetchFailed);
		UnityAds.setVideoCompletedDelegate(UnityAdsVideoCompleted);
		UnityAds.setVideoStartedDelegate(UnityAdsVideoStarted);
	}
	
	// Use this for initialization
	void Start () {
		
		canShowAd = true;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(freeEgg == null)
		{
			freeEgg = GameObject.FindGameObjectWithTag("freeEgg");
			freeEgg.gameObject.SetActive(false);
		}
		else if(UnityAds.canShowAds() && UnityAds.canShow() && canShowAd) 
		{
			canShowAd = false;
			freeEgg.gameObject.SetActive(true);
		}
	
	}
	
	public void UnityAdsCampaignsAvailable() {
		Debug.Log ("ADS: CAMPAIGNS READY!");
		_campaignsAvailable = true;
	}

	public void UnityAdsCampaignsFetchFailed() {
		Debug.Log ("ADS: CAMPAIGNS FETCH FAILED!");
	}

	public void UnityAdsShow() {
		Debug.Log ("ADS: SHOW");
	}
	
	public void UnityAdsHide() {
		Debug.Log ("ADS: HIDE");
	}

	public void UnityAdsVideoCompleted(string rewardItemKey, bool skipped) {
		PlayerPrefs.SetInt("currentEggs", PlayerPrefs.GetInt("currentEggs") + 1);
		freeEgg.gameObject.SetActive(false);
		Debug.Log ("ADS: VIDEO COMPLETE : " + rewardItemKey + " - " + skipped);
	}

	public void UnityAdsVideoStarted() {
		freeEgg.gameObject.SetActive(false);
		Debug.Log ("ADS: VIDEO STARTED!");
	}
	
	public void ShowVideoAd()
	{
		UnityAds.show("16-default");
	}
}
