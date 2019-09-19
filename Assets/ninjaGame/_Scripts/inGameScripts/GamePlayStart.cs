using UnityEngine;
using System.Collections;

public class GamePlayStart : MonoBehaviour
{

	// Use this for initialization
	void OnDisable ()
	{
		GameController.Static.StartGamePlay ();
	}
}
