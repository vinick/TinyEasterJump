using UnityEngine;
using System.Collections;

public class FadeInFadeOut : MonoBehaviour {
	
	public Transform target;
	public float fadeTime;
	public float delayTime;
	public bool hasFadeOut;
	
	// Use this for initialization
	void Start () {
		Fade(fadeTime, delayTime, hasFadeOut);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Fade(float time, float delay, bool fadeOut)
	{
		iTween.FadeTo(target.gameObject, 0, time);
		
		if(fadeOut)
		{
			iTween.FadeTo(target.gameObject, iTween.Hash(
				"amount", 1,
				"time", time,
				"delay", delay,
				"oncomplete", "NextScene"
				));
		}
	}
	
	void NextScene()
	{
		Application.LoadLevel("MainScene");
	}
}
