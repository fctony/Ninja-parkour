using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour
{
//		public float Speed = 0.5f;
//		public float JumpSpeed = 0.5f;
	public Transform thisTrans ; //to take player's transform
	CharacterController controller  ;//to hold player character controller 
	public Animator playerAnimator;//for player animations
	public Animator SwordAnimator;//for Sword rotation
	public    float speed = 5F;//for player speed
	public float jumpSpeed = 8.0F;//for player jumping
	public float doubleJumpSpeed = 8.0F;
	public float gravity = 20.0F;//for player moving down
	private Vector3 moveDirection = Vector3.zero;//for player moving zero position
	public static  Vector3 thisPosition;
	public   GameObject fireEffect, SmokeEffect, sword, Shield;
	public GameObject PlayerDeadEffect;
	public static bool  ShieldIcon;
	public Texture[] playertexture;
	public Material playerMaterial;
	public float MultiplierCount = 1f;
	public GameObject jumpinfo, attackinfo;
	int Coin = 0;
	int CoinMultipler = 1;
	//int i = 0;
	    
	public static event EventHandler switchOnMagnetPower,
		switchOFFMagnetPower ;//for magnet on and off
	public enum playerStates
	{
		Alive,
		idle,
		attack1,
		dead
	}
	public  playerStates presentPlayerState ;//
	int attack = Animator.StringToHash ("layer1.Attack");//for player attack1 animation
	int attack2 = Animator.StringToHash ("layer1.Attack2");//for player attack2 animation
	int attack3 = Animator.StringToHash ("layer1.Attack3");//for player attack3 animation
	int runAnim = Animator.StringToHash ("layer1.Run");//for player run animation
	public	int jump = Animator.StringToHash ("layer1.Jump");//for player jump animation

	void Start ()
	{

		MultiplierCount = 1f + PlayerPrefs.GetInt ("IngameMultiplierCount", 0);
		thisTrans = transform;
		controller = GetComponent<CharacterController> ();
		//ActivateShield ();//for shield active in game start
		//getting player index in to player selection script
		PlayerPrefs.GetInt ("PlayerIndex", Playerselection.PlayerIndex);
		
		//Debug.Log ("Player Index : " + Playerselection.PlayerIndex);
		//for selecting player acording to player index
		if (Playerselection.PlayerIndex == 0) {
			
			PlayerPrefs.SetInt ("PlayerIndex", 0);
			playerMaterial.mainTexture = playertexture [0]; 
			
			
		} else if (Playerselection.PlayerIndex == 1) {

			playerMaterial.mainTexture = playertexture [1]; 
			
		} else if (Playerselection.PlayerIndex == 2) {
			playerMaterial.mainTexture = playertexture [2]; 
			
		} else if (Playerselection.PlayerIndex == 3) {
			
			playerMaterial.mainTexture = playertexture [3]; 
		}

	}

	public float currentJumpSpeed, jumpTimer ;
	[SerializeField]
	float
		jumpSpeedFalloff;
	[SerializeField]
	AnimationCurve
		jumpCurve;

	float onAirTime ;

	int startGamePlayValueCount = 2 ;
	bool canDoubleJump = false;
	void  FixedUpdate ()
	{
		//isPlayerOnGround ();

		thisPosition = thisTrans.position;
		switch (presentPlayerState) {
		//for player in alive

		case playerStates.Alive:

		 
			 
			if (InputController.Static.isJump) {
								
				if (canDoubleJump) {
					currentJumpSpeed = jumpSpeed * 0.5f;
					canDoubleJump = false;
					playerAnimator.SetTrigger ("DoubleJump");
					jumpTimer = 0.0f;
					onAirTime = Time.timeSinceLevelLoad;
				} else {
					if (isPlayerOnTheGround) {
						currentJumpSpeed = jumpSpeed;
						canDoubleJump = true;
						playerAnimator.SetTrigger ("Jump");
						jumpTimer = 0.0f;
						jumpinfo.SetActive (false);
						SoundController.Static.playSoundFromName ("JUMP");//for jump sound
						onAirTime = Time.timeSinceLevelLoad;
					}
				}

					 
			 
 
				InputController.Static.isJump = false;

					 
			}
  
			if (InputController.Static.isAttack) {
					                  
				attackinfo.SetActive (false);
				fireEffect.SetActive (false);
				SwordAnimator.SetTrigger ("Rotate");
				playerAnimator.SetTrigger ("Attack");
				SoundController.Static.playSoundFromName ("Sword");//for sword sound

				InputController.Static.isAttack = false;
			}
 
			 

		
			moveDirection = new Vector3 (speed, currentJumpSpeed, 0);
			controller.Move (moveDirection * Time.deltaTime);
		 
			jumpSpeedFalloff = jumpCurve.Evaluate (jumpTimer);
			currentJumpSpeed -= jumpSpeedFalloff;
			jumpTimer += Time.deltaTime;

			isPlayerOnGround ();
			break;
		case playerStates.idle:
			break;
		//to player dead state
		case playerStates.dead:
			fireEffect.SetActive (false);
			SmokeEffect.SetActive (false);
			sword.SetActive (false);
			            //player moving down
			moveDirection.y -= gravity * Time.deltaTime;
			moveDirection = Vector3.MoveTowards (moveDirection, Vector3.zero, 0.09f);
			controller.Move (moveDirection * Time.deltaTime);
		
			SoundController.Static.bgSound.volume = 0;//to bg sound
			           //to resetting player moving speed when died
						
			if (!oneTimeReset) {
				oneTimeReset = true;
				playerAnimator.SetTrigger ("Dead");//for player dead animation
				Invoke ("ResetMoveDirection", 0.7f);
			}	
			break;
			         
			
		}
				
	
 
	}

	bool oneTimeReset = false ;

	//reseting player moving speed when died
	void ResetMoveDirection ()
	{
		moveDirection = Vector3.zero;
		transform.position = new Vector3 (thisTrans.position.x, 0, thisTrans.position.z);
		gravity = 0.1f;
	}
	//to handle the player collision information
	void OnTriggerEnter (Collider hit)
	{

		GameObject incomingObj = hit.gameObject;
		//for getting new world
		if (hit.GetComponent<Collider> ().name.Contains ("World")) {
			GameController.Static.CreateNewWorld ();

			hit.enabled = false;

			//Destroy (hit.collider.gameObject, 25);//for world destroy
		} 
		//for world destroy
		if (hit.GetComponent<Collider> ().name.Contains ("Destroytrigger")) {

			
			Destroy (hit.GetComponent<Collider> ().transform.parent.gameObject);//for world destroy
		} 
              //for collecting coins
		else if (hit.GetComponent<Collider> ().name.Contains ("coin")) {
			Coin++;
			//Ace_IngameUiControl.Static.inGameCoinCount++;
			Destroy (hit.GetComponent<Collider> ().gameObject.GetComponent<Collider> ());
			SoundController.Static.playSoundFromName ("CoinHit");//for coin sound
			Ace_IngameUiControl.Static.inGameCoinCount = Coin * Mathf.RoundToInt (MultiplierCount);
			coinControl coinScript = incomingObj.GetComponent<coinControl> ();
			if (coinScript != null)
				coinScript.moveToPlayer = true;
			//	Destroy (hit.collider.gameObject);
		}
		//for getting magnet power
		else if (hit.GetComponent<Collider> ().name.Contains ("Magnet_Icon")) {
			if (switchOnMagnetPower != null)
				switchOnMagnetPower (null, null);
			coinControl.isONMagetPower = true;
			Destroy (incomingObj);
			SoundController.Static.playSoundFromName ("PowerUp");//for powerup sound	
			Invoke ("switchOffMagnet", 3f + PlayerPrefs.GetInt ("IngamemagnetCount", 0));//for magnet power off 
		}
		//for getting multiplier 
		else if (hit.GetComponent<Collider> ().name.Contains ("Multiplier")) {
			Destroy (hit.GetComponent<Collider> ().gameObject);
			//Ace_IngameUiControl.Static.inGameMultiplierCount++;
			MultiplierCount = 2 + PlayerPrefs.GetInt ("IngameMultiplierCount", 0);
			SoundController.Static.playSoundFromName ("PowerUp");//for powerup sound
			Ace_IngameUiControl.Static.inGameMultiplierCount = 2 + PlayerPrefs.GetInt ("IngameMultiplierCount", 0);
			Invoke ("switchOffMultiplier", 10);//for multiplier time off
			// CoinMultipler = 5;
		} 
		//for getting shield
		else if (hit.GetComponent<Collider> ().name.Contains ("Shield")) {
			Destroy (hit.GetComponent<Collider> ().gameObject);
			ActivateShield ();//for activating shield
			SoundController.Static.playSoundFromName ("PowerUp");//for powerup sound
		}
		//broken_pot 
		
	}

	public bool isPlayerOnTheGround = false;
	string hitObjTagName;//for ray hit obj name
	float hitDistance ;//for ray hit distance
	RaycastHit hit;
	//to ray passing
	void isPlayerOnGround ()
	{
		//to ray passing down position
		 
		Debug.DrawRay (thisTrans.position, -Vector3.up * 0.15f, Color.red);

		if (Physics.Raycast (transform.position, -Vector3.up, out hit, 0.15f)) {


		 
			//Debug.Log ("name" + hit.collider.tag);
			//for ray hit castle ground
			if (playerAnimator.GetCurrentAnimatorStateInfo (0).IsName ("Run")) {
				if (hit.collider.tag.Contains ("ground1")) {
				 

					fireEffect.SetActive (true);//to fire effect disable
					SmokeEffect.SetActive (false);//to smoke effect disable
				}
  
			//for ray hit forest ground
			else if (hit.collider.tag.Contains ("ground2")) {
					fireEffect.SetActive (false);//to fire effect disable
					SmokeEffect.SetActive (true);//to smoke effect disable
				}	
			} else {
				SmokeEffect.SetActive (false);//to smoke effect disable
				fireEffect.SetActive (false);//to fire effect disable
			}
			isPlayerOnTheGround = true;
		
		} else {
			isPlayerOnTheGround = false;
			//if player is on Air
			SmokeEffect.SetActive (false);//to smoke effect disable
			fireEffect.SetActive (false);//to fire effect disable
		}
	}
	//to handle the player ControllerColliderHit information
	void OnControllerColliderHit (ControllerColliderHit incoming)
	{ 
		if (presentPlayerState != playerStates.Alive)
			return;

		//for player hit zombies when shield is off
		if (incoming.collider.name.Contains ("Zombie") && !ShieldIcon) {
			SoundController.Static.PlayDeadSound ();//for player dead sound
			presentPlayerState = playerStates.dead;//to take player is which state
			GameController.Static.isplayerDaed = true;
			incoming.collider.isTrigger = true;
			Ace_IngameUiControl.Static.GameEnd ();//to calling gameEnd function 
			sword.SetActive (false);//to sword deactive when player is dead
			GameObject obj = Instantiate (PlayerDeadEffect, thisTrans.position, Quaternion.identity)as GameObject;//to player dead effect
			Destroy (obj, 0.5f);//for destroy zombie after some time
			Destroy (incoming.collider.gameObject.GetComponent<Collider> ());//for destroy zombie collider
			GameObject.Find ("Main Camera").GetComponent<CameraShake> ().enabled = true;//for camera shaking
		} 
		//for player hit Obsticles when shield is off
		else if (incoming.collider.tag.Contains ("Obstacles") && !ShieldIcon) {
			           
			presentPlayerState = playerStates.dead;//to take player is which state
						
			GameController.Static.isplayerDaed = true;
			SoundController.Static.PlayDeadSound ();//for player dead sound
			Ace_IngameUiControl.Static.GameEnd ();//to calling gameEnd function 
			GameObject obj1 = Instantiate (PlayerDeadEffect, thisTrans.position, Quaternion.identity)as GameObject;//to player dead effect
			Destroy (obj1, 0.3f);//for destroy zombie after some time
			Destroy (incoming.collider.GetComponent<GameObject> ());//for destroy zombie collider
			sword.SetActive (false);//to sword deactive when player is dead
			GameObject.Find ("Main Camera").GetComponent<CameraShake> ().enabled = true;//for camera shaking
		} 
		//for player hit Rock when shield is off
		else if (incoming.collider.name.Contains ("Rock") && !ShieldIcon) {
			           
			presentPlayerState = playerStates.dead;//to take player is which state
					
			GameController.Static.isplayerDaed = true;
			SoundController.Static.PlayDeadSound ();//for player dead sound
			Ace_IngameUiControl.Static.GameEnd ();//to calling gameEnd function 
			GameObject obj2 = Instantiate (PlayerDeadEffect, thisTrans.position, Quaternion.identity)as GameObject;//to player dead effect
			Destroy (obj2, 0.3f);//for destroy zombie after some time
			Destroy (incoming.collider.gameObject.GetComponent<Collider> ());//for destroy zombie collider
			sword.SetActive (false);//to sword deactive when player is dead
			GameObject.Find ("Main Camera").GetComponent<CameraShake> ().enabled = true;//for camera shaking
		}
		//for player hit zombies when shield is on
		if (incoming.collider.name.Contains ("Zombie") && (ShieldIcon || !isPlayerOnTheGround)) {

			ZombieController zombieScript = incoming.collider.GetComponent<ZombieController> ();
			zombieScript.DeathState ();
			Ace_IngameUiControl.Static.inGameScoreCount++;
		} 
		//for player hit Obsticles when shield is on
		else if (incoming.collider.tag.Contains ("Obsticles") && ShieldIcon) {
			Destroy (incoming.collider.gameObject);
			
		}
		//for player hit Rock when shield is off
		else if (incoming.collider.name.Contains ("Rock") && ShieldIcon) {
						
			Destroy (incoming.collider.transform.parent.gameObject);
			
		} else if (incoming.collider.name.Contains ("broken_pot") || incoming.collider.name.Contains ("broken_pot") && ShieldIcon) {
			
			incoming.gameObject.GetComponent<Collider> ().isTrigger = true;
			
		}

	}
	//to magnet power time off
	void switchOffMagnet ()
	{

		coinControl.isONMagetPower = false;

		if (switchOFFMagnetPower != null)
			switchOFFMagnetPower (null, null);
	}
	//to activate shield power
	public void ActivateShield ()
	{	
		ShieldIcon = true;
		Shield.SetActive (true);
		Invoke ("ShieldOff", 10f + PlayerPrefs.GetInt ("IngameShieldCount", 0));
		
	}
//to deactivate shield power
	void ShieldOff ()
	{
		ShieldIcon = false;
		Shield.SetActive (false);

	}
	// to deactivate multiplier power time
	void switchOffMultiplier ()
	{


		Ace_IngameUiControl.Static.inGameMultiplierCount = 0;

		MultiplierCount = 1;
		
	}
}
