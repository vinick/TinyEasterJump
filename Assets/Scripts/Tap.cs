using UnityEngine;
using System.Collections;

public class Tap : MonoBehaviour {
	
	public Transform startTap;
	public Transform pauseTap;
	public Transform resumePauseTap;
	public Transform restartPauseTap;
	public Transform restartGameOverTap;
	public Transform boostTap;
	public Transform cancelBoostTap;
	public Transform acceptBoostTap;
	
	public Transform boost01Tap;
	public Transform boost02Tap;
	public Transform boost03Tap;
	public Transform boost04Tap;
	
	public Transform boost01SelectedTap;
	public Transform boost02SelectedTap;
	
	public GameObject boostControl;
	
	public static bool touch;
	
	public Transform skipButton;
	public Transform boostGameOver;
	
	public Transform myImpactStarter;
	GameObject myImpact;
	
	public Transform gameMode01;
	public Transform gameMode02;
	public Transform chooseControl;
	public Transform hudStart;
	
	public Transform RightButton;
	public Transform LeftButton;
	public Transform controlButtons;
	
	// Use this for initialization
	void Start () {
		myImpact = GameObject.FindWithTag("myImpact");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnEnable(){
		EasyTouch.On_TouchStart += On_SimpleTap;
		EasyTouch.On_TouchDown += On_TouchDown;
		EasyTouch.On_TouchUp += On_TouchUp;
	}

	void OnDisable(){
		UnsubscribeEvent();
	}
	
	void OnDestroy(){
		UnsubscribeEvent();
	}
	
	void UnsubscribeEvent(){
		EasyTouch.On_TouchStart -= On_SimpleTap;	
	}
	
	private void On_SimpleTap( Gesture gesture){
		
		if(gesture.pickObject == startTap.gameObject && GameControl.canStartGame && !BoostControl.boostTime)
		{
			BoostControl.canBoost = false;
			//GameControl.start = true;
			//touch = true;
			startTap.gameObject.SetActive(false);
			hudStart.gameObject.SetActive(false);
			chooseControl.gameObject.SetActive(true);
		}
		
		if(gesture.pickObject == gameMode01.gameObject)
		{
			audio.Play();
			GameControl.accControl = true;
			chooseControl.gameObject.SetActive(false);
			touch = true;
		}
		
		if(gesture.pickObject == gameMode02.gameObject)
		{
			audio.Play();
			controlButtons.gameObject.SetActive(true);
			GameControl.accControl = false;
			chooseControl.gameObject.SetActive(false);
			touch = true;
		}
		
		if(gesture.pickObject == pauseTap.gameObject)
		{
			audio.Play();
			PauseScript.pauseGame = true;
		}
		
		if(gesture.pickObject == resumePauseTap.gameObject)
		{
			audio.Play();
			PauseScript.pauseGame = false;
		}
		
		if(gesture.pickObject == restartPauseTap.gameObject)
		{
			audio.Play();
			Application.LoadLevel("MainScene");
		}
		
		if(gesture.pickObject == restartGameOverTap.gameObject)
		{
			audio.Play();
			Application.LoadLevel("MainScene");
		}
		
		if(gesture.pickObject == boostTap.gameObject)
		{
			audio.Play();
			BoostControl.boostTime = true;
		}
		
		if(gesture.pickObject == cancelBoostTap.gameObject)
		{
			BoostControl.boostTime = false;
		}
		
		if(gesture.pickObject == boost01Tap.gameObject && BoostControl.canSelectBoost)
		{
			boostControl.SendMessage("SelectBoost", 1, SendMessageOptions.DontRequireReceiver);
		}
		
		if(gesture.pickObject == boost02Tap.gameObject && BoostControl.canSelectBoost)
		{
			boostControl.SendMessage("SelectBoost", 2, SendMessageOptions.DontRequireReceiver);
		}
		
		if(gesture.pickObject == boost03Tap.gameObject && BoostControl.canSelectBoost)
		{
			boostControl.SendMessage("SelectBoost", 3, SendMessageOptions.DontRequireReceiver);
		}
		
		if(gesture.pickObject == boost04Tap.gameObject && BoostControl.canSelectBoost)
		{
			boostControl.SendMessage("SelectBoost", 4, SendMessageOptions.DontRequireReceiver);
		}
		
		if(gesture.pickObject == boost01SelectedTap.gameObject && BoostControl.isSelected01)
		{
			boostControl.SendMessage("UnSelectBoost", 1, SendMessageOptions.DontRequireReceiver);
		}
		
		if(gesture.pickObject == boost02SelectedTap.gameObject && BoostControl.isSelected02)
		{
			boostControl.SendMessage("UnSelectBoost", 2, SendMessageOptions.DontRequireReceiver);
		}
		
		if(gesture.pickObject == acceptBoostTap.gameObject)
		{
			audio.Play();
			BoostControl.boostWasSelected = true;
		}
		
		if(gesture.pickObject == skipButton.gameObject)
		{
			GameOver.skip = true;
		}
		
		if(gesture.pickObject == boostGameOver.gameObject)
		{
			PlayerPrefs.SetInt("boostGameOver", 1);
			Application.LoadLevel("MainScene");
		}
		
		if(gesture.pickObject == myImpactStarter.gameObject)
		{
			audio.Play();
			myImpact.SendMessage("ShowVideoAd", SendMessageOptions.DontRequireReceiver);
		}
		
	}
	
	private void On_TouchDown(Gesture gesture)
	{
		
		if (RightButton != null &&  gesture.pickObject == RightButton.gameObject)
		{
			RabbitController.direction = -1;
		}
		else if (LeftButton != null && gesture.pickObject == LeftButton.gameObject)
		{
			RabbitController.direction = 1;
		}
	}
	
	private void On_TouchUp(Gesture gesture)
	{
		if (RightButton != null && gesture.pickObject == RightButton.gameObject)
		{
			RabbitController.direction = 0;
		}
		else if (LeftButton != null && gesture.pickObject == LeftButton.gameObject)
		{
			RabbitController.direction = 0;
		}
	}
}
