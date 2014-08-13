using UnityEngine;
using System.Collections;

public class RabbitController : MonoBehaviour {
	
	public CharacterController rabbit;
	public float gravity;
	public float forceGravity;
	public float jumpForce;
	
	bool down;
	public static bool candyBoost;
	public static bool eggBoost;
	
	public static bool dead;

	float timeToDown;
	float defaultGravity;
	
	GameObject broken;
	
	public CandyCollector candyCollector;
	
	bool canBoost;
	bool boosting;
	
	public static bool imune;
	float imuneTime;
	bool immunityEnding;
	
	bool brokenEffect;
	float timeBrokenEffect;
	
	float trailTime;
	public Transform trail;
	
	public static bool candyMagnet;
	
	float timeToResetBoost;
	
	public AudioClip [] audios;
	
	bool turnOnCollider;
	float turnOnColliderTime;
	
	public static int direction;
	
	// Use this for initialization
	void Start () {
		down = true;
		candyBoost = false;
		eggBoost = false;
		dead = false;
		defaultGravity = gravity;
		
		canBoost = true;
		boosting = false;
		imune = false;
		immunityEnding = false;
		
		brokenEffect = false;
		trailTime = Time.time;
		
		candyMagnet = false;
		
		timeToResetBoost = Time.time;
		turnOnCollider = false;
		turnOnColliderTime = Time.time;
		
		direction = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(boosting && timeToResetBoost < Time.time)
		{
			boosting = false;
		}
		
		if(trailTime < Time.time)
		{
			trail.gameObject.SetActive(false);
			candyMagnet = false;
		}
		else
		{
			candyMagnet = true;
		}
		
		if(brokenEffect && timeBrokenEffect < Time.time)
		{
			brokenEffect = false;
		}
		
		if(imune && !immunityEnding)
		{
			immunityEnding = true;
			imuneTime = Time.time + 2;
		}
		
		if(immunityEnding && imuneTime < Time.time)
		{
			imune = false;
		}
		
		if(turnOnCollider && turnOnColliderTime < Time.time)
		{
			turnOnCollider = false;
			candyCollector.SendMessage("TurnOnCollider", SendMessageOptions.DontRequireReceiver);
		}
		
		if(dead)
		{
			RabbitAnimator.die = true;
			this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -1);
			iTween.Stop(this.gameObject);
			rabbit.Move(Vector3.down * gravity * Time.deltaTime);
			gravity += forceGravity;
		}
		else if(KillRabbit.revive)
		{
			KillRabbit.revive = false;
			down = false;
			
			iTween.Stop(this.gameObject);
			iTween.MoveBy(this.gameObject, iTween.Hash(
					"amount", new Vector3(0, jumpForce + 35, 0),
					"time", 1f,
					"easetype", iTween.EaseType.linear,
					"delay", 0.005f,
					"oncomplete", "EndBoost"
					));
			
			gravity = defaultGravity;
			GameControl.secondChance = true;
		}
		else if(BoostControl.boost1 && Tap.touch && canBoost)
		{
			trailTime = Time.time + 3.5f;
			trail.gameObject.SetActive(true);
			
			boosting = true;
			canBoost = false;
			down = false;
			
			SmokeScript.touchGround = true;
			RabbitAnimator.canJump = true;
			GameControl.startGame = true;
			
			this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -2);
			iTween.Stop(this.gameObject);
			iTween.MoveBy(this.gameObject, iTween.Hash(
					"amount", new Vector3(0, jumpForce + 75, 0),
					"time", 4f,
					"easetype", iTween.EaseType.linear,
					"delay", 0.005f,
					"oncomplete", "EndBoost"
					));
			timeToDown = Time.time + 5f;
			down = true;
			gravity = defaultGravity;
			
			timeToResetBoost = Time.time + 4.5f;
			
			audio.clip = audios[1];
			audio.Play();
		}
		else if(eggBoost)
		{
			trailTime = Time.time + 0.5f;
			trail.gameObject.SetActive(true);
			
			iTween.Stop(this.gameObject);
			iTween.MoveBy(this.gameObject, iTween.Hash(
					"amount", new Vector3(0, jumpForce + 10, 0),
					"time", 1.5f,
					"easetype", iTween.EaseType.easeOutCubic,
					"delay", 0.005f/*,
					"oncompletetarget", candyCollector.gameObject,
					"oncomplete", "TurnOnCollider"*/
					));
			
			turnOnColliderTime = Time.time + 0.5f;
			turnOnCollider = true;
			
			candyCollector.transform.collider.enabled = false;
			eggBoost = false;
			down = true;
			timeToDown = Time.time + 1.51f;
			gravity = defaultGravity;
		}
		else if(candyBoost)
		{
			iTween.Stop(this.gameObject);
			iTween.MoveBy(this.gameObject, iTween.Hash(
					"amount", new Vector3(0, jumpForce + 0.4f, 0),
					"time", 0.5f,
					"easetype", iTween.EaseType.easeOutCubic,
					"delay", 0.005f
					));
			
			candyBoost = false;
			down = true;
			timeToDown = Time.time + 0.51f;
			gravity = defaultGravity;
		}
		else if(down && timeToDown < Time.time)
		{
			this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0);
			rabbit.Move(Vector3.down * gravity * Time.deltaTime);
			if(!PauseScript.pauseGame)
			{
				gravity += forceGravity;
			}
		}
		else if(!down && !boosting)
		{
			audio.clip = audios[0];
			if(!GameControl.gameOver)
				audio.PlayDelayed(0);
			
			rabbit.Move(Vector3.up * Time.deltaTime);
			
			iTween.MoveBy(this.gameObject, iTween.Hash(
					"amount", new Vector3(0, jumpForce, 0),
					"time", 0.5f,
					"easetype", iTween.EaseType.easeOutCubic
					));
				
			down = true;
			timeToDown = Time.time + 0.51f;
			gravity = defaultGravity;
		}
		
		if(Tap.touch && !GameControl.startGame && GameControl.canStartGame && !BoostControl.boost1)
		{
			Tap.touch = false;
			SmokeScript.touchGround = true;
			RabbitAnimator.canJump = true;
			GameControl.startGame = true;
			down = false;
		}
		
		if(rabbit.isGrounded && GameControl.startGame && down)
		{
			GameControl.start = false;
			
			if(!brokenEffect)
				SmokeScript.touchGround = true;
			
			RabbitAnimator.canJump = true;
			down = false;
			CameraFollow.followDown = false;
			
			if(broken != null)
			{
				broken.SendMessage("CanDestroy", SendMessageOptions.DontRequireReceiver);
			}
		}
		
		if(GameControl.accControl)
		{
			if(!BoostControl.boostTime)
			{
				Vector3 dir = Vector3.zero;
				dir.x = Input.acceleration.x;
				
				if(dir.sqrMagnitude > 1)
					dir.Normalize();
				
				rabbit.transform.Translate(dir * 17.5f * Time.deltaTime);
				
				if((Input.GetKey(KeyCode.A) ))
				{
					rabbit.transform.Translate(Vector3.left * 5 * Time.deltaTime);
				}
				else if((Input.GetKey(KeyCode.D) ))
				{
					rabbit.transform.Translate(Vector3.right * 5 * Time.deltaTime);
				}
			}
		}
		else
		{
			if((Input.GetKey(KeyCode.A) || direction == 1) && !dead && !BoostControl.boostTime)
			{
				rabbit.transform.Translate(Vector3.left * 5 * Time.deltaTime);
			}
			else if((Input.GetKey(KeyCode.D) || direction == -1) && !dead && !BoostControl.boostTime)
			{
				rabbit.transform.Translate(Vector3.right * 5 * Time.deltaTime);
			}
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "brokenPoint")
		{
			timeBrokenEffect = Time.time + 0.5f;
			brokenEffect = true;
			broken = other.gameObject;
		}
	}
	
	
	void EndBoost()
	{
		this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0);
		boosting = false;
		timeToDown = Time.time + 0.5f;
		down = true;
		BoostControl.boost1 = false;
	}
}
