using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class buyPopUP : MonoBehaviour {


	//public Text costText;
	public GameObject PlayerSelectionMenuParent,buyPopUpMenuParent,SelectBtn,BuyBtn,playerGroup;
		

	public static int PlayerCost;//for player cost
	void OnEnable()
	{
		//costText.text=" "+PlayerCost;
   

	}
	void Start () {
	
	}
	
	void  Update (){
		//for escape present menu
		if (Input.GetKeyDown (KeyCode.Escape)) {
			buyPopUpMenuParent.SetActive(false);
			PlayerSelectionMenuParent.SetActive(true);
		}
		}

	//for buypopup menu buttons control
public	void OnButtonClick(string ButtonName )
	{


		switch(ButtonName)
			{
			//for buy  player 
			case "YES":
				 
			PlayerPrefs.SetInt("isPlayer"+Playerselection.PlayerIndex+"Purchased",1); // to save the Player lock status
			TotalCoins.Static.SubtractCoins(PlayerCost);//for SubtractCoins in to total coins
		     	 SelectBtn.SetActive(true);
			     BuyBtn.SetActive(false);
			playerGroup.SetActive(true);
			PlayerSelectionMenuParent.SetActive(true);
			buyPopUpMenuParent.SetActive(false);
			SoundController.Static.PlayClickSound();//for click sound
				break;
			//for cancel buy  player 
			case "NO":
			SoundController.Static.PlayClickSound();//for click sound
			playerGroup.SetActive(true);
			PlayerSelectionMenuParent.SetActive(true);
			buyPopUpMenuParent.SetActive(false);
				break;
			 
				
			}
			
		}
		
	}

