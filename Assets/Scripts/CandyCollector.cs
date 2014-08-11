using UnityEngine;
using System.Collections;

public class CandyCollector : MonoBehaviour {
	
	public Transform pow;
	public AudioClip monsterHit;
	public AudioClip eggNhack;
	public AudioClip [] candyNhack;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "candy")
		{
			audio.clip = candyNhack[Random.Range(0, 9)];
			audio.volume = 1;
			audio.Play();
			RabbitScore.candyAmount++;
			Destroy(other.gameObject);
			if(!RabbitController.candyMagnet)
			{
				RabbitController.candyBoost = true;
			}
		}
		
		if(other.tag == "easterEgg")
		{
			audio.clip = eggNhack;
			audio.volume = 1;
			audio.Play();
			RabbitScore.eggAmount++;
			if(!RabbitController.candyMagnet)
			{
				RabbitController.eggBoost = true;
			}
			Destroy(other.gameObject);
		}
		
		if(other.tag == "enemy" && !RabbitController.imune)
		{
			audio.clip = monsterHit;
			audio.volume = 0.6f;
			audio.Play();
			Instantiate(pow, this.transform.position + new Vector3(0,0,-2), Quaternion.identity);
			
			RabbitController.dead = true;
			//this.collider.enabled = false;
			//this.collider.isTrigger = true;
		}
		
		if(other.tag == "caution")
		{
			//Destroy(other.gameObject);
		}
	}
	
	public void TurnOnCollider()
	{
		this.collider.enabled = true;
	}
}
