using UnityEngine;
using System.Collections;

public class SmokeScript : MonoBehaviour {
	
	public Transform smoke;
	public Transform smokeParado;
	public Transform rabbit;
	
	float previousPosition;
	
	public static bool touchGround;
	
	public Transform smokeParent;
	public float offset;
	public float xOffset;
	
	// Use this for initialization
	void Start () {
		previousPosition = rabbit.position.x;
		touchGround = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(!GameControl.startGame)
		{
			if(rabbit.position.x > previousPosition)
			{
				smoke.gameObject.SetActive(true);
				this.transform.localScale = new Vector3(-1, 1, 1);
			}
			else if(rabbit.position.x < previousPosition)
			{
				smoke.gameObject.SetActive(true);
				this.transform.localScale = new Vector3(1, 1, 1);
			}
			else
			{
				smoke.gameObject.SetActive(false);
			}
			
			previousPosition = rabbit.position.x;
		}
		else
		{
			smoke.gameObject.SetActive(false);
			smokeParent.parent = null;
			if(touchGround)
			{
				smokeParent.transform.position = 
					new Vector3(rabbit.position.x - xOffset, rabbit.position.y - offset, smokeParent.transform.position.z);
				touchGround = false;
				//smokeParado.gameObject.SetActive(true);
				//SmokeAnim.canSmoke = true;
				
				Transform tempSmoke = Instantiate(smokeParado, smokeParent.position, Quaternion.identity) as Transform;
				tempSmoke.localScale *= 0.3f;
				Destroy(tempSmoke.gameObject, 0.25f);
			}
			/*
			else if(!SmokeAnim.canSmoke)
			{
				smokeParado.gameObject.SetActive(false);
			}
			*/
		}
	
	}
}
