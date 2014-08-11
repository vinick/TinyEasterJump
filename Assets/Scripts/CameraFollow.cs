using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public Transform target;
	bool followUp;
	public float offSet;
	
	public static bool followDown;
	
	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		
		this.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
		
		if(GameControl.startGame && !GameControl.gameOver)
		{
			if(followUp)
			{
				if(RabbitController.candyMagnet)
				{
					this.transform.position = 
						Vector3.Lerp(this.transform.position, 
									new Vector3(transform.position.x,target.position.y - offSet + 5, -10), 
									0.05f);
				}
				else
				{
					this.transform.position = 
						Vector3.Lerp(this.transform.position, 
									new Vector3(transform.position.x,target.position.y - offSet, -10), 
									0.05f);
				}
			}
			
			if(followDown && transform.position.y > 5)
			{
				this.transform.position = 
					Vector3.Lerp(this.transform.position, 
								new Vector3(transform.position.x,target.position.y - (offSet * 4), -10), 
								0.05f);
			}
			
			
			if(target.position.y >= this.transform.position.y + 1f)
			{
				followUp = true;
			}
			else
			{
				followUp = false;
			}
			
			if(target.position.y < this.transform.position.y - 3f)
			{
				followDown = true;
			}
		}
	
	}
}
