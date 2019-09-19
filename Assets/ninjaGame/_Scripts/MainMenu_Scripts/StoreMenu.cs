using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StoreMenu : MonoBehaviour
{

		// Use this for initialization

		public GameObject[] MagnetIndicators, multiplierIndicators, ShieldIndicators;//for magnet,multiplier,shield fill bars
		public int magnetPowerCost = 500, multiplierCost = 1000, ShieldCost = 500 ;//for cost of magnet,shield,multiplier
 
		public GameObject unSufficentCoinsParent, mainMenuParent, StoreMenuParent;
		public Text magnetCostText, multiplierCostText, MagnetFull, MultiplayerFull, ShieldCostText, ShieldFulltext;

		void Start ()
		{

				//for magnet
				for (int i=0; i<PlayerPrefs.GetInt("MagnetPower",0); i++) {
						MagnetIndicators [i].SetActive (true);
				}
				//for multiplier
				for (int i=0; i<PlayerPrefs.GetInt("Multiplier",0); i++) {
						multiplierIndicators [i].SetActive (true);
				}
				//for shield
				for (int i=0; i<PlayerPrefs.GetInt("Shield",0); i++) {
						ShieldIndicators [i].SetActive (true);
				}


		}

		void Update ()
		{

				magnetCostText.text = "" + PlayerPrefs.GetInt ("MagnetCost", 500);//for magnet cost text
				multiplierCostText.text = " " + PlayerPrefs.GetInt ("MultiplierCost", 1000);//for multiplier cost text
				ShieldCostText.text = " " + PlayerPrefs.GetInt ("ShieldCost", 500);//for shield cost text
				//for delet all
				if (Input.GetKey (KeyCode.D)) {
						PlayerPrefs.DeleteAll ();
				}
//		if (Input.GetKeyDown (KeyCode.Escape)) {
//			StoreMenuParent.SetActive(false);
//			mainMenuParent.SetActive(true);
//		}


		}
		//for button control
		public	void OnButtonClick (string ButtonName)
		{

				switch (ButtonName) {
				//for magnet buying
				case "Magnet":
						print ("Clicked on buy item1");
						IncreaseMagnetPower ();//for magnet purchase
						SoundController.Static.PlayClickSound ();//for click sound
						break;
				//for mutliplier buying
				case "BuyMultiplier":
						print ("Clicked on buy item2");
						IncreaseMultipiler ();//for multiplier purchase
						SoundController.Static.PlayClickSound ();//for click sound
						break;
//for shield buying
				case "BuyShield":
						print ("Clicked on buy item2");
						IncreaseShield ();//for shield purchase
						SoundController.Static.PlayClickSound ();//for click sound
						break;
				//for back to the main menu
				case "Back":
						StoreMenuParent.SetActive (false);
						mainMenuParent.SetActive (true);
						SoundController.Static.PlayClickSound ();//for click sound
						break;

				}
		}
	
 
		//for magnet purchase
		void IncreaseMagnetPower ()
		{
				//for magnet purchase
				if (TotalCoins.Static.totalCoins >= PlayerPrefs.GetInt ("MagnetCost", 500) && PlayerPrefs.GetInt ("MagnetPower", 0) <= 3) {

						TotalCoins.Static.SubtractCoins (PlayerPrefs.GetInt ("MagnetCost", 500));//for subtraction coins in to magnet cost
						PlayerPrefs.SetInt ("MagnetCost", PlayerPrefs.GetInt ("MagnetCost", 500) + 500);//for magnet cost increase
						//for show magnet fill bar
						for (int i=0; i<MagnetIndicators.Length; i++) {
								Debug.Log ("Magnet Power1 " + PlayerPrefs.GetInt ("MagnetPower", 0));
								if (i == PlayerPrefs.GetInt ("MagnetPower", 0)) {

										MagnetIndicators [i].SetActive (true);
								}
							
						}
						//for ingame magnet value
						PlayerPrefs.SetInt ("IngameMagnetCount", PlayerPrefs.GetInt ("IngamemagnetCount", 0) + 6);
						PlayerPrefs.SetInt ("MagnetPower", PlayerPrefs.GetInt ("MagnetPower") + 1);
				}
		//for full text showing
		else {
						if (PlayerPrefs.GetInt ("MagnetPower", 0) > 3) {
								MagnetFull.text = "Full";
						}
			//for unsufficent menu showing
				else {
								//gameObject.SetActive(false);
								unSufficentCoinsParent.SetActive (true);
								StoreMenuParent.SetActive (false);
								//	MainMenuScreens.currentScreen=MainMenuScreens.MenuScreens.StoreMenu;
						}
				}

		}
		//for multiplier purchase
		void IncreaseMultipiler ()
		{
				//for multiplier purchase
				if (TotalCoins.Static.totalCoins >= PlayerPrefs.GetInt ("MultiplierCost", 1000) && PlayerPrefs.GetInt ("Multiplier", 0) <= 3) {
						TotalCoins.Static.SubtractCoins (PlayerPrefs.GetInt ("MultiplierCost", 1000));//for subtraction coins in to multiplier cost
						PlayerPrefs.SetInt ("MultiplierCost", PlayerPrefs.GetInt ("MultiplierCost", 1000) + 1000);//for multiplier cost increase
						//for show multiplier fill bar
						for (int i=0; i<multiplierIndicators.Length; i++) {
								Debug.Log ("Magnet Power1 " + PlayerPrefs.GetInt ("Multiplier", 0));
								if (i == PlayerPrefs.GetInt ("Multiplier", 0)) {
					
										multiplierIndicators [i].SetActive (true);
								}
				
						}
						//for ingame multiplier value
						PlayerPrefs.SetInt ("IngameMultiplierCount", PlayerPrefs.GetInt ("IngameMultiplierCount", 0) + 2);
						PlayerPrefs.SetInt ("Multiplier", PlayerPrefs.GetInt ("Multiplier") + 1);

				}
		//for showing full text
		else {
						if (PlayerPrefs.GetInt ("Multiplier", 0) > 3) {
				
								MultiplayerFull.text = "Full";
						} 
			//for unsufficent menu showing
			else {
								//gameObject.SetActive(false);
								StoreMenuParent.SetActive (false);
								unSufficentCoinsParent.SetActive (true);
								//	MainMenuScreens.currentScreen=MainMenuScreens.MenuScreens.StoreMenu;
						}
				}
		
		}
		//for shield purchas
		void IncreaseShield ()
		{
				//for shield purchas
				if (TotalCoins.Static.totalCoins >= PlayerPrefs.GetInt ("ShieldCost", 500) && PlayerPrefs.GetInt ("Shield", 0) <= 3) {
						TotalCoins.Static.SubtractCoins (PlayerPrefs.GetInt ("ShieldCost", 500));//for subtraction coins in to shield cost
						PlayerPrefs.SetInt ("ShieldCost", PlayerPrefs.GetInt ("ShieldCost", 500) + 500);//for shield cost increase
						//for show shield fill bar
						for (int i=0; i<ShieldIndicators.Length; i++) {
								Debug.Log ("Magnet Power1 " + PlayerPrefs.GetInt ("Shield", 0));
								if (i == PlayerPrefs.GetInt ("Shield", 0)) {
					
										ShieldIndicators [i].SetActive (true);
								}
				
						}
						//for ingame shield value
						PlayerPrefs.SetInt ("IngameShieldCount", PlayerPrefs.GetInt ("IngameShieldCount", 0) + 6);
						PlayerPrefs.SetInt ("Shield", PlayerPrefs.GetInt ("Shield") + 1);
			
				}
		//for showing full text
		else {
						if (PlayerPrefs.GetInt ("Shield", 0) > 3) {
				
								ShieldFulltext.text = "Full";
						}
			//for unsufficent menu showing
			else {
								//gameObject.SetActive(false);
								StoreMenuParent.SetActive (false);
								unSufficentCoinsParent.SetActive (true);
								//	MainMenuScreens.currentScreen=MainMenuScreens.MenuScreens.StoreMenu;
						}
				}
		
		}





}
