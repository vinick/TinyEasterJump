using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {
	
	public static bool startGame;
	public static bool gameOver;
	
	public static bool start;
	
	public Transform HUD;
	public Transform gameLogo;
	public Transform tapToPlay;
	public Transform initialSpawn;
	
	public Transform StartHud;
	public Transform GameOverHud;
	
	float canStartGameTime;
	public static bool canStartGame;
	
	bool bgSound;
	public static bool secondChance;
	
	public AudioClip [] backgrounds;
	
	bool canFade;
	
	float audioTime;
	
	public static bool accControl;
	public Transform controlButtons;
	
	// Use this for initialization
	void Start () {
		startGame = false;
		gameOver = false;
		
		start = false;
		
		canStartGameTime = Time.time + 0.5f;
		canStartGame = false;
		
		bgSound = false;
		secondChance = false;
		
		canFade = true;
		audioTime = 0;
		
		accControl = true;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown(KeyCode.Escape)) 
		{
			Application.Quit(); 
		}
		
		if(!audio.isPlaying && !startGame)
		{
			audio.clip = backgrounds[2];
			audio.loop = true;
			audio.Play();
		}
		
		if(!bgSound && startGame && canFade)
		{
			canFade = false;
			iTween.AudioTo(this.gameObject, iTween.Hash(
				"volume", 0,
				"time", 2
				));
		}
		
		if(!bgSound && startGame && audio.volume < 0.1f)
		{
			//audio.volume = 0;
			iTween.AudioTo(this.gameObject, iTween.Hash(
				"volume", 0.25f,
				"time", 1f
				));
			bgSound = true;
			audio.clip = backgrounds[3];
			audio.loop = false;
			audio.Play();
		}
		else if(secondChance)
		{
			secondChance = false;
			audio.clip = backgrounds[1];
			audio.loop = false;
			audio.Play();
		}
		else if(RabbitController.dead || RabbitAnimator.die)
		{
			audio.Stop();
		}
		
		if(!audio.isPlaying && startGame &&!(RabbitController.dead || RabbitAnimator.die))
		{
			if(audio.clip == backgrounds[3])
			{
				audio.clip = backgrounds[1];
				audio.loop = false;
			}
			else
			{
				audio.clip = backgrounds[3];
				audio.loop = false;
			}
			audio.Play();
		}
		
		
		if(PauseScript.pauseGame && !audio.mute)
		{
			audio.mute = true;
		}
		else if(!PauseScript.pauseGame && audio.mute)
		{
			audio.mute = false;
		}
		
		if(canStartGameTime < Time.time && !canStartGame)
		{
			Tap.touch = false;
			canStartGame = true;
			//start = false;
		}
		
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		
		if(startGame)
		{
			HUD.gameObject.SetActive(true);
			gameLogo.gameObject.SetActive(false);
			tapToPlay.gameObject.SetActive(false);
			initialSpawn.gameObject.SetActive(true);
			StartHud.gameObject.SetActive(false);
		}
		
		if(gameOver)
		{
			controlButtons	.gameObject.SetActive(false);
			GameOverHud.gameObject.SetActive(true);
			HUD.gameObject.SetActive(false);
		}
	
	}
}
