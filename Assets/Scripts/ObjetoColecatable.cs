﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoColecatable : MonoBehaviour, IInspectObjects {

	[SerializeField]
	private int objectId;

	public bool isColected;

	public void Action(GameObject player, GameObject aimObject)
	{
		isColected = true;
		aimObject.GetComponent<InspectAim>().ActivateAim();
		gameObject.SetActive(false);
	}

	public void GoingOut(GameObject player, GameObject aimObject)
	{

	}
}
