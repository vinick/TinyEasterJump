using UnityEngine;
using System.Collections;

public class BrokenPlatform : MonoBehaviour {
	
	public Transform plat;
	public Transform anim;
	public float offset;
	bool canDestroy;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}
	
	void OnTriggerStay(Collider other)
	{
		if(other.tag == "killBrokens")
		{
			canDestroy = true;
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if(other.tag == "killBrokens")
		{
			canDestroy = false;
		}
	}
	
	void CanDestroy()
	{
		if(canDestroy)
		{
			Instantiate(anim, 
				new Vector3(plat.position.x, plat.position.y + offset, plat.position.z), Quaternion.identity);
			Destroy(plat.gameObject);
		}
	}
}
