using UnityEngine;
using System.Collections;

public class ControlSelection : MonoBehaviour {

	public GameObject LoadingMenuParent,LevelSelectionParent,ControlSelectionParent,TotalCoinsParent;
	void Start () {
	
	}

	void  Update (){
//		if (Input.GetKeyDown (KeyCode.Escape)) {
//			ControlSelectionParent.SetActive(false);
//			LevelSelectionParent.SetActive(true);
//		}
	}


	
	public void OnButtonClick(string ButtonName){
		switch(ButtonName){
		case "AccelarationMode":
			SoundController.Static.PlayClickSound();
			LoadingMenuParent.SetActive(true);
			ControlSelectionParent.SetActive(false);
			TotalCoinsParent.SetActive(false);
			break;

		case "ButtonMode":
			SoundController.Static.PlayClickSound();
			LoadingMenuParent.SetActive(true);
			ControlSelectionParent.SetActive(false);
			TotalCoinsParent.SetActive(false);
			break;

		case "Back":
			SoundController.Static.PlayClickSound();
			ControlSelectionParent.SetActive(false);
			LevelSelectionParent.SetActive(true);
			break;
		}

	}
}
