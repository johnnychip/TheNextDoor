using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class MoverObjeto : MonoBehaviour, IInspectObjects {

	[SerializeField]
	private Transform limitA;

	[SerializeField]
	private Transform limitB;


	private float modificator;

	private bool isPlayerActive;

	private GameObject currentPlayer;

	private

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
		if(!isPlayerActive)
		{
			if(Input.GetKey(KeyCode.W))
			{
				modificator += 0.01f;
			}
			if(Input.GetKey(KeyCode.S))
			{
				modificator -= 0.01f;
			}
			modificator = Mathf.Clamp(modificator,0,1);
			LerpingDoor();
		}
	}

	public void Action(GameObject player)
	{
		if(Input.GetKeyDown(KeyCode.E))
			{	
				if(isPlayerActive)
				{
				player.GetComponent<RigidbodyFirstPersonController>().enabled = false;
				isPlayerActive = false;
				player.transform.SetParent(transform);
				}
				else
				{
				player.GetComponent<RigidbodyFirstPersonController>().enabled = true;
				isPlayerActive = true;
				player.transform.SetParent(null);
				}
			}
	}

	public void GoingOut(GameObject player)
	{
		isPlayerActive = true;
		player.transform.SetParent(null);
	}

	void LerpingDoor()
	{
		transform.position = Vector3.Lerp(limitA.position, limitB.position, modificator);
	}
	
}
