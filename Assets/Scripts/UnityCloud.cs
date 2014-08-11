using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class UnityCloud : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
#if UNITY_ANDROID
		Advertisement.Initialize("02315e60931bc4d1", "c0b990db225f86c2");
#endif
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(GameControl.gameOver && Advertisement.availableCount > 0)
		{
			Advertisement.Show();
		}
	
	}
}
