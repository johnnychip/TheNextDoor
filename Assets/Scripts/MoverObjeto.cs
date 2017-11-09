using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class MoverObjeto : MonoBehaviour, IInspectObjects {

	[SerializeField]
	private Transform limitA;

	[SerializeField]
	private Transform limitB;

	[SerializeField]
	private GameObject[] objectsToAction;

	private float modificator;

	private bool isPlayerActive;

	private bool isActionated;

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
			
			if(modificator>=1)
			{
				foreach(GameObject temp in objectsToAction)
				{
					temp.GetComponent<IInspectObjects>().Action(gameObject,gameObject);
				}
				GoingOut(currentPlayer,currentPlayer);
				isActionated = true;
			}
		}
	}

	public void Action(GameObject player, GameObject aimObject)
	{

		

		if(Input.GetKeyDown(KeyCode.E)&&!isActionated)
			{	
				if(isPlayerActive)
				{
				UIManager.Instance.SetMessageScreen("Press W to move");
				player.GetComponent<RigidbodyFirstPersonController>().enabled = false;
				isPlayerActive = false;
				player.transform.SetParent(transform);
				currentPlayer = player;
				}
				else
				{
				player.GetComponent<RigidbodyFirstPersonController>().enabled = true;
				isPlayerActive = true;
				player.transform.SetParent(null);
				currentPlayer = null;
				}
			}
	}

	public void GoingOut(GameObject player, GameObject aimObject)
	{
		player.GetComponent<RigidbodyFirstPersonController>().enabled = true;
		isPlayerActive = true;
		player.transform.SetParent(null);
	}

	void LerpingDoor()
	{
		transform.position = Vector3.Lerp(limitA.position, limitB.position, modificator);
	}
	
}
