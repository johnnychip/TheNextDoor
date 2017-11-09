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

	[SerializeField]
	private GameObject[] thisSetActive;

	private bool isPut;

	public void Action(GameObject player, GameObject aimObject)
	{
		if(isPut)
			return;

		if(myLibrary.TryToPutObject(objectInLibrary, transform))
		{
			isPut = true;

			AudioManager.Instance.PlayTakeSound();

			if(thisSetActive.Length>0)
			{
				foreach(GameObject temp in thisSetActive)
					temp.SetActive(true);
			}

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
