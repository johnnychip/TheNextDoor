﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowNotesScript : MonoBehaviour, IInspectObjects {

	[SerializeField]
	private string stringNote;

	[SerializeField]
	private GameObject objNote;

	[SerializeField]
	private Text textNote; 

	[SerializeField]
	private GameObject[] thigsToActivate;

	public void Action(GameObject player, GameObject aimObject)
	{
		if(!objNote.activeSelf)
		{
			objNote.SetActive(true);
			textNote.text = stringNote;
			if(thigsToActivate!=null){
				foreach(GameObject temp in thigsToActivate)
				temp.GetComponent<IInspectObjects>().Action(player,gameObject);
			}
		}else
		{
			objNote.SetActive(false);
		}
	}

	public void GoingOut(GameObject player, GameObject aimObject)
	{
		objNote.SetActive(false);
	}
}
