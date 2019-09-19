using UnityEngine;
using System.Collections;

public class LoadingRotation : MonoBehaviour
{

		// Use this for initialization

		public GameObject LoadinBg;//for loading bg

		void Start ()
		{
				//Invoke ("gameplay",3f);
		}

		void Update ()
		{
				LoadinBg.transform.Rotate (Vector3.forward * -3);//for rotating Loading object
		       
		}
	    //for moving gameplay scene
		public static void gameplay ()
		{
		Application.LoadLevelAsync ("NinjaGameplay");   //for  gameplay scene

		}

}
