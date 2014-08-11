using UnityEngine;
using System.Collections;

public class SpawnClouds : MonoBehaviour {
	
	public Transform leftLimitScreen;
	public Transform rightLimitScreen;
	
	public Transform rabbit;
	
	public Transform [] clouds;
	
	public float valueNextCloud;
	float nextCloud;
	
	public float offset;
	public float limitOffset;
	
	// Use this for initialization
	void Start () {
		
		nextCloud = valueNextCloud;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(rabbit.position.y >= nextCloud)
		{
			for(int i = 1; i <= 3; i++)
			{
				Instantiate(clouds[Random.Range(0, 9)], 
				new Vector3(Random.Range(leftLimitScreen.position.x + limitOffset, rightLimitScreen.position.x - limitOffset), 
				this.transform.position.y + Random.Range(-2.5f, 2.5f) + (offset * i), this.transform.position.z), Quaternion.Euler(90, 180, 0));
			}
			nextCloud += valueNextCloud;
			
			
		}
	
	}
}
