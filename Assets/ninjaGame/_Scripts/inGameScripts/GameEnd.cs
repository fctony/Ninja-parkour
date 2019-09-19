using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
public class GameEnd : MonoBehaviour
{

	public float startCoinsCount, TargetCoisCount, startScoreCount, startBestDistanceCount, TargetScoreCount, TargetBestDistanceCount, startDistanceCount, TargetDistanceCount;
	private float toreachCoins, toreachScore, toreachBestDistance, toreachDistance;
	public float  valueForScore, ValueForBestDistance, valueForCoins, valueForDistance;
	public Text finalDistance, finalCoins, finalScore, bestDistance;
	public GameObject newBestScore_Image, buttonGroup;
	public static EventHandler showAdd;
	//for values display state
	public enum endMenuStates
	{
		coinCount,
		ScoreCount,
		DistanceCount,
		BestDistanceCount ,
		showButtons ,
		nothing
		
	}
	
	public endMenuStates currentState ;

	void Start ()
	{
		 
		TotalCoins ();//for total coins collected 
		FinalScoreCount ();//for total score
		FinalDistance ();//for total distance
		BestDistance ();//for best distance
		buttonGroup.SetActive (false);//for buttons 
		SoundController.Static.CollectedCoins.volume = 0.5f;//for coins collected sound


	}

	void Update ()
	{




		switch (currentState) {
			
		//for coins collected state
		case endMenuStates.coinCount:
			valueForCoins = Mathf.Lerp (valueForCoins, toreachCoins, 0.3f);//value for coins
			finalCoins.text = "" + Mathf.RoundToInt (valueForCoins);
			if (Mathf.RoundToInt (valueForCoins) == toreachCoins) {
			
				currentState = endMenuStates.ScoreCount;
			} 
			break;
		//for score count state
		case endMenuStates.ScoreCount:
			valueForScore = Mathf.Lerp (valueForScore, toreachScore, 0.3f);//value for score
			finalScore.text = "" + Mathf.RoundToInt (valueForScore);
			if (Mathf.RoundToInt (valueForScore) == toreachScore) {
				currentState = endMenuStates.DistanceCount;
			}
			
			break;
		//for distance take state
		case endMenuStates.DistanceCount:
			valueForDistance = Mathf.Lerp (valueForDistance, toreachDistance, 0.3f);//value for distance
			finalDistance.text = "" + Mathf.RoundToInt (valueForDistance);
			if (Mathf.RoundToInt (valueForDistance) == toreachDistance) {
				currentState = endMenuStates.BestDistanceCount;
			}
			
			break;

		//for best distance state
		case endMenuStates.BestDistanceCount:
			
			ValueForBestDistance = Mathf.Lerp (ValueForBestDistance, toreachBestDistance, 0.3f);//value for best distance
			bestDistance.text = "" + Mathf.RoundToInt (ValueForBestDistance);
			
			if (Mathf.RoundToInt (ValueForBestDistance) == toreachBestDistance) {
				currentState = endMenuStates.showButtons;
			}
			
			break;
		//for buttons show state
		case endMenuStates.showButtons:
			
			showButtons ();//to show buttons
			currentState = endMenuStates.nothing;
			break;
			
		}
		
		
		

	}


	//for total coins
	void TotalCoins ()
	{

		
		TargetCoisCount = Ace_IngameUiControl.Static.inGameCoinCount;
		
		toreachCoins = TargetCoisCount;
		//too store in playerprefs
		PlayerPrefs.SetInt ("TotalCoins", PlayerPrefs.GetInt ("TotalCoins", 0) + (int)TargetCoisCount);
		//print ("forcoins" + Ace_IngameUiControl.Static.inGameCoinCount);

//		iTween.ValueTo (gameObject, iTween.Hash ("from", 0, "to", Ace_IngameUiControl.Static.inGameCoinCount, "time", 1.0f,"onupdate","ChangeCoinsCount","oncomplete","FinalScoreCount"));//"oncomplete",

	}

	void ChangeCoinsCount (int newCoinCount)
	{
		finalCoins.text = "" + newCoinCount;
	}
	
//for distance
	void FinalDistance ()
	{
		//Debug.Log (Ace_IngameUiControl.Static.inGameScoreCount);
		TargetDistanceCount = Ace_IngameUiControl.Static.inGameDistance;
		toreachDistance = TargetDistanceCount;
		//iTween.ValueTo (gameObject, iTween.Hash ("from", 0, "to", Ace_IngameUiControl.Static.inGameDistance, "time", 1.0f,"onupdate","ChangeDistance","oncomplete","BestDistance"));//"oncomplete",
	}

	void ChangeDistance (int newDistance)
	{
		finalDistance.text = "" + newDistance;
	}


	//for total score
	void FinalScoreCount ()
	{
		TargetScoreCount = Ace_IngameUiControl.Static.inGameScoreCount;
		toreachScore = TargetScoreCount;
		//	iTween.ValueTo (gameObject, iTween.Hash ("from", 0, "to", Ace_IngameUiControl.Static.inGameScoreCount, "time", 1.0f,"onupdate","ChangeScoreCount","oncomplete","FinalDistance"));//"oncomplete",
	}

	void ChangeScoreCount (int newScoreCount)
	{
		finalScore.text = "" + newScoreCount;
	}
	

	//for best distance
	void BestDistance ()
	{
		toreachBestDistance = Mathf.RoundToInt (PlayerPrefs.GetFloat ("BestDistance", 0));
		if (PlayerPrefs.GetFloat ("BestDistance", 0) < Ace_IngameUiControl.Static.inGameDistance) {
			newBestScore_Image.SetActive (true);
			
			TargetBestDistanceCount = Ace_IngameUiControl.Static.inGameDistance;
			toreachBestDistance = TargetBestDistanceCount;
			
			PlayerPrefs.SetFloat ("BestDistance", Ace_IngameUiControl.Static.inGameDistance);
		}
		bestDistance.text = "" + Mathf.RoundToInt (PlayerPrefs.GetFloat ("BestDistance", 0));

	}


	//for show buttons
	void showButtons ()
	{
		//you need to subscribe to this event to display .
		if (showAdd != null)
			showAdd (gameObject, null);

		buttonGroup.SetActive (true);
		SoundController.Static.CollectedCoins.volume = 0;//for coins collected sound is zero
	}





}
