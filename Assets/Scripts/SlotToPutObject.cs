using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotToPutObject : MonoBehaviour, IInspectObjects {

	[SerializeField]
	private LibraryOfObjects myLibrary;

	[SerializeField]
	private int objectInLibrary;

	public void Action(GameObject player, GameObject aimObject)
	{
		myLibrary.TryToPutObject(objectInLibrary, transform);
	}

	public	void GoingOut(GameObject player, GameObject aimObject)
	{

	}

}
