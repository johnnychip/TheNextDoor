using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girador : MonoBehaviour {

	[SerializeField]
	private Vector3 startRotation;

	[SerializeField]
	private Vector3 endRotation;

	[SerializeField]
	private Transform objRotator;


	void OnTriggerEnter (Collider other)
	{
		if(objRotator.rotation.eulerAngles != startRotation)
		{
			objRotator.rotation = Quaternion.Euler(startRotation);
		}
		else
		{
			objRotator.rotation = Quaternion.Euler(endRotation);
		}
	}

}
