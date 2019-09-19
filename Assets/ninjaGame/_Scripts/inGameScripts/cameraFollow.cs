using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour
{



	// Use this for initialization
	public Transform target ;//to camera follow the object
	public Vector3 offset ; //to take offset values
	Transform thisTrans ; // to camera postion
	//public  Animator cameraAnimator;
	public static cameraFollow Static;
	[SerializeField]
	[Range(10,110)]
	float
		smoothFollowSpeed;
	void Start ()
	{
		thisTrans = transform;
		Static = this;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		//to camera folling in player postion
		Vector3 smoothTarget = new Vector3 (target.position.x + offset.x, offset.y, offset.z);
		thisTrans.position = Vector3.MoveTowards (thisTrans.position, smoothTarget, Time.deltaTime * smoothFollowSpeed);
		;

	}
}
