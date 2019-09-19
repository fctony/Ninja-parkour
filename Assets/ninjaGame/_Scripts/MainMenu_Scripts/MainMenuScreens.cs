using UnityEngine;
using System.Collections;

public class MainMenuScreens : MonoBehaviour
{
		//for menuscreen states
		public enum MenuScreens
		{

				mainmenu,
				playerSelectionMenu,
				ControlselectionMenu,
				CredtsMenu,
				ByPopupMenu,
				UnSufficentCoinsMenu,
				LevelSelectionMenu,
				StoreMenu,
				InnAppmenu,
				Loadindmenu
	}
		;
		public GameObject MainMenuParent, LoadingMenuParent, PlayerSelectionParent, ControlselectionMenuParent, CredtsMenuParent, 
				ByPopupMenuParent, UnSufficentCoinsMenuParent, LevelSelectionMenuParent, StoreMenuParent, InnAppMenuParent, UnsufficentCoinsForPlayerselectionMenu, TotalCoinsParent;
		public static MenuScreens currentScreen ;
		public GameObject PlayerGroup;

		void Start ()
		{
				Time.timeScale = 1;
				currentScreen = MenuScreens.mainmenu;
				DeActive ();//for desable all screen
				MainMenuParent.SetActive (true);//for main menu screen active
		}

		void Update ()
		{

				//for menu escapes control
				switch (currentScreen) {
				// for game close
				case MenuScreens.mainmenu:
						if (Input.GetKeyDown (KeyCode.Escape)) {
			
								Application.Quit ();//for game close
						}
						break;
				//for main menu 
				case MenuScreens.playerSelectionMenu:
						if (Input.GetKeyDown (KeyCode.Escape)) {
								DeActive ();//for disable all screens
								MainMenuParent.SetActive (true);//for main menu screen screen active
						}
						break;

				//for main menu 
				case MenuScreens.CredtsMenu:
						if (Input.GetKeyDown (KeyCode.Escape)) {
								DeActive ();//for disable all screens
								MainMenuParent.SetActive (true);//for main menu screen active
						}
						break;
				//for player selection
				case MenuScreens.ByPopupMenu:
						if (Input.GetKeyDown (KeyCode.Escape)) {
								DeActive ();//for disable all screens
								PlayerSelectionParent.SetActive (true);//for playerselection screen active
								PlayerGroup.SetActive (true);//for player active
						}
						break;
				//for main menu 
				case MenuScreens.UnSufficentCoinsMenu:
						if (Input.GetKeyDown (KeyCode.Escape)) {
								DeActive ();//for disable all screens
								MainMenuParent.SetActive (true);//for main menu screen active
						}
						break;
				case MenuScreens.Loadindmenu:
						DeActive ();//for disable all screens
						LoadingMenuParent.SetActive (true);//loading menu screen active
			           
						break;
				//for main menu 
				case MenuScreens.StoreMenu:
						if (Input.GetKeyDown (KeyCode.Escape)) {
								DeActive ();//for disable all screens
								MainMenuParent.SetActive (true);//for main menu screen active

						}
						break;
				//for main menu 
				case MenuScreens.InnAppmenu:
						if (Input.GetKeyDown (KeyCode.Escape)) {
								DeActive ();//for disable all screens
								MainMenuParent.SetActive (true);//for main menu screen  active
				
						}
						break;
				}

		}
		//for disable all screens
		void DeActive ()
		{
				PlayerGroup.SetActive (false);
				MainMenuParent.SetActive (false);
				LoadingMenuParent.SetActive (false);
				PlayerSelectionParent.SetActive (false);
				ControlselectionMenuParent.SetActive (false);
				CredtsMenuParent.SetActive (false);
				ByPopupMenuParent.SetActive (false);
				UnSufficentCoinsMenuParent.SetActive (false);
				LevelSelectionMenuParent.SetActive (false);
				StoreMenuParent.SetActive (false);
				InnAppMenuParent.SetActive (false);
				UnsufficentCoinsForPlayerselectionMenu.SetActive (false);
		}
}
