using UnityEngine;
using System.Collections;

public class CandyMagnets : MonoBehaviour {
	
	bool follow;
	
	Transform player;
	
	// Use this for initialization
	void Start () {
		
		follow = false;
	
		
		player = GameObject.FindWithTag("Player").transform;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(player.position.y > this.transform.position.y && RabbitController.candyMagnet)
		{
			follow = true;
		}
		
		if(follow)
		{
			
			this.transform.position = Vector3.Slerp(this.transform.position, player.transform.position, 0.75f);
			
			/*
			iTween.MoveTo(this.gameObject, iTween.Hash(
				"position", player.position,
				"time", 1,
				"delay", 0.5f,
				"easetype", iTween.EaseType.easeInBounce
				));
				*/
		}
	}
}
