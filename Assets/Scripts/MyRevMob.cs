using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MyRevMob : MonoBehaviour, IRevMobListener {
	
	bool showFullscreenAD;
	
	RevMobBanner banner;

	
	private static readonly Dictionary<string, string> REVMOB_APP_IDS = new Dictionary<string, string>()
	{
		{"Android", "5331bb8d2cf782db0f6bac6b"},
		{"IOS", "ID"}
	};
	private RevMob revmob;
	
	public float timingAd;
	float timing;
	bool start;
	
	bool canShowEndBanner;
	
	public static bool canRestartGame;
	float restartTiming;
	
	void Awake()
	{
		start = false;
		#if (UNITY_ANDROID && !UNITY_EDITOR)
		
		revmob = RevMob.Start(REVMOB_APP_IDS, this.gameObject.name);
		
		#endif
	}
	
	// Use this for initialization
	void Start () {
		
		showFullscreenAD = true;
		canShowEndBanner = true;
		canRestartGame = false;
		#if (UNITY_ANDROID && !UNITY_EDITOR)
		banner = revmob.CreateBanner(RevMob.Position.BOTTOM);
		//banner.Show();
		#endif
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(GameControl.startGame)
		{
			start = true;
			timing = Time.time + timingAd;
		}
		
		#if (UNITY_ANDROID && !UNITY_EDITOR)
		if(GameControl.startGame && showFullscreenAD)
		{
			showFullscreenAD = false;
			banner.Show();
		}
		
		if(GameControl.gameOver)
		{
			banner.Hide();
		}
		
		if(GameControl.gameOver && canShowEndBanner)
		{
			revmob.SetTimeoutInSeconds(1);
			canShowEndBanner = false;
			revmob.ShowPopup();
			//revmob.ShowFullscreen();
		}
		#endif
		
		
	}
	
	#region IRevMobListener implementation
    public void AdDidReceive (string revMobAdType) {
		//canRestartGame = true;
        Debug.Log("Ad did receive.");
    }

    public void AdDidFail (string revMobAdType) {
		canRestartGame = true;
        Debug.Log("Ad did fail.");
    }

    public void AdDisplayed (string revMobAdType) {
		//canRestartGame = true;
        Debug.Log("Ad displayed.");
    }

    public void UserClickedInTheAd (string revMobAdType) {
		revmob.HideBanner();
		canRestartGame = true;
        Debug.Log("Ad clicked.");
    }

    public void UserClosedTheAd (string revMobAdType) {
		revmob.HideBanner();
		canRestartGame = true;
        Debug.Log("Ad closed.");
    }

    public void InstallDidReceive(string message) {
        Debug.Log("Install received");
    }

    public void InstallDidFail(string message) {
        Debug.Log("Install not received");
    }
    #endregion
}
