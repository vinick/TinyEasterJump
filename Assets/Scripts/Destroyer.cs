using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "canDestroy" || other.tag == "candy" || other.tag == "enemy" || other.tag == "easterEgg")
		{
			Destroy(other.gameObject);
		}
	}
}
