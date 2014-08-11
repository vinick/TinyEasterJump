using UnityEngine;
using System.Collections;

public class CautionScript : MonoBehaviour {
	
	public Transform enemy;
	Transform cam;
	public float offSet;
	
	bool followCam;
	public float camOffset;
	bool playAudio;
	
	// Use this for initialization
	void Start () {
		followCam = false;
		
		cam = GameObject.FindWithTag("MainCamera").transform;
		
		playAudio = false;
	
	}
	
	
	// Update is called once per frame
	void Update () 
	{
		if(followCam)
		{
			this.transform.position = 
				new Vector3(this.transform.position.x, cam.position.y + offSet, this.transform.position.z);
		}
		
		if(enemy.position.y <= cam.position.y + camOffset)
		{
			followCam = true;
			if(!playAudio)
			{
				playAudio = true;
				enemy.audio.PlayDelayed(0);
			}
		}
		
		if(GameControl.gameOver)
		{
			this.gameObject.renderer.enabled = false;
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "enemy")
		{
			Destroy(this.gameObject);
		}
	}
}
