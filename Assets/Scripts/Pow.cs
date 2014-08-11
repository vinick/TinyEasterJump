using UnityEngine;
using System.Collections;

public class Pow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		iTween.ScaleTo(this.gameObject, this.transform.localScale * 3, 0.1f);
		Destroy(this.gameObject, 0.2f);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
