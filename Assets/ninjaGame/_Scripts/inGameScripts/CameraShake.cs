using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

	public Transform camTransform;
	
	// How long the object should shake for.
	public float shake = 0f;//to camera shake time
	
	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.7f;//to camera shake amount
	public float decreaseFactor = 1.0f;//camera shake decrease amount
	
	Vector3 originalPos;//to camera position
	
	void Awake()
	{
		//to getting camera object
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}
	
	void OnEnable()
	{
		originalPos = camTransform.localPosition;
	}
	
	void Update()
	{
		  //for camera shake 
		if (shake > 0)
		{
			camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
			
			shake -= Time.deltaTime * decreaseFactor;//to shake time decrease
		}
		//for camera change normal postion  
		else
		{
			shake = 0f;
			camTransform.localPosition = originalPos;
		}
	}
}
