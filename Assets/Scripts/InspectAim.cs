using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class InspectAim : MonoBehaviour {

	private GameObject currentInspect;

	[SerializeField]
	private GameObject player;

	void Update () {
		if(Input.GetKeyDown(KeyCode.E) && currentInspect != null)
		{
			currentInspect.GetComponent<IInspectObjects>().Action();
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag == "inspect")
		{
			currentInspect = other.gameObject;
		}
	}

	void OnTriggerExit (Collider other)
	{
		if(other.gameObject == currentInspect)
		{	
			currentInspect.GetComponent<IInspectObjects>().GoingOut();
			currentInspect = null;
		}
	}

}
