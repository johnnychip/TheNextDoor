using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class MoverObjeto : MonoBehaviour {

	[SerializeField]
	private Transform limitA;

	[SerializeField]
	private Transform limitB;

	[SerializeField]
	private Transform playerSlot;

	private bool isPlayerActive;

	private GameObject currentPlayer;

	void Start()
	{
		isPlayerActive = true;
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			currentPlayer = other.gameObject;
		}
	}
	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			currentPlayer = other.gameObject;
		}
	}


	void Update ()
	{
		if(currentPlayer != null)
		{	
			if(Input.GetKeyDown(KeyCode.E))
			{	
				if(isPlayerActive)
				{
				currentPlayer.GetComponent<FirstPersonController>().enabled = false;
				isPlayerActive = false;
				currentPlayer.transform.SetParent(transform);
				}
				else
				{
				currentPlayer.GetComponent<FirstPersonController>().enabled = true;
				isPlayerActive = true;
				currentPlayer.transform.SetParent(null);
				}
			}
			

			if(Input.GetKeyDown(KeyCode.W))
			{
				
			}
		}

		
	}

	void LerpingDoor()
	{
		transform.position = Vector3.Lerp(limitA.position, limitB.position, 1);
	}
	
}
