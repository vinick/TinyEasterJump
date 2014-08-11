using UnityEngine;
using UnityEngine.Advertisements;

public class AdvancedExample : MonoBehaviour
{
	int showCount = 0;

	private void Start()
	{
		//Initialize with your appid and appsignature. 
		Advertisement.Initialize("app_id", "app_signature");
	}

	void OnGUI()
	{
		//Available count lets us know  how many interstitials we have to show. If this is zero, you will get an error upon calling show
		GUILayout.Label("availableCount: " + Advertisement.availableCount);
		
		//Setting prefetch lets you tell us how many interstitials to queue up in advance. This can be useful to avoid loading times. Default is 1.
		GUILayout.Label("prefetchCount: " + Advertisement.prefetchCount);
		if (GUILayout.Button("+"))
			Advertisement.prefetchCount++;
		if (GUILayout.Button("-"))
			Advertisement.prefetchCount--;

		if (GUILayout.Button("show"))
		{
			showCount++;
			int localCount = showCount;
			
			//ShowOptions has two values: resultCallback, a callback which returns one of Closed, Failed or Clicked
			//  and pause, which tells us whether or not to pause the app while showing an interstitial.
			//  pause is true by default
			ShowOptions opts = new ShowOptions
			{
				resultCallback = result => Debug.Log("show " + localCount + ": " + result)
			};

			//Ensure an interstitial is ready
			if (Advertisement.availableCount > 0)
				Advertisement.Show(opts);
		    //When calling show, if any errors were received by failed downloads, wrong urls, etc.
			//It will iterate through those errors until it finds an interstitial to show.
		}
	}
}
