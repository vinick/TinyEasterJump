using UnityEngine;
using System.Collections;

public class AdMobStarter : MonoBehaviour {

	public Transform banner;
	public Transform interstitial;

	bool canShowBanner;
	bool canShowInterstitial;

	// Use this for initialization
	void Start () {
		canShowBanner = true;
		canShowInterstitial = true;
	}
	
	// Update is called once per frame
	void Update () {

		if(GameControl.startGame && canShowBanner)
		{
			canShowBanner = false;
			banner.gameObject.SetActive(true);
		}

		if(GameControl.gameOver && canShowInterstitial)
		{
			canShowInterstitial = false;
			banner.gameObject.SetActive(false);

			if(PlayerPrefs.GetInt("adMob") == 3)
			{
				interstitial.gameObject.SetActive(true);
				PlayerPrefs.SetInt("adMob", 1);
			}
			else
			{
				PlayerPrefs.SetInt("adMob", PlayerPrefs.GetInt("adMob") + 1);
			}
		}
	
	}
}
