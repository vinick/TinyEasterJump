using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class StartAdCount : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Advertisement.Initialize("13157");
		
		PlayerPrefs.SetInt("adMob", 1);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
