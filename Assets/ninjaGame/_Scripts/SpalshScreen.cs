using UnityEngine;
using System.Collections;

public class SpalshScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Invoke("loadMenuLevel",2.0f);
	//	iTween.FadeTo(logo,1.0f,1.0f);
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}
	
	// Update is called once per frame

	void loadMenuLevel( )
	{
		Application.LoadLevel("Mainmenu");
	}
	 
	public GameObject logo;
	void Update () {

	    
	   

		if(Input.GetKey(KeyCode.Mouse0) )
		{
			loadMenuLevel();
		}

		if(Input.GetKey(KeyCode.Escape) )
		{
			Application.Quit();
		}
	}
}
