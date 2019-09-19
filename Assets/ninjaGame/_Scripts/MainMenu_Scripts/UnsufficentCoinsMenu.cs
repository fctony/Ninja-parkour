using UnityEngine;
using System.Collections;

public class UnsufficentCoinsMenu : MonoBehaviour {

	public GameObject InAppMenuParent,UnsufficentMenu;//for inapp,unsufficent menu screens
	void Start () {
	
	}
	void  Update (){

	}


//for button control
	public void OnButtonClick(string ButtonName){
		switch (ButtonName){
			//for ok button
		case "Ok":
			InAppMenuParent.SetActive(true);//for inapp enables
			UnsufficentMenu.SetActive(false);//for unsufficent menu disables
			SoundController.Static.PlayClickSound();//for click sound
			MainMenuScreens.currentScreen=MainMenuScreens.MenuScreens.InnAppmenu;//for moving inapp menu state
			break;
		}
	}
}
