using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour
{



	public  static InputController Static;
	PlayerController playerScript;
	public bool isJump = false, isdoubleJump = false, isAttack = false;
    	
	void Start ()
	{
	
		Static = this;
		playerScript = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();//for getting player scipt

	}
	float lastJumpTime ;
	float lastAttackTime;
	void Update ()
	{

				
#if UNITY_EDITOR || UNITY_WEBPLAYER
		if (Input.GetKeyDown (KeyCode.Mouse0)) {

			if (Input.mousePosition.x < Screen.width / 2) {
				 
				if (Time.timeSinceLevelLoad - lastJumpTime > 0.2f) {//to avoid repeated tapping
					isJump = true;
					lastJumpTime = Time.timeSinceLevelLoad;   
				} 
			} else if (Time.timeSinceLevelLoad - lastAttackTime > 0.3f) {
				isAttack = true;
				lastAttackTime = Time.timeSinceLevelLoad;   
			}
		}

#endif
		#if   UNITY_IOS || UNITY_ANDROID || UNITY_WP8

		foreach (Touch t in Input.touches) {
			if (t.phase == TouchPhase.Began) {
				if (t.position.x < Screen.width / 2) {
					
					if (Time.timeSinceLevelLoad - lastJumpTime > 0.2f) {//to avoid repeated tapping
						isJump = true;
						lastJumpTime = Time.timeSinceLevelLoad;   
					}
					
				
					
				} else if (Time.timeSinceLevelLoad - lastAttackTime > 0.1f) {
					isAttack = true;
					lastAttackTime = Time.timeSinceLevelLoad;   
				}
			}
			
			
		}

#endif

	 
	


	}






}
