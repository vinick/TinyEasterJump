using UnityEngine;
using System.Collections;

public class CustomAdMob : MonoBehaviour {
	
	public Transform adMob;
	public Transform adMobInter;
	bool googleAd;
	
	// Use this for initialization
	void Start () {
		googleAd = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(googleAd)
		{
			if(GameControl.startGame)
			{
				adMob.gameObject.SetActive(true);
			}
			
			if(GameControl.gameOver)
			{
				Destroy(adMob.gameObject);
				
				/*
				if(PlayerPrefs.GetInt("adMob") == 3)
				{
					adMobInter.gameObject.SetActive(true);
					PlayerPrefs.SetInt("adMob", 1);
				}
				else
				{
					PlayerPrefs.SetInt("adMob", PlayerPrefs.GetInt("adMob") + 1);
				}
				*/
				
				googleAd = false;
			}
		}
		else
		{
			adMobInter.gameObject.SetActive(true);
		}
	}
	
	
}
