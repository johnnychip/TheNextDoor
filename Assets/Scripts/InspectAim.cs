using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class InspectAim : MonoBehaviour {

	private GameObject currentInspect;

	[SerializeField]
	private GameObject player;

	[SerializeField]
	private GameObject aim;

	[SerializeField]
	private GameObject handAim;

	void Update () {
		if(Input.GetKeyDown(KeyCode.E) && currentInspect != null)
		{
			currentInspect.GetComponent<IInspectObjects>().Action(player);
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag == "inspect")
		{
			currentInspect = other.gameObject;
			aim.SetActive(false);
			handAim.SetActive(true);
		}
	}

	void OnTriggerExit (Collider other)
	{
		if(other.gameObject == currentInspect)
		{	
			currentInspect.GetComponent<IInspectObjects>().GoingOut(player);
			player.GetComponent<RigidbodyFirstPersonController>().enabled=true;
			currentInspect = null;
			aim.SetActive(true);
			handAim.SetActive(false);
		}
	}

}
