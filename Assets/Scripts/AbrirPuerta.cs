using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class AbrirPuerta : MonoBehaviour {
	[SerializeField]
	private Vector3 clostRotation;

	[SerializeField]
	private Vector3 openRotation;

	[SerializeField]
	private Transform objectToRotate;

	private bool isPlayerOpen;

	private float currentRotation;

	private GameObject currentPlayer;

	// Use this for initialization
	void Start () {

		currentRotation = 0;

		LerpingDoor();
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			currentPlayer = other.gameObject;
			Debug.Log("Adentro");
		}
	}

		void OnTriggerExit(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			currentPlayer = null;
			Debug.Log("Afuera");
		}
	}

	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.E) && currentPlayer!=null)
		{
			if(!isPlayerOpen)
			{
				isPlayerOpen = true;
				currentPlayer.GetComponent<RigidbodyFirstPersonController>().enabled = false;
			}
			else
			{
				isPlayerOpen = false;
				currentPlayer.GetComponent<RigidbodyFirstPersonController>().enabled = true;
			}
		}

		

		if(isPlayerOpen && Input.GetAxis("Mouse Y") != 0)
		{
			currentRotation += 0.05f*Input.GetAxis("Mouse Y");
			LerpingDoor();
		}
	}

	void LerpingDoor()
	{
		objectToRotate.rotation = Quaternion.Euler( Vector3.Lerp(clostRotation, openRotation, currentRotation));
	}

}
