
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(GoogleMobileAdSettings))]
public class GoogleMobileAdSettingsEditor : Editor {


	
	
	GUIContent IOS_UnitAdId  	 = new GUIContent("Banners Ad Unit Id [?]:",  "IOS Banners Ad Unit Id ");
	GUIContent IOS_InterstAdId   = new GUIContent("Interstitials Ad Unit Id [?]:", "IOS Interstitials Ad Unit Id");

	GUIContent Android_UnitAdId  	 = new GUIContent("Banners Ad Unit Id [?]:",  "Android Banners Ad Unit Id ");
	GUIContent Android_InterstAdId   = new GUIContent("Interstitials Ad Unit Id [?]:", "Android Interstitials Ad Unit Id");

	GUIContent WP8_UnitAdId  	 = new GUIContent("Banners Ad Unit Id [?]:",  "WP8 Banners Ad Unit Id ");
	GUIContent WP8_InterstAdId   = new GUIContent("Interstitials Ad Unit Id [?]:", "WP8 Interstitials Ad Unit Id");



	
	GUIContent SdkVersion   = new GUIContent("Plugin Version [?]", "This is Plugin version.  If you have problems or compliments please include this so we know exactly what version to look out for.");
	GUIContent SupportEmail = new GUIContent("Support [?]", "If you have any technical quastion, feel free to drop an e-mail");


	private GoogleMobileAdSettings settings;

	private bool IsIOSSettinsOpened = true;
	private bool IsAndroidSettinsOpened = true;
	private bool IsWP8SettinsOpened = true;


	public override void OnInspectorGUI() {
		settings = target as GoogleMobileAdSettings;

		GUI.changed = false;




		MainSettings();
		EditorGUILayout.Space();
		AboutGUI();
	

		if(GUI.changed) {
			DirtyEditor();
		}
	}

	



	public void MainSettings() {

		EditorGUILayout.HelpBox("Google Mobile Ad Plugin", MessageType.None);
		EditorGUILayout.Space();

		IsIOSSettinsOpened = EditorGUILayout.Foldout(IsIOSSettinsOpened, "IOS");
		if(IsIOSSettinsOpened) {
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField(IOS_UnitAdId);
			settings.IOS_BannersUnitId	 	= EditorGUILayout.TextField(settings.IOS_BannersUnitId);
			EditorGUILayout.EndHorizontal();
			
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField(IOS_InterstAdId);
			settings.IOS_InterstisialsUnitId	 	= EditorGUILayout.TextField(settings.IOS_InterstisialsUnitId);
			EditorGUILayout.EndHorizontal();
		}


		IsAndroidSettinsOpened = EditorGUILayout.Foldout(IsAndroidSettinsOpened, "Android");
		if(IsAndroidSettinsOpened) {
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField(Android_UnitAdId);
			settings.Android_BannersUnitId	 	= EditorGUILayout.TextField(settings.Android_BannersUnitId);
			EditorGUILayout.EndHorizontal();
			
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField(Android_InterstAdId);
			settings.Android_InterstisialsUnitId	 	= EditorGUILayout.TextField(settings.Android_InterstisialsUnitId);
			EditorGUILayout.EndHorizontal();
		}



		IsWP8SettinsOpened = EditorGUILayout.Foldout(IsWP8SettinsOpened, "WP8");
		if(IsWP8SettinsOpened) {
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField(WP8_UnitAdId);
			settings.WP8_BannersUnitId	 	= EditorGUILayout.TextField(settings.WP8_BannersUnitId);
			EditorGUILayout.EndHorizontal();
			
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField(WP8_InterstAdId);
			settings.WP8_InterstisialsUnitId	 	= EditorGUILayout.TextField(settings.WP8_InterstisialsUnitId);
			EditorGUILayout.EndHorizontal();
		}
	}



	private void AboutGUI() {

		EditorGUILayout.HelpBox("Version Info", MessageType.None);
		EditorGUILayout.Space();
		
		SelectableLabelField(SdkVersion, GoogleMobileAdSettings.VERSION_NUMBER);
		SelectableLabelField(SupportEmail, "stans.assets@gmail.com");
		
		
	}
	
	private void SelectableLabelField(GUIContent label, string value) {
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.LabelField(label, GUILayout.Width(180), GUILayout.Height(16));
		EditorGUILayout.SelectableLabel(value, GUILayout.Height(16));
		EditorGUILayout.EndHorizontal();
	}



	private static void DirtyEditor() {
		#if UNITY_EDITOR
		EditorUtility.SetDirty(GoogleMobileAdSettings.Instance);
		#endif
	}
	
	
}
