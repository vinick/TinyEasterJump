using UnityEngine;
using System.IO;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
[InitializeOnLoad]
#endif

public class SocialPlatfromSettings : ScriptableObject {

	public const string VERSION_NUMBER = "3.1";

	public bool showPermitions = true;
	public List<string> fb_scopes_list =  new List<string>();
	

	//private string TWITTER_CONSUMER_KEY = "wEvDyAUr2QabVAsWPDiGwg";
	//private string TWITTER_CONSUMER_SECRET = "igRxZbOrkLQPNLSvibNC3mdNJ5tOlVOPH3HNNKDY0";

	public string TWITTER_CONSUMER_KEY 	= "REPLACE_WITH_YOUR_CONSUMER_KEY";
	public string TWITTER_CONSUMER_SECRET 	= "REPLACE_WITH_YOUR_CONSUMER_SECRET";
	

	private const string ISNSettingsAssetName = "SocialSettings";
	private const string ISNSettingsPath = "Extensions/GooglePlayCommon/Resources";
	private const string ISNSettingsAssetExtension = ".asset";

	

	
	private static SocialPlatfromSettings instance = null;
	
	
	public static SocialPlatfromSettings Instance {
		
		get {
			if (instance == null) {
				instance = Resources.Load(ISNSettingsAssetName) as SocialPlatfromSettings;
				
				if (instance == null) {
					
					// If not found, autocreate the asset object.
					instance = CreateInstance<SocialPlatfromSettings>();
					#if UNITY_EDITOR
					string properPath = Path.Combine(Application.dataPath, ISNSettingsPath);
					if (!Directory.Exists(properPath)) {
						AssetDatabase.CreateFolder("Extensions/", "GooglePlayCommon");
						AssetDatabase.CreateFolder("Extensions/GooglePlayCommon", "Resources");
					}
					
					string fullPath = Path.Combine(Path.Combine("Assets", ISNSettingsPath),
					                               ISNSettingsAssetName + ISNSettingsAssetExtension
					                               );
					
					AssetDatabase.CreateAsset(instance, fullPath);
					#endif
				}
			}
			return instance;
		}
	}


	public string fb_scopes {
		get {
			string scopes = "";
			foreach(string s in fb_scopes_list) {
				scopes+= s + ",";
			}

			if(scopes.Length > 0) {
				scopes = scopes.Substring(0, scopes.Length - 1);
			}

			return scopes;
		}
	}
	


}

