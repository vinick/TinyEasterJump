using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class BasicExample : MonoBehaviour 
{
	public string nextScene  = "BasicNextScene";
	public float  interstitialDelay  = 1.0f;
	
	void Start () 
	{
		//Set your app_id and app_signature
		//Advertisement.Initialize("replace_with_app_id", "replace_with_app_signature");
		#if UNITY_ANDROID
		Advertisement.Initialize ("22232d6eb38dc95e", "50e170bf8e9aaffe");
		#elif UNITY_IPHONE
		Advertisement.Initialize ("57b640e0342d0da3", "47ec87c9e950a9ba");
		#endif
	}
	
	void Update ()
	{
		//Ensure we have an available interstitial to show
		if (Advertisement.availableCount > 0)
		{
			//ShowOptions has two values: resultCallback, a callback which returns one of Closed, Failed or Clicked
			//  and pause, which tells us whether or not to pause the app while showing an interstitial.
			//  pause is true by default
			ShowOptions showOptions = new ShowOptions()
			{
				resultCallback = OnInterstitialResult
			};
			
			//When calling show, if any errors were received by failed downloads, wrong urls, etc.
			//It will iterate through those errors until it finds an interstitial to show.
			Advertisement.Show(showOptions);
		}
	}
	
	private void OnInterstitialResult(ShowResult showResult)
	{
		Debug.Log("Interstitial Result: " + showResult);
		StartCoroutine(LoadNextScene());
	}
	
	IEnumerator LoadNextScene () 
	{
		yield return new WaitForSeconds (interstitialDelay);
		Application.LoadLevelAsync (nextScene);
	}
}
