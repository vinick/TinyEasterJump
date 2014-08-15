using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ApplifierImpactTest : MonoBehaviour {

	#if (UNITY_ANDROID && !UNITY_EDITOR)

	private bool _campaignsAvailable = false;

	void Awake() {
		ApplifierImpactMobile.setCampaignsAvailableDelegate(ApplifierImpactCampaignsAvailable);
		ApplifierImpactMobile.setCloseDelegate(ApplifierImpactClose);
		ApplifierImpactMobile.setOpenDelegate(ApplifierImpactOpen);
		ApplifierImpactMobile.setCampaignsFetchFailedDelegate(ApplifierImpactCampaignsFetchFailed);
		ApplifierImpactMobile.setVideoCompletedDelegate(ApplifierImpactVideoCompleted);
		ApplifierImpactMobile.setVideoStartedDelegate(ApplifierImpactVideoStarted);
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
		Debug.Log ("IMPACT: VIDEO COMPLETE : " + rewardItemKey + " - " + skipped);
	}

	public void ApplifierImpactVideoStarted() {
		Debug.Log ("IMPACT: VIDEO STARTED!");
	}

	void OnGUI () {
		if (GUI.Button (new Rect (10, 10, 150, 50), _campaignsAvailable ? "Open Zone 1" : "Waiting...")) {
			if (_campaignsAvailable) {
				ApplifierImpactMobileExternal.Log("Open Zone 1 -button clicked");
				ApplifierImpactMobile.showImpact("16-default");
			}	
		}
		
		if (GUI.Button (new Rect (10, 70, 150, 50), _campaignsAvailable ? "Open Zone 2" : "Waiting...")) {
			if(_campaignsAvailable) {
				ApplifierImpactMobileExternal.Log ("Open Zone 2 -button clicked");
				ApplifierImpactMobile.showImpact("16-default", "ship", new Dictionary<string, string>{
					{"openAnimated", "true"},
					{"noOfferScreen", "true"},
					{"sid", "testiSid"},
					{"muteVideoSounds", "true"},
					{"useDeviceOrientationForVideo", "true"}
				});
			}
		}
	}

#endif
}
