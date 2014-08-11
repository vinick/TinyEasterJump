using UnityEngine;
using System.Collections;

public class NotEnoughEggs : MonoBehaviour {

	public float timeToBlink;
	float timing;
	
	int onOff;
	
	tk2dTextMesh text;
	
	float timer;
	
	// Use this for initialization
	void Start () {
		timing = Time.time + timeToBlink;
		onOff = 1;
		
		text = GetComponent<tk2dTextMesh>();
		
		timer = Time.time;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(timer > Time.time)
		{
			if(onOff == 1)
			{
				//this.renderer.material.color = Color.white;
				text.color = Color.white;
			}
			else if(onOff == -1)
			{
				//this.renderer.material.color = Color.red;
					text.color = Color.red;
			}
			
			if(timing < Time.time)
			{
				onOff *= -1;
				timing = Time.time + timeToBlink;
			}
		}
		else
		{
			onOff = 1;
			text.color = Color.white;
		}
	}
	
	void NotEnough()
	{
		timer = Time.time + 0.9f;
	}
}
