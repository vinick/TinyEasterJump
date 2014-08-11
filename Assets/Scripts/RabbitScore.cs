using UnityEngine;
using System.Collections;

public class RabbitScore : MonoBehaviour {
	
	public Transform rabbit;
	public tk2dTextMesh score;
	public tk2dTextMesh candyScore;
	public tk2dTextMesh eggScore;
	
	float maxHeight;
	public static int intHeight;
	
	public static int candyAmount;
	public static int eggAmount;
	
	public Transform floor;
	
	int maxScore;
	
	public Transform newRecord;
	
	// Use this for initialization
	void Start () {
		maxHeight = 0;
		intHeight = 0;
		candyAmount = 0;
		eggAmount = 0;
		
		maxScore = PlayerPrefs.GetInt("maxScore");
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(intHeight >= 60 && floor != null)
		{
			Destroy(floor.gameObject);
		}
		
		if(rabbit.position.y > maxHeight + 0.3f)
		{
			if(BoostControl.boost1)
			{
				maxHeight += 0.2f;
			}
			else
			{
				maxHeight += 0.1f;
			}
		}
		
		intHeight = (int)(maxHeight*10);
		score.text = intHeight.ToString();
		score.Commit();
		
		if(intHeight > maxScore)
		{
			NewRecord.newRecord = true;
			maxScore = intHeight;
			PlayerPrefs.SetInt("maxScore", maxScore);
		}
		
		candyScore.text = candyAmount.ToString();
		candyScore.Commit();
		eggScore.text = eggAmount.ToString();
		eggScore.Commit();
		
	}
}
