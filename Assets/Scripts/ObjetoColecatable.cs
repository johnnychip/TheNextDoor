using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjetoColecatable : Inspeccionador {

	[SerializeField]
	private int objectId;

	[SerializeField]
	private GameObject[] objectsToActivate;

	private GameObject playerObject;

	public bool isColected;

	public bool isBeingInspected;

	

    public override void Action(GameObject player, GameObject aimObject)
	{
		

		if(isColected)
			return;

		playerObject = player;

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
		playerObject.GetComponentInChildren<InspectAim>().ActivateAim();
		gameObject.SetActive(false);
		
		if(objectsToActivate!=null)
		{
			foreach(GameObject temp in objectsToActivate)
			{
				temp.GetComponent<IInspectObjects>().Action(gameObject,gameObject);
			}
		}
		
	}

	public override void GoingOut(GameObject player, GameObject aimObject)
	{

		if(!isColected)
			base.GoingOut(player,aimObject);
        
    }

}
