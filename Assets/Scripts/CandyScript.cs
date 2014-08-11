using UnityEngine;
using System.Collections;

public class CandyScript : MonoBehaviour {
	
	public float amountShake;
	public float timing;
	
	public Texture [] images;
	
	public float transShake;
	public float transTiming;
	
	public bool easterEgg;
	
	// Use this for initialization
	void Start () {
		if(easterEgg)
		{
			this.renderer.material.mainTexture = images[Random.Range(0,10)];
		}
		else
		{
			this.renderer.material.mainTexture = images[Random.Range(0,8)];
		}
		
		iTween.RotateBy(this.gameObject, iTween.Hash(
			"y", amountShake/2,
			"time", timing/2,
			"easetype", iTween.EaseType.easeInCubic,
			"oncomplete", "Shake02"
			));
		
	
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}
	
	void Shake01()
	{
		iTween.RotateBy(this.gameObject, iTween.Hash(
			"y", amountShake,
			"time", timing,
			"easetype", iTween.EaseType.easeOutBounce,
			"oncomplete", "Shake02"
			));
		
		if(!easterEgg)
		{
			this.transform.position = Vector3.Slerp(this.transform.position, 
				new Vector3(transform.position.x + transShake, transform.position.y, transform.position.z), transTiming);
		}
	}
	
	void Shake02()
	{
		iTween.RotateBy(this.gameObject, iTween.Hash(
			"y", -amountShake,
			"time", timing,
			"easetype", iTween.EaseType.easeOutBounce,
			"oncomplete", "Shake01"
			));
		
		if(!easterEgg)
		{
			this.transform.position = Vector3.Slerp(this.transform.position, 
				new Vector3(transform.position.x - transShake, transform.position.y, transform.position.z), transTiming);
		}
	}
}
