using UnityEngine;
using System.Collections;

public class PlusOne : MonoBehaviour {
	
	public float amount;
	
	// Use this for initialization
	void Start () {
		
		iTween.MoveBy(this.gameObject, iTween.Hash(
			"y", amount,
			"time", 1f,
			"easetype", iTween.EaseType.easeOutBounce
			));
		
		Destroy(this.gameObject, 1);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
