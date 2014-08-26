using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MyRevMob : MonoBehaviour {

	bool canShowAd;
	
	private static readonly Dictionary<string, string> REVMOB_APP_IDS = new Dictionary<string, string>()
	{
		{"Android", "5331bb8d2cf782db0f6bac6b"},
		{"IOS", "ID"}
	};
	private RevMob revmob;

	RevMobBanner banner = null;

	void Awake()
	{
		#if (UNITY_ANDROID && !UNITY_EDITOR)
		
		revmob = RevMob.Start(REVMOB_APP_IDS, this.gameObject.name);
		
		#endif
	}

	// Use this for initialization
	void Start () {
		canShowAd = true;

		#if (UNITY_ANDROID && !UNITY_EDITOR)
		RevMobBanner banner = revmob.CreateBanner(RevMob.Position.BOTTOM);
		#endif
	
	}
	
	// Update is called once per frame
	void Update () {

		#if (UNITY_ANDROID && !UNITY_EDITOR)
		if(GameControl.startGame && canShowAd)
		{
			canShowAd = false;
			banner.Show();
		}

		if(GameControl.gameOver)
		{
			banner.Hide();
		}
		#endif
	}
}
