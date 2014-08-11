using UnityEngine;
using System.Collections;

public class ScoreControl : MonoBehaviour {
	
	public static int score;
	public static int eggs;
	public static int candy;
	
	public string maxScore = "maxScore";
	public string currentEggs = "currentEggs";
	public string currentCandys = "currentCandys";
	
	public tk2dTextMesh totalEggs;
	public tk2dTextMesh bestcore;
	
	// Use this for initialization
	void Start () {
		
		if(!PlayerPrefs.HasKey(currentEggs))
		{
			PlayerPrefs.SetInt(currentEggs, 0);
		}
		
		if(!PlayerPrefs.HasKey(currentCandys))
		{
			PlayerPrefs.SetInt(currentCandys, 0);
		}
		
		if(!PlayerPrefs.HasKey("boostGameOver"))
		{
			PlayerPrefs.SetInt("boostGameOver", 0);
		}
		
		//PlayerPrefs.SetInt(maxScore, 100);
		/*
		if(PlayerPrefs.GetInt(currentEggs) < 1000)
		{
			PlayerPrefs.SetInt(currentEggs, 1000);
		}
		*/
	
	}
	
	// Update is called once per frame
	void Update () {
		
		totalEggs.text = (PlayerPrefs.GetInt(currentEggs)).ToString();
		totalEggs.Commit();
		
		bestcore.text = (PlayerPrefs.GetInt(maxScore)).ToString();
		bestcore.Commit();
	
	}
}
