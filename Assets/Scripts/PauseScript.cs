using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {
	
	public Transform pauseSprite;
	
	public static bool pauseGame;
	
	public Transform pauseBoard;
	public Transform [] pauseBoardComponents;
	
	Color tempColor;
	bool paused;
	
	// Use this for initialization
	void Start () {
		pauseGame = false;
		paused = false;
		
		for(int i = 0; i <= 4; i++)
		{
			tempColor = pauseBoardComponents[i].renderer.material.color;
			tempColor.a = 0;
			pauseBoardComponents[i].renderer.material.color = tempColor;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(pauseGame)
		{
			
			pauseSprite.gameObject.SetActive(false);
			Time.timeScale = 0;
			
			PauseFadeOut();
		}
		else
		{
			PauseFadeIn();
			if(tempColor.a <= 0)
			{
				for(int i = 0; i <= 4; i++)
				{
					pauseBoardComponents[i].gameObject.SetActive(false);
				}
				//pauseBoard.gameObject.SetActive(false);
				pauseSprite.gameObject.SetActive(true);
				Time.timeScale = 1;
			}
		}
	
	}
	
	void PauseFadeIn()
	{
		if(paused)
		{
			paused = false;
			
			for(int i = 0; i <= 4; i++)
			{
			iTween.FadeTo(pauseBoardComponents[i].gameObject, iTween.Hash(
				"alpha", 0,
				"time", 0.1f,
				"ignoretimescale", true
				));
			}
		}
	}
	
	void PauseFadeOut()
	{
		if(!paused)
		{
			paused = true;
			//pauseBoard.gameObject.SetActive(true);
			
			for(int i = 0; i <= 4; i++)
			{
			pauseBoardComponents[i].gameObject.SetActive(true);
			iTween.FadeTo(pauseBoardComponents[i].gameObject, iTween.Hash(
				"alpha", 1,
				"time", 0.1f,
				"ignoretimescale", true
				));
			}
		}
	}
}
