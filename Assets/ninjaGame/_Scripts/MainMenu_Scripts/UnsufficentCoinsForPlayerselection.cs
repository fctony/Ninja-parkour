using UnityEngine;
using System.Collections;

public class UnsufficentCoinsForPlayerselection : MonoBehaviour {

	public GameObject UnsufficentCoinsForPlayerselectionMenu,InAppMenuParent;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//for button control
	public void OnButtonClick(string ButtonName){
		switch (ButtonName){
			//for ok button
		case "ok":
			SoundController.Static.PlayClickSound();//for click sound
			UnsufficentCoinsForPlayerselectionMenu.SetActive(false);//for unsufficent menu Disables
			InAppMenuParent.SetActive(true);//inapp menu Enables
			MainMenuScreens.currentScreen=MainMenuScreens.MenuScreens.InnAppmenu;//for moving inapp menu state
			break;
		}
	}
}
