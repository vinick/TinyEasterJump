using UnityEngine;
using System.Collections;

public class MovedPlatform : MonoBehaviour {
	
	public float speed;
	public float offSet;
	
	Transform leftLimit;
	Transform rightLimit;
	
	bool goRight;
	
	// Use this for initialization
	void Start () {
		
		leftLimit = GameObject.FindWithTag("limitLeft").transform;
		rightLimit = GameObject.FindWithTag("limitRight").transform;
	
	}
	
	// Update is called once per frame
	void Update () {
		
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
}
