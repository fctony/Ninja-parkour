using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour
{
	public  Transform thisTrans;
	public static Vector3 thisPosition;//for zombie position
	public Animator ZombieAnim;//for zombie Animation
	public BoxCollider box ;//for zombie Collider 
	public GameObject FireEffect;//for Zombie dead Effect
	//for zombie States
	public enum ZombieStates
	{
		Alive,
		Dead,
		Null
	}
	public ZombieStates CurrentState;

	void Start ()
	{
		thisTrans = transform;
		//thisPosition = thisTrans.localPosition;
		box = GetComponent<BoxCollider> () as BoxCollider;
	}
	
	// Update is called once per frame
	void Update ()
	{

		switch (CurrentState) {
		//for zombie Alive state
		case ZombieStates.Alive:
					
			ZombieAnim.SetTrigger ("Move");

			break;
		//for zombie dead state
		case ZombieStates.Dead:
			             //Zombie head cutting Animation play Rondomly
			int randomValue = UnityEngine.Random.Range (-1, 2);
			if (randomValue > 0) {
				ZombieAnim.SetInteger ("HeadCutCount", 1);//Zombie head cutting Animation1
			} else if (randomValue == 0) {
				ZombieAnim.SetInteger ("HeadCutCount", 3);//Zombie head cutting Animation2
			} else 
				ZombieAnim.SetInteger ("HeadCutCount", 2);//Zombie head cutting Animation3
			break;
		case ZombieStates.Null:

			break;
		}
	}
	//to handle the Obsticles collision information
	void OnTriggerEnter (Collider Hit)
	{
		//for Obsticles hit Sword
		if (Hit.GetComponent<Collider> ().name.Contains ("sword")) {
			DeathState ();
		}
	}

	public void DeathState ()
	{
		CurrentState = ZombieStates.Dead;//For zombie dead state

		GetComponent<BoxCollider> ().enabled = false;
		box.size = new Vector3 (0, 0, 0);//for Zombie collider size
		Destroy (gameObject, 1f);//for destroy Zombie
		GameObject obj = Instantiate (FireEffect, transform.position, Quaternion.identity)as GameObject;//for Zombie dead Effect instantiate
		Destroy (obj, 1f);//destroy Zombie dead effect
		Ace_IngameUiControl.Static.inGameScoreCount++;//for Counting score
		SoundController.Static.playSoundFromName ("Dead2");	//for Zombie dead sound
	}

}
