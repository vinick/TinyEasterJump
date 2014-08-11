using UnityEngine;
using System.Collections;

public class FumacinhaSpeed : MonoBehaviour {
	
	Animator anim;
	
	// Use this for initialization
	void Start () {
		
		anim = GetComponent<Animator>();
		
		anim.speed = 2;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
