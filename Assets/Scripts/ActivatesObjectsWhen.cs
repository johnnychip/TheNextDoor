using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatesObjectsWhen : MonoBehaviour, IInspectObjects {

	[SerializeField]
	private GameObject[] objectsToActivate;

	public void Action(GameObject player, GameObject aimObject)
	{
		if(objectsToActivate.Length>0)
		{
			foreach(GameObject temp in objectsToActivate)
				{
					if(temp.activeSelf)
					{
						temp.SetActive(false);
					}else
					{
						temp.SetActive(true);
					}
				}
		}
	}

	public void GoingOut(GameObject player, GameObject aimObject)
	{

	}

}
