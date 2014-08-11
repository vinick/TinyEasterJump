using UnityEngine;
using System.Collections;

public class DeadFall : MonoBehaviour {
	
	public Transform Destroyer;
	
	public static bool fallTeleporter;
	
	// Use this for initialization
	void Start () {
		
		fallTeleporter = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(this.transform.position.y < Destroyer.position.y)
		{
			this.transform.position = Destroyer.position;
		}
		
		if(fallTeleporter)
		{
			fallTeleporter = false;
			this.transform.position = Destroyer.position;
		}
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "rabbitCollider" && !RabbitController.imune)
		{
			audio.Play();
			RabbitAnimator.die = true;
		}
	}
}
