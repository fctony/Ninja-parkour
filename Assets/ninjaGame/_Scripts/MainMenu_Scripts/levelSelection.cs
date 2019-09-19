using UnityEngine;
using System.Collections;

public class levelSelection : MonoBehaviour
{

		
		
		
		public static string levelName;
		public GameObject ControlSelection, PlayerSelectionMenu, LevelSelectionParent;

		void Start ()
		{
	
		}
	
		void  Update ()
		{

		}

		public void OnButtonClick (string ButtonName)
		{
				switch (ButtonName) {

				case "Back":
						LevelSelectionParent.SetActive (false);
						PlayerSelectionMenu.SetActive (true);
						SoundController.Static.PlayClickSound ();
						break;
				case "Level1":
		
						levelName = "GamePlay";
						ControlSelection.SetActive (true);
						LevelSelectionParent.SetActive (false);
						MainMenuScreens.currentScreen = MainMenuScreens.MenuScreens.ControlselectionMenu;
						SoundController.Static.PlayClickSound ();

						break;
				case "Level2":
		
						levelName = "cityGameplay";
						ControlSelection.SetActive (true);
						LevelSelectionParent.SetActive (false);
						MainMenuScreens.currentScreen = MainMenuScreens.MenuScreens.ControlselectionMenu;

						SoundController.Static.PlayClickSound ();
						break;
				case "Level3":
						SoundController.Static.PlayClickSound ();
						levelName = "NightGameplay";
						ControlSelection.SetActive (true);
						LevelSelectionParent.SetActive (false);
						MainMenuScreens.currentScreen = MainMenuScreens.MenuScreens.ControlselectionMenu;
						break;
				}
		}
		


}
