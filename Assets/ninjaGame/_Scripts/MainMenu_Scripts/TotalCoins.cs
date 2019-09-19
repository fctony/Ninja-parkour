using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TotalCoins : MonoBehaviour
{


		public GameObject MainMenuParent, LoadingMenuParent, PlayerSelectionParent, ControlselectionMenuParent, CredtsMenuParent, 
				ByPopupMenuParent, UnSufficentCoinsMenuParent, LevelSelectionMenuParent, StoreMenuParent, InnAppMenuParent, UnsufficentCoinsForPlayerselectionMenu;
		public static TotalCoins Static;
		public  Text TotalCoinstext;//for total coins text
		public int totalCoins;//for total coins 
		int coinsIn;

		void Start ()
		{
				UpdateCoins ();//for getting coins in to the gameplay
				Static = this;
		}
		//for getting coins in to the gameplay
		public  void UpdateCoins ()
		{
				totalCoins = PlayerPrefs.GetInt ("TotalCoins", 0);
				TotalCoinstext.text = "" + PlayerPrefs.GetInt ("TotalCoins", 0);
		}
		//for adding coins in to total coins count
		public void AddCoins (int AddingCoins)
		{
				PlayerPrefs.SetInt ("TotalCoins", PlayerPrefs.GetInt ("TotalCoins", 0) + AddingCoins);
				UpdateCoins ();
		}
		//for SubtractCoins coins in to total coins count
		public void SubtractCoins (int SubtractingCoins)
		{
				PlayerPrefs.SetInt ("TotalCoins", PlayerPrefs.GetInt ("TotalCoins", 0) - SubtractingCoins);
				UpdateCoins ();
		}

		public int getCoinCount ()
		{
				return PlayerPrefs.GetInt ("TotalCoins", 0);
		}
		//for delet all coins count
		public void ClearCoins ()
		{
				PlayerPrefs.DeleteAll ();
		}
		//for buying coins
		public void OnButtonClic (string ButtonName)
		{
				switch (ButtonName) {
				case "BuyCoins":
						DeActive ();
						InnAppMenuParent.SetActive (true);
						MainMenuScreens.currentScreen = MainMenuScreens.MenuScreens.InnAppmenu;//for moving inapp menu state
						SoundController.Static.PlayClickSound ();//for click sound
						break;
				}
		}

		void Update ()
		{
				//for adding coins
				if (Input.GetKeyDown (KeyCode.P)) {
						AddCoins (10000);
				}
				//for delet coins
				if (Input.GetKeyDown (KeyCode.Q)) {
						PlayerPrefs.DeleteAll ();
				}
	
		}
		//for disable all menu screens
		void DeActive ()
		{
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
