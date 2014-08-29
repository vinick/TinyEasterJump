using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIFade : MonoBehaviour {

	public CanvasGroup target;
	bool fade;

	// Use this for initialization
	void Start () {
		fade = true;
	}
	
	// Update is called once per frame
	void Update () {

		if(fade)
		{
			if(target.alpha > 0)
			{
				target.alpha -= (Time.deltaTime / 2);
			}
			else
			{
				fade = false;
			}
		}
		else
		{
			if(target.alpha < 1)
			{
				target.alpha += (Time.deltaTime / 2);
			}
			else
			{
				Application.LoadLevel("MainScene");
			}
		}


	}
}
