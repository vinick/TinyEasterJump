using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {
	
	public Transform otherTeleport;
	
	public float offSet;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			other.transform.position = new Vector3(otherTeleport.position.x + offSet, 
				other.transform.position.y,
				other.transform.position.z);
		}
	}
	
	void OnTriggerStay(Collider other)
	{
		if(other.tag == "Player")
		{
			other.transform.position = new Vector3(otherTeleport.position.x + offSet, 
				other.transform.position.y,
				other.transform.position.z);
		}
	}
}
