using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotToPutObject : MonoBehaviour, IInspectObjects {

	[SerializeField]
	private LibraryOfObjects myLibrary;

	[SerializeField]
	private int objectInLibrary;

	[SerializeField]
	private GameObject[] thigsToActivate;

	public void Action(GameObject player, GameObject aimObject)
	{
		if(myLibrary.TryToPutObject(objectInLibrary, transform))
		{

			AudioManager.Instance.PlayTakeSound();

			if(thigsToActivate.Length<=0)
				return;

			foreach(GameObject temp in thigsToActivate)
				temp.GetComponent<IInspectObjects>().Action(player,gameObject);
		}
	}

	public	void GoingOut(GameObject player, GameObject aimObject)
	{

	}

}
