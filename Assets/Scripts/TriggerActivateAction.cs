using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActivateAction : MonoBehaviour {


	[SerializeField]
	private bool isLoop;

	[SerializeField]
	private GameObject[] objectsToAction;

	private bool isActivated;
	
	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			PlayActions(other.gameObject);
		}
	}

	private void PlayActions (GameObject other)
	{
		if(isLoop)
		{
			foreach(GameObject temp in objectsToAction)
			{
				temp.GetComponent<IInspectObjects>().Action(other, other);
			}
		}else
		{
			if(!isActivated)
			{
				foreach(GameObject temp in objectsToAction)
				{
					temp.GetComponent<IInspectObjects>().Action(other, other);
				}
				isActivated = true;
			}
		}
	}

}
