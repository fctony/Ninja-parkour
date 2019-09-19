using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public GameObject[] ForestWorld;//to forest world
	public GameObject[] CastleWorld;//to castle world
	public static GameController Static;
	public float nextBlockDistance = 50;// to distance next world
	public GameObject[]  NewCoins, Zombies, Obsticles;
	public GameObject[] PowerUps;//to powerups
	public Transform Player;
	public bool isplayerDaed;
		
	// Use this for initialization
	//for game states
	public enum GameState
	{
		idle,
		GameStart,
		GamePlay,
		GamePause,
		GameEnd
	}
	//for world states
	public enum WorldType
	{
		forest,
		castle

	}
	public   WorldType currentWorld;
	public static GameState CurrentState ;

	void Start ()
	{
		Static = this;
		CurrentState = GameState.idle;	 
		currentWorld = WorldType.castle;
	}

	int startCount = 2 ;
	public void StartGamePlay ()
	{
		startCount --;

		if (startCount <= 0)
			CurrentState = GameState.GameStart;
	}
	// Update is called once per frame
	void FixedUpdate ()
	{
		switch (CurrentState) {
		//for game start state
		case GameState.GameStart:
			InvokeRepeating ("CreateNewCoins", 0.8f, 3.5f);	//for creating coins
			InvokeRepeating ("CreateZombies", 0.5f, 2.5f);	//for creating zombies
			InvokeRepeating ("CreateObsticles", 1.2f, 10.0f);//for creating obsticles
			InvokeRepeating ("CreatePowerUps", 10.2f, 45.5f);//for creating powerups
			InvokeRepeating ("SwitchWorlds", 0, 20);
			CurrentState = GameState.GamePlay;//for current state
			break;
		//for game Play state
		case GameState.GamePlay:
			
			break;

		//for game End state
		case GameState.GameEnd:
			
			break;

			
		}
	}

	int blockCount = 2;//for counting blocks
	GameObject choosenWorldObj;//to choose which world
	//for creating world
	public	void CreateNewWorld ()
	{

		 
		         
		switch (currentWorld) {
		// to forest world state
		case WorldType.forest:
			choosenWorldObj = ForestWorld [Random.Range (0, ForestWorld.Length)];
			break;
		// to castle world state
		case WorldType.castle:
			choosenWorldObj = CastleWorld [Random.Range (0, CastleWorld.Length)];
			break;
		}
		//to instantiate world 
		GameObject obj = GameObject.Instantiate (choosenWorldObj, new Vector3 (nextBlockDistance * blockCount, 0, 0), Quaternion.identity)as GameObject;
		      
		blockCount++;


		
	}
	
				 
	public void SwitchWorlds ()
	{
		if (currentWorld == WorldType.forest)
			currentWorld = WorldType.castle;
		else
			currentWorld = WorldType.forest;
	}
	// for creating coins
	public	void CreateNewCoins ()
	{
		if (isplayerDaed)
			return;
			
		GameObject obj = GameObject.Instantiate (NewCoins [Random.Range (0, NewCoins.Length)], new Vector3 (Player.position.x + 20, Random.Range (1.0f, 2.5f), Player.position.z), Quaternion.identity)as GameObject;
		Destroy (obj, 15f);
		
		
	}
	//for creating powerups
	public	void CreatePowerUps ()
	{
			
		if (isplayerDaed)
			return;
				
		GameObject obj = GameObject.Instantiate (PowerUps [Random.Range (0, PowerUps.Length)], new Vector3 (Player.position.x + 40, Random.Range (1.0f, 1.5f), Player.position.z), Quaternion.identity)as GameObject;
		Destroy (obj, 15f);
				
		
	}
	//for creating zomblies
	public	void CreateZombies ()
	{
		if (isplayerDaed)
			return;
				
		GameObject obj = GameObject.Instantiate (Zombies [Random.Range (0, Zombies.Length)], new Vector3 (Player.position.x + 30, 0, Player.position.z), Quaternion.identity)as GameObject;
		
		Destroy (obj, 20.0f);

		
	}
	//for creating Obsticles
	public	void CreateObsticles ()
	{
		if (isplayerDaed)
			return;
				
		GameObject obj = GameObject.Instantiate (Obsticles [Random.Range (0, Obsticles.Length)], new Vector3 (Player.position.x + 35, 0, Player.position.z), Quaternion.identity)as GameObject;
		
		Destroy (obj, 20.0f);
		
	}
	
}
