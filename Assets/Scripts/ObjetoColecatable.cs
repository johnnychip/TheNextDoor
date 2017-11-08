using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoColecatable : Inspeccionador {

	[SerializeField]
	private int objectId;

	[SerializeField]
	private GameObject[] objectsToActivate;


	public bool isColected;

	public bool isBeingInspected;

	

    public override void Action(GameObject player, GameObject aimObject)
	{
		

		if(isColected)
			return;

		base.Action(player, aimObject);
		
		isBeingInspected = true;

	
		
	}

	public override void SomethignToDoInOutBlur()
	{
		CollectTheObject();
	}

	private void CollectTheObject()
	{
		AudioManager.Instance.PlayTakeSound();
		isColected = true;
		gameObject.SetActive(false);
		if(objectsToActivate!=null)
		{
			foreach(GameObject temp in objectsToActivate)
			{
				temp.GetComponent<IInspectObjects>().Action(gameObject,gameObject);
			}
		}
	}

}
