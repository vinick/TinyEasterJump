using UnityEngine;
using System.Collections;

public class NewRecord : MonoBehaviour {
	
	public float offset;
	
	public static bool newRecord;
	
	bool sessionRecord;
	
	// Use this for initialization
	void Start () {
		sessionRecord = false;
		newRecord = false;
		//this.gameObject.renderer.enabled = false;
		
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(GameControl.startGame && PlayerPrefs.HasKey("newRecord"))
		{
			//this.gameObject.renderer.enabled = true;
			this.transform.position = 
				new Vector3(this.transform.position.x, PlayerPrefs.GetInt("maxScore")/10 + 4 + offset, 0.2f);
		}
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "rabbitCollider" && !sessionRecord && PlayerPrefs.HasKey("newRecord"))
		{
			sessionRecord = true;
			audio.Play();
			this.gameObject.renderer.enabled = false;
			//Destroy(this.gameObject, 0.5f);
		}
	}
	
}
