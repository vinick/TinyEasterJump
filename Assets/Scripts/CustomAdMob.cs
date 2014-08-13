using UnityEngine;
using System.Collections;

public class CustomAdMob : MonoBehaviour {
	
	public Transform adMob;
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
				googleAd = false;
			}
		}
	
	
	}
	
}
