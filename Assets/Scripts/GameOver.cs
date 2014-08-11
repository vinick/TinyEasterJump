using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	
	public tk2dTextMesh currentEggs;
	public tk2dTextMesh currentCandys;
	
	int currentEggsAmount;
	int currentCandysAmount;
	
	public tk2dTextMesh sessionEggs;
	public tk2dTextMesh sessionCandys;
	public tk2dTextMesh sessionScore;
	
	public Transform restartButton;
	
	int sessionScoreAmount;
	int sessionEggsAmount;
	int sessionCandysAmount;
	
	public Transform eggDestinyPosition;
	public Transform spawnEggPosition;
	public Transform eggPrefab;
	
	float timeToNextEgg;
	float timeToNextCandy;
	
	bool gameOverProcess;
	
	public GameObject plusOne;
	
	public tk2dTextMesh maxScore;
	
	public Transform newRecordHud;
	
	int candyLeft;
	public static bool skip;
	
	public Transform helpGameover;
	
	// Use this for initialization
	void Start () {
		timeToNextEgg = Time.time + 0.5f;
		timeToNextCandy = Time.time + 0.5f;
		gameOverProcess = false;
		
		restartButton.gameObject.SetActive(false);
		newRecordHud.gameObject.SetActive(false);
		
		skip = false;

	}
	
	// Update is called once per frame
	void Update () {
		
		if(NewRecord.newRecord)
		{
			PlayerPrefs.SetInt("newRecord", 1);
			newRecordHud.gameObject.SetActive(true);
		}
		
		if(GameControl.gameOver && !gameOverProcess)
		{
			
			gameOverProcess = true;
			
			sessionScoreAmount = RabbitScore.intHeight;
			sessionEggsAmount = RabbitScore.eggAmount;
			sessionCandysAmount = RabbitScore.candyAmount;
			
			sessionScore.text = sessionScoreAmount.ToString();
			sessionScore.Commit();
			
			sessionEggs.text = sessionEggsAmount.ToString();
			sessionEggs.Commit();
			
			sessionCandys.text = sessionCandysAmount.ToString();
			sessionCandys.Commit();
			
			
			currentEggsAmount = PlayerPrefs.GetInt("currentEggs");
			currentEggs.text = currentEggsAmount.ToString();
			currentEggs.Commit();
			
			currentCandysAmount = PlayerPrefs.GetInt("currentCandys");
			currentCandys.text = currentCandysAmount.ToString();
			currentCandys.Commit();
			
			maxScore.text = (PlayerPrefs.GetInt("maxScore")).ToString();
			maxScore.Commit();
			
			candyLeft = sessionCandysAmount;
		}
		
		if(sessionEggsAmount > 0 && timeToNextEgg < Time.time)
		{
			Transform tempEgg = 
				Instantiate(eggPrefab, spawnEggPosition.position, Quaternion.Euler(-90, 0, 0)) as Transform;
			
			tempEgg.localScale *= 0.7f;
			
			iTween.MoveTo(tempEgg.gameObject, iTween.Hash(
				"position", eggDestinyPosition,
				"time", 0.5f,
				"easetype", iTween.EaseType.easeOutCubic
				));
			
			timeToNextEgg = Time.time + 0.55f;
			Destroy(tempEgg.gameObject, 0.55f);
			
			currentEggsAmount++;
			PlayerPrefs.SetInt("currentEggs", currentEggsAmount);
			currentEggs.text = currentEggsAmount.ToString();
			currentEggs.Commit();
			
			sessionEggsAmount--;
			sessionEggs.text = sessionEggsAmount.ToString();
			sessionEggs.Commit();
		}
		else if(sessionEggsAmount <= 0 && sessionCandysAmount > 0 && timeToNextCandy < Time.time && timeToNextEgg + 0.5f < Time.time)
		{
			if(skip && sessionCandysAmount%10 == 0)
			{
				sessionCandysAmount -= 10;
				currentCandysAmount += 10;
			}
			else
			{
				sessionCandysAmount--;
				currentCandysAmount++;
			}
			
			
			sessionCandys.text = sessionCandysAmount.ToString();
			sessionCandys.Commit();
			
			
			PlayerPrefs.SetInt("currentCandys", currentCandysAmount);
			currentCandys.text = currentCandysAmount.ToString();
			currentCandys.Commit();
			
			if(currentCandysAmount >= 100)
			{
				currentCandysAmount = 0;
				PlayerPrefs.SetInt("currentCandys", currentCandysAmount);
				currentCandys.text = currentCandysAmount.ToString();
				currentCandys.Commit();
				
				Instantiate(plusOne, 
					new Vector3(currentCandys.transform.position.x - 0.35f,
								currentCandys.transform.position.y, 
								currentCandys.transform.position.z), 
					Quaternion.identity);
				
				currentEggsAmount++;
				PlayerPrefs.SetInt("currentEggs", currentEggsAmount);
				currentEggs.text = currentEggsAmount.ToString();
				currentEggs.Commit();
			}
			
			timeToNextCandy = Time.time + 0.05f;
		}
		else if(sessionCandysAmount <= 0 && timeToNextCandy + 0.5f < Time.time)
		{
			helpGameover.collider.enabled = true;
			restartButton.gameObject.SetActive(true);
		}
	}
	
	public void PlusOne()
	{
		Instantiate(plusOne, 
					new Vector3(currentCandys.transform.position.x - 0.35f,
								currentCandys.transform.position.y, 
								currentCandys.transform.position.z), 
					Quaternion.identity);
	}
}
