using UnityEngine;
using System.Collections;

public class MyImpact : MonoBehaviour {

	#if (UNITY_ANDROID && !UNITY_EDITOR)

	private bool _campaignsAvailable = false;
	
	//public Transform freeEgg;
	public GameObject freeEgg;
	
	bool canShowAd;
	

	void Awake() {
		
		
		
		ApplifierImpactMobile.setCampaignsAvailableDelegate(ApplifierImpactCampaignsAvailable);
		ApplifierImpactMobile.setCloseDelegate(ApplifierImpactClose);
		ApplifierImpactMobile.setOpenDelegate(ApplifierImpactOpen);
		ApplifierImpactMobile.setCampaignsFetchFailedDelegate(ApplifierImpactCampaignsFetchFailed);
		ApplifierImpactMobile.setVideoCompletedDelegate(ApplifierImpactVideoCompleted);
		ApplifierImpactMobile.setVideoStartedDelegate(ApplifierImpactVideoStarted);
	}
	
	void Start()
	{
		//freeEgg = GameObject.FindGameObjectWithTag("freeEgg");
		//freeEgg.gameObject.SetActive(false);
		canShowAd = true;
		ApplifierImpactCampaignsAvailable();
	}
	
	void Update()
	{
		
		if(freeEgg == null)
		{
			freeEgg = GameObject.FindGameObjectWithTag("freeEgg");
			freeEgg.gameObject.SetActive(false);
		}
		
		
		if(ApplifierImpactMobile.canShowCampaigns() && ApplifierImpactMobile.canShowImpact() && canShowAd && freeEgg != null)
		{
			freeEgg.gameObject.SetActive(true);
		}
	}
	
	public void ApplifierImpactCampaignsAvailable() {
		Debug.Log ("IMPACT: CAMPAIGNS READY!");
		_campaignsAvailable = true;
	}

	public void ApplifierImpactCampaignsFetchFailed() {
		Debug.Log ("IMPACT: CAMPAIGNS FETCH FAILED!");
	}

	public void ApplifierImpactOpen() {
		Debug.Log ("IMPACT: OPEN!");
	}
	
	public void ApplifierImpactClose() {
		Debug.Log ("IMPACT: CLOSE!");
	}

	public void ApplifierImpactVideoCompleted(string rewardItemKey, bool skipped) {
		PlayerPrefs.SetInt("currentEggs", PlayerPrefs.GetInt("currentEggs") + 1);
		Debug.Log ("IMPACT: VIDEO COMPLETE : " + rewardItemKey + " - " + skipped);
	}

	public void ApplifierImpactVideoStarted() {
		canShowAd = false;
		freeEgg.gameObject.SetActive(false);
		Debug.Log ("IMPACT: VIDEO STARTED!");
	}
	
	
	public void ShowVideoAd()
	{
		ApplifierImpactMobile.showImpact("16-default");
	}

#endif
}
