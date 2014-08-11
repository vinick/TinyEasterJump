using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
	
	public Transform platform;
	public Transform brokenPlatform;
	public Transform movedPlatform;
	public Transform [] candy;
	public Transform easterEgg;
	public Transform enemy;
	
	public Transform leftLimitScreen;
	public Transform rightLimitScreen;
	
	public bool start;
	
	public Transform rabbit;
	
	public float offset;
	public float limitOffset;
	
	public float valueNextBlock;
	float nextBlock;
	
	public float valueNextEgg;
	float nextEgg;
	bool canEgg;
	
	public float valueNextEnemy;
	float nextEnemy;
	bool canEnemy;
	
	//public Transform initialPlat;
	
	// Use this for initialization
	void Start () {
		if(start)
			StartSpawn();
		
		nextBlock = valueNextBlock;
		canEgg = false;
		nextEnemy = valueNextEnemy;
		canEnemy = false;
		
		if(!BoostControl.boost1)
		{
			nextEgg += 20;
		}
		else
		{
			nextEgg += valueNextEgg;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(!start)
		{
			this.transform.position = new Vector3(0, rabbit.position.y + 7.5f, 0.2f);
			
			if(rabbit.position.y >= nextBlock)
			{
				nextBlock += valueNextBlock;
				SpawnBlock(Random.Range(0, 8));
				//SpawnBlock(1);
			}
			
			if(rabbit.position.y >= nextEgg)
			{
				if(BoostControl.boost2)
				{
					nextEgg += (valueNextEgg/2);
				}
				else
				{
					nextEgg += valueNextEgg;
				}
				canEgg = true;
			}
			
			if(rabbit.position.y >= nextEnemy)
			{
				nextEnemy += valueNextEnemy;
				canEnemy = true;
				/*
				if(valueNextEnemy >= 10)
				{
					valueNextEnemy--;
				}
				*/
			}
		}
	
	}
	
	void StartSpawn()
	{
		for(int i = 1; i <=8; i++)
		{
			Transform tempPlat = Instantiate(platform, 
				new Vector3(Random.Range(leftLimitScreen.position.x + limitOffset, rightLimitScreen.position.x - limitOffset), 
				this.transform.position.y + (offset * i), this.transform.position.z), Quaternion.Euler(0, 180, 0)) as Transform;
			
			//tempPlat.parent = initialPlat.transform;
			
			iTween.MoveTo(tempPlat.gameObject, iTween.Hash(
			"position", new Vector3(tempPlat.position.x, tempPlat.position.y - 9, tempPlat.position.z - 0.2f),
			"time", 2f,
			"easetype", iTween.EaseType.easeOutBounce,
			"delay", i/2f
			));
		}
		
		/*
		iTween.MoveTo(initialPlat.gameObject, iTween.Hash(
			"position", new Vector3(this.transform.position.x, 0, this.transform.position.z - 0.2f),
			"time", 1f,
			"easetype", iTween.EaseType.easeOutBounce,
			"delay", 0.3f
			));
			*/
	}
	
	void SpawnBlock(int type)
	{
		if(canEgg && type <= 3)
		{
			canEgg = false;
			Instantiate(easterEgg, 
					new Vector3(Random.Range(leftLimitScreen.position.x + limitOffset, rightLimitScreen.position.x - limitOffset), 
					this.transform.position.y + (offset + 0.5f), this.transform.position.z), Quaternion.Euler(-90, 0, 0));
		}
		
		if(canEnemy && type <= 3)
		{
			canEnemy = false;
			Instantiate(enemy, 
					new Vector3(Random.Range(leftLimitScreen.position.x + limitOffset, rightLimitScreen.position.x - limitOffset), 
					this.transform.position.y + (offset + 5f), this.transform.position.z - 0.2f), Quaternion.Euler(90, 180, 0));
		}
		
		switch(type)
		{
		case 0:
			for(int i = 1; i <= 4; i++)
			{
				int temp = Random.Range(1, 4);
				if(temp == 1)
				{
					Instantiate(platform, 
					new Vector3(Random.Range(leftLimitScreen.position.x + limitOffset, rightLimitScreen.position.x - limitOffset), 
					this.transform.position.y + (offset * i), this.transform.position.z), Quaternion.Euler(0, 180, 0));
				}
				else if(temp == 2)
				{
					Instantiate(brokenPlatform, 
					new Vector3(Random.Range(leftLimitScreen.position.x + limitOffset, rightLimitScreen.position.x - limitOffset), 
					this.transform.position.y + (offset * i), this.transform.position.z), Quaternion.Euler(0, 180, 0));
				}
				else if(temp == 3)
				{
					Instantiate(movedPlatform, 
					new Vector3(Random.Range(leftLimitScreen.position.x + limitOffset, rightLimitScreen.position.x - limitOffset), 
					this.transform.position.y + (offset * i), this.transform.position.z), Quaternion.Euler(0, 180, 0));
				}
			}
			break;
		case 1:
			for(int i = 1; i <= 4; i++)
			{
				Instantiate(platform, 
					new Vector3(Random.Range(leftLimitScreen.position.x + limitOffset, rightLimitScreen.position.x - limitOffset), 
					this.transform.position.y + (offset * i), this.transform.position.z), Quaternion.Euler(0, 180, 0));
			}
			break;
		case 2:
			for(int i = 1; i <= 4; i++)
			{
				if(i%3 == 0)
				{
					Instantiate(brokenPlatform, 
					new Vector3(Random.Range(leftLimitScreen.position.x + limitOffset, rightLimitScreen.position.x - limitOffset), 
					this.transform.position.y + (offset * i), this.transform.position.z), Quaternion.Euler(0, 180, 0));
				}
				else
				{
					Instantiate(platform, 
					new Vector3(Random.Range(leftLimitScreen.position.x + limitOffset, rightLimitScreen.position.x - limitOffset), 
					this.transform.position.y + (offset * i), this.transform.position.z), Quaternion.Euler(0, 180, 0));
				}
			}
			break;
		case 3:
			for(int i = 1; i <= 4; i++)
			{
				if(i%2 == 0)
				{
					Instantiate(movedPlatform, 
					new Vector3(Random.Range(leftLimitScreen.position.x + limitOffset, rightLimitScreen.position.x - limitOffset), 
					this.transform.position.y + (offset * i), this.transform.position.z), Quaternion.Euler(0, 180, 0));
				}
				else
				{
					Instantiate(platform, 
					new Vector3(Random.Range(leftLimitScreen.position.x + limitOffset, rightLimitScreen.position.x - limitOffset), 
					this.transform.position.y + (offset * i), this.transform.position.z), Quaternion.Euler(0, 180, 0));
				}
			}
			break;
		case 4:
			for(int i = 1; i <= 2; i++)
			{
				Instantiate(candy[0],
				new Vector3(Random.Range(leftLimitScreen.position.x + (limitOffset * 2), rightLimitScreen.position.x - (limitOffset * 2)), 
				this.transform.position.y + (offset * i * 1.5f), this.transform.position.z), Quaternion.Euler(0, 0, 0));
			}
			break;
		case 5:
			Instantiate(candy[1],
				new Vector3(this.transform.position.x, 
				this.transform.position.y + (offset * 2.5f), this.transform.position.z), Quaternion.Euler(0, 0, 0));
			break;
		case 6:
			Instantiate(candy[2],
				new Vector3(Random.Range(leftLimitScreen.position.x + (limitOffset * 2), rightLimitScreen.position.x - (limitOffset * 2)), 
				this.transform.position.y + (offset * 2.5f), this.transform.position.z), Quaternion.Euler(0, 0, 0));
			break;
		case 7:
			Instantiate(candy[3],
				new Vector3(this.transform.position.x, 
				this.transform.position.y + (offset * 2.5f), this.transform.position.z), Quaternion.Euler(0, 0, 0));
			break;
		}
	}
}
