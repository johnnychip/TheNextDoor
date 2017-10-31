using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoColecatable : MonoBehaviour, IInspectObjects {

	[SerializeField]
	private int objectId;

	[SerializeField]
	private GameObject[] objectsToActivate;

	public bool isColected;



    public void Action(GameObject player, GameObject aimObject)
	{
		if(isColected)
			return;

		AudioManager.Instance.PlayTakeSound();
		isColected = true;
		aimObject.GetComponent<InspectAim>().ActivateAim();
		gameObject.SetActive(false);

		if(objectsToActivate!=null)
		{
			foreach(GameObject temp in objectsToActivate)
			{
				temp.GetComponent<IInspectObjects>().Action(gameObject,gameObject);
			}
		}
	}

	public void GoingOut(GameObject player, GameObject aimObject)
	{
        //GoingOut
	}
}
