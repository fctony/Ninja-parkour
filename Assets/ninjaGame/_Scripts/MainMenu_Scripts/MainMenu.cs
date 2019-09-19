using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{

	public GameObject MainMenuParent, CreditsMenuParent, StoreMunuParent, PlayerSelectionmenuParent, ExitButton, PlayerGroup;
	// Use this for initialization
	void Start ()
	{
		//for exite button disable in IOS
		#if UNITY_IOS
		
		ExitButton.SetActive (false);
		#endif
		

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape) && MainMenuParent.activeSelf) {
			
			Application.Quit ();
		}
	}
	//for buttons controll
	public void OnButtunClick (string ButtonName)
	{
		Debug.Log (" clicked on " + ButtonName);
		switch (ButtonName) {
		//for play button
		case "Play":
			 
			PlayerGroup.SetActive (true);
			SoundController.Static.PlayClickSound ();//for click sound
			MainMenuParent.SetActive (false);
			PlayerSelectionmenuParent.SetActive (true);
			MainMenuScreens.currentScreen = MainMenuScreens.MenuScreens.playerSelectionMenu;//for state chenge in to mainmenu screen
			break;
		//for more button
		case "More":
			//for open playstore acegames games
			#if UNITY_IPHONE
			Application.OpenURL("https://play.google.com/store/apps/developer?id=Ace+Games");
			# elif UNITY_ANDROID
			Application.OpenURL ("https://play.google.com/store/apps/developer?id=Ace+Games");
			#elif UNITY_WP8
			Application.OpenURL ("https://play.google.com/store/apps/developer?id=Ace+Games");
			#endif
			SoundController.Static.PlayClickSound ();//for click sound
			break;
		//for review button
		case "Review":
		//for open playstore acegames games
			#if UNITY_IPHONE
			Application.OpenURL("https://play.google.com/store/apps/developer?id=Ace+Games");
			# elif UNITY_ANDROID
			Application.OpenURL ("https://play.google.com/store/apps/details?id=com.acegames.ninjavszombies2");
			#elif UNITY_WP8
			Application.OpenURL ("https://play.google.com/store/apps/developer?id=Ace+Games");
			#endif
			SoundController.Static.PlayClickSound ();//for click sound
			break;
		//for credits button
		case "Credits":
			SoundController.Static.PlayClickSound ();//for click sound
			MainMenuParent.SetActive (false);
			CreditsMenuParent.SetActive (true);
			MainMenuScreens.currentScreen = MainMenuScreens.MenuScreens.CredtsMenu;//for state chenge in to credits screen
			break;
		//for exite button
		case "Exit":
			SoundController.Static.PlayClickSound ();//for click sound
			Application.Quit ();//for close the game
			break;
		//for store button
		case "Store":
			StoreMunuParent.SetActive (true);
			MainMenuParent.SetActive (false);
			SoundController.Static.PlayClickSound ();//play click sound
			MainMenuScreens.currentScreen = MainMenuScreens.MenuScreens.StoreMenu;//for state change in to store screen
			break;


		}

	}
}
