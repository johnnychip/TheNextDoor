using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PuertaAbrir : MonoBehaviour, IInspectObjects {

	[SerializeField]
	private Transform theDoor;

	[SerializeField]
	private Vector3 openDoorRotation;

	[SerializeField]
	private float timeToOpen;

	[SerializeField]
	private AudioSource audioPuerta;

	[SerializeField]
	private LibraryOfObjects myLibrary;

	[SerializeField]
	private int objectToCheckInLibrary;

	[SerializeField]
	private bool isNeedingKey;

	private bool isOpen;

	void Start () {
		DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
	}
	public void Action (GameObject player, GameObject aimObject)
	{	
		if(isOpen)
			return;

		if(isNeedingKey)
		{
			if(myLibrary.ObjectWasColected(objectToCheckInLibrary))
			{
				OpenDoor();
			}else
			{
				myLibrary.ShowTextKey();
			}
			
		}else
		{
			OpenDoor();
		}
		
	}

	private void OpenDoor()
	{
		isOpen= true;
		theDoor.DORotate(openDoorRotation,timeToOpen);
		audioPuerta.Play();
	}

	public void GoingOut(GameObject player, GameObject aimObject)
	{}
}
