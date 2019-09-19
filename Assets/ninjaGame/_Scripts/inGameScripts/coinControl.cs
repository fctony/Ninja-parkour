using UnityEngine;
using System.Collections;
using System;

public class coinControl : MonoBehaviour
{

	// Use this for initialization
	float coinSpeed = 1.0f;//for coin move speed
	Transform coinTrans ;//for coin move
	public static int  turnCount;
	public BoxCollider box ;//for coin collider
	Vector3 originalScale;//for coins scale
	public static bool isONMagetPower ;//for magnet power
	public bool moveToPlayer = false ;//for coin move to player side
	public bool moveToCoinTarget = false;//for coin transform
	Transform thisTrans;
	//for coin magnet power states
	public enum CoinStates
	{
		MagnetOn,
		magnetoff
	}
	public  CoinStates CurrentState ;

	void OnEnable ()
	{
		thisTrans = transform;
		box = GetComponent<BoxCollider> () as BoxCollider;//for getting coin collider
		if (box == null)
			Debug.Log ("Found no box collider for " + name);
			
		originalScale = box.size;//for coin original collider
		//for magnet power on
		PlayerController.switchOnMagnetPower += onMagnetPower;
		if (isONMagetPower)
			onMagnetPower (null, null);
	}

	void OnDisable ()
	{
		PlayerController.switchOFFMagnetPower += offMagnetPower;//for magnet power off	
	}

	void onGameEnd (System.Object obj, EventArgs args)
	{
		Destroy (gameObject);//for destroy the coin
	}
	//for coin magnet power on
	void onMagnetPower (System.Object obj, EventArgs args)
	{
		isONMagetPower = true;
		
		if (box != null)
			box.size = new Vector3 (6.3f, 6.3f, 6.3f);
	}
	//for coin collider original size
	public void resetSize ()
	{
		if (box != null)
			box.size = originalScale;
	}
	//for coin magnet power off
	void offMagnetPower (System.Object obj, EventArgs args)
	{
		isONMagetPower = false;
		resetSize ();
	}

	void Start ()
	{

		coinTrans = transform;
		coinTrans.Rotate (0, 0, turnCount);
		turnCount += 4;
	}
	
	// Update is called once per frame
	Vector3 newCoinPostionTarget;//for coin moving target position
	bool isAwaredNitrous = false;
	bool reduceTozero = false;

	void Update ()
	{
		 
		switch (CurrentState) {
		case CoinStates.magnetoff:
		 
			break;
		case CoinStates.MagnetOn:
 
			break;
		}
		//for coin moving to player
		if (moveToPlayer) {
			thisTrans.position = Vector3.MoveTowards (thisTrans.position, PlayerController.thisPosition, 3.0f);
			if (Vector3.Distance (thisTrans.position, PlayerController.thisPosition) < 3) {
				moveToPlayer = false;
				moveToCoinTarget = true;
				newCoinPostionTarget = Camera.main.transform.position + new Vector3 (-190, 230, 170);
 
				//	Destroy (gameObject, 2.0f);
			}
		} 
		//for coin moving to target position
		else if (moveToCoinTarget) {

			//Vector3 coinRelativetoPlayer = new Vector3(-10,20,playerCarControl.thisPosition.z+40);
			thisTrans.position = Vector3.MoveTowards (thisTrans.position, newCoinPostionTarget, Time.deltaTime * 100);

		}

	
	}

	 

}
