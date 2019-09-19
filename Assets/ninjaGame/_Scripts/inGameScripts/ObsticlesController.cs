using UnityEngine;
using System.Collections;

public class ObsticlesController : MonoBehaviour
{

	// Use this for initialization
	public BoxCollider box ;
	public GameObject BrokenObj;//for pot istantiate
	void Start ()
	{
		//box = GetComponent<BoxCollider> () as BoxCollider;
	}
	
	// Update is called once per frame
	 
	//to handle the Obsticles Collider information
	void OnTriggerEnter (Collider Hit)
	{
		//for Obsticles hit Sword
		if (Hit.GetComponent<Collider> ().name.Contains ("sword")) {

			//box.size = new Vector3 (0, 0, 0);//to obj collider size
			Hit.gameObject.GetComponent<Collider> ().isTrigger = true;
			GameObject obj = Instantiate (BrokenObj, gameObject.transform.position, Quaternion.identity)as GameObject;//for broken pot
			Destroy (obj, 0.5f);//to destroy the instantiate obj
			PlayerController.thisPosition = new Vector3 (PlayerController.thisPosition.x, PlayerController.thisPosition.y, -7.0f);
			SoundController.Static.playSoundFromName ("PotCrash");//for pot broken sound
			Destroy (gameObject);//to desrtoy the obsticles
		}
	}
}
