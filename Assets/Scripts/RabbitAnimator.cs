using UnityEngine;
using System.Collections;

public class RabbitAnimator : MonoBehaviour {
	
	public static bool canJump;
	
	public static bool die;
	
	Animator anim;
	
	// Use this for initialization
	void Start () {
		canJump = false;
		die = false;
		anim = GetComponent<Animator>();
		
	
	}
	
	// Update is called once per frame
	void Update () {
		if(canJump)
		{
			anim.speed = 0.6f;
			canJump = false;
			anim.Play("jump");
		}
		
		if(die)
		{
			anim.speed = 1f;
			anim.Play("death");
		}
		
		
	}
}
