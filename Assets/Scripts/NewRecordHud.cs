using UnityEngine;
using System.Collections;

public class NewRecordHud : MonoBehaviour {

	public float timeToBlink;
	float timing;
	
	int onOff;
	
	// Use this for initialization
	void Start () {
		timing = Time.time + timeToBlink;
		onOff = 1;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(onOff == 1)
		{
			this.renderer.enabled = true;
		}
		else if(onOff == -1)
		{
			this.renderer.enabled = false;
		}
		
		if(timing < Time.time)
		{
			onOff *= -1;
			timing = Time.time + timeToBlink;
		}
	
	}
}
