using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour
{


		 

	void OnBecameInvisible ()
	{
		Debug.Log ("destroyer called here");

		Destroy (gameObject);
	}
}
