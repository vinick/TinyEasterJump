using UnityEngine;
using System.Collections;

public class KillRabbit : MonoBehaviour {
	
	public static bool revive;
	public Transform chocoRevive;
	
	public Transform rabbitCollider;
	
	// Use this for initialization
	void Start () {
		
		revive = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "killBrokens" && BoostControl.boost4)
		{
			chocoRevive.gameObject.SetActive(true);
			rabbitCollider.collider.enabled = true;
			RabbitController.dead = false;
			RabbitController.imune = true;
			RabbitAnimator.die = false;
			RabbitAnimator.canJump = true;
			BoostControl.boost4 = false;
			DeadFall.fallTeleporter = true;
			revive = true;
		}
		else
		{
			if(other.tag == "killBrokens")
			{
				GameControl.gameOver = true;
			}
		}
	}
}
