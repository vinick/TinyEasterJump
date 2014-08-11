using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float speed;
	public float offSet;
	
	Transform leftLimit;
	Transform rightLimit;
	
	bool goRight;
	
	public Transform freeze;
	bool isFreezed;
	
	// Use this for initialization
	void Start () {
		isFreezed = false;
		
		leftLimit = GameObject.FindWithTag("limitLeft").transform;
		rightLimit = GameObject.FindWithTag("limitRight").transform;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(!BoostControl.boost3)
		{
			if(goRight)
			{
				this.transform.Translate(Vector3.left * speed * Time.deltaTime);
			}
			else
			{
				this.transform.Translate(Vector3.right * speed * Time.deltaTime);
			}
			
			if(this.transform.position.x >= rightLimit.position.x - offSet)
			{
				goRight = false;
			}
			else if(this.transform.position.x <= leftLimit.position.x + offSet)
			{
				goRight = true;
			}
		}
		else if(!isFreezed)
		{
			isFreezed = true;
			
			Transform tempFreeze = Instantiate(freeze, this.transform.position, Quaternion.identity) as Transform;
			tempFreeze.parent = this.transform;
		}
	}
}
