using UnityEngine;
using System.Collections;

public class ChocoRevive : MonoBehaviour {
	
	public Transform rabbit;
	
	// Use this for initialization
	void Start () {
		
		iTween.MoveTo(this.gameObject, iTween.Hash(
			"position", new Vector3(this.transform.position.x, this.transform.position.y + 0.5f, this.transform.position.z),
			"time", 0.5f,
			"easetype", iTween.EaseType.linear
			));
	
	}
	
	// Update is called once per frame
	void Update () {
		
		this.transform.position = new Vector3(rabbit.position.x, this.transform.position.y, this.transform.position.z);
	
	}
}
