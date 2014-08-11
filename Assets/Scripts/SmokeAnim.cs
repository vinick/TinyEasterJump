using UnityEngine;
using System.Collections;

public class SmokeAnim : MonoBehaviour {
	
	public static bool canSmoke;
	
	Animator anim;
	
	float timing;
	
	// Use this for initialization
	void Start () {
		canSmoke = false;
		anim = GetComponent<Animator>();
		timing = Time.time;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(canSmoke && timing < Time.time)
		{
			//canSmoke = false;
			timing = Time.time + 0.7f;
			
			this.transform.position = 
				new Vector3( this.transform.parent.position.x, this.transform.position.y, this.transform.position.z);
			anim.speed = 2;
			
			anim.Play("fumacinha2");
			
		}
		
		//if(anim.GetCurrentAnimatorStateInfo(0).nameHash == Animator.StringToHash("Base.Nothing"))
		if(timing < Time.time)
		{
			this.gameObject.SetActive(false);
			//canSmoke = false;
		}
	
	}
}
