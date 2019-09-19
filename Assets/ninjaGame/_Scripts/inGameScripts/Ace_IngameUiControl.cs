using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ace_IngameUiControl : MonoBehaviour
{

	public GameObject ResumeMenuParent, GameEndMenuParent, Pausemenu;
	public int inGameCoinCount = 0;//for coins count
	public int inGameScoreCount = 0;//for score count
	public int inGameMultiplierCount = 0;//for multiplier count
	public int inGameDistance;//for distance count
	public Text  scoreCountText, coinsCountText, distanceCountText;//for ingameui texts
	public static Ace_IngameUiControl Static;
	public GameObject infomenu;

	void Start ()
	{
		Static = this;
		distanceCountText.text = "" + inGameDistance + " M";
				
	}
	
	// Update is called once per frame
	void Update ()
	{


		//for Distance

		if (GameController.CurrentState == GameController.GameState.GamePlay) {
			Distance_IngameCount ();
			//for Coins
			Coins_IngameCount ();
			// for Score
			Score_IngameCount ();
			//for multiplier
			Multiplier_IngameCount ();
		}
				
		#if UNITY_EDITOR

		#endif

		if (Input.GetKeyDown (KeyCode.Escape)) {

			if (!GameEndMenuParent .activeSelf) {
				if (Time.timeScale != 0) {
					Time.timeScale = 0;
					Pausemenu.SetActive (false);
					ResumeMenuParent.SetActive (true);
					infomenu.SetActive (false);
					SoundController.Static.PlayClickSound ();//for click sound
				} else {
					Time.timeScale = 1;
					ResumeMenuParent.SetActive (false);
					Pausemenu.SetActive (true);
					infomenu.SetActive (true);
					SoundController.Static.PlayClickSound ();//for click sound
				}
			} else {

				Application.LoadLevel (1);
			}
		}

	}

	void AddCoins (int i)
	{

	}
		
	//for ingame ui buttons controls
	public void OnButtonClick (string ButtonName)
	{
		switch (ButtonName) {
		//for pause button
		case "Pause":
			Time.timeScale = 0;
			Pausemenu.SetActive (false);
			ResumeMenuParent.SetActive (true);
			infomenu.SetActive (false);
			SoundController.Static.PlayClickSound ();//for click sound
			break;
		//for resume button
		case "Resume":
			Time.timeScale = 1;
			ResumeMenuParent.SetActive (false);
			Pausemenu.SetActive (true);
			infomenu.SetActive (true);
			SoundController.Static.PlayClickSound ();//for click sound
			break;
		//for playagain button 
		case "PlayAgain":
			Application.LoadLevelAsync (Application.loadedLevelName);//for game re loaded
			Time.timeScale = 1;
			ResumeMenuParent.SetActive (false);
			GameEndMenuParent.SetActive (false);
			SoundController.Static.PlayClickSound ();//for click sound
			print ("play btn Clicked");
			break;
		//for home button
		case "Home":
			Application.LoadLevelAsync ("MainMenu");//for mainmenu scene
			ResumeMenuParent.SetActive (false);
			SoundController.Static.PlayClickSound ();//for click sound
			break;
		//for Facebook button
		case "FbLike":

			string fbUrl = "https://www.facebook.com/AceGamesHyderabad";//for open acegame fb page
			Application.OpenURL (fbUrl);//for open acegame fb page

			SoundController.Static.PlayClickSound ();//for click sound
			break;


		}

	}
	//for game end and Finalscore card display
	public void GameEnd ()
	{
		Invoke ("ScoreCardEnabled", 1.6f);//for final score card late display
		Pausemenu.SetActive (false);//for pause menu disable
		infomenu.SetActive (false);
		//SoundController.Static.bgSound.volume = 0;
	}
	// for score card enable
	void ScoreCardEnabled ()
	{
		GameEndMenuParent.SetActive (true);
	}

	public Text multiplierCountText;
	//for show multiplier in ingame ui
	void Multiplier_IngameCount ()
	{
		multiplierCountText.text = "" + inGameMultiplierCount;
	}
	//for show coins in ingame ui
	void Coins_IngameCount ()
	{
		coinsCountText.text = "" + inGameCoinCount;


	}
	//for show distance in ingame ui
	float distanceCounter = 30;
	void Distance_IngameCount ()
	{

		inGameDistance += Mathf.RoundToInt (distanceCounter * Time.deltaTime);//for distance calculate Acording to player postion
		distanceCountText.text = "" + inGameDistance + " M";// for display the distance
	}
	//for show score in ingame ui
	void 	Score_IngameCount ()
	{
		scoreCountText.text = "" + inGameScoreCount;

	}
}
