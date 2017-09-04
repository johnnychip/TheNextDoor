using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PuertaAbrir : MonoBehaviour, IInspectObjects {

	[SerializeField]
	private Transform theDoor;

	[SerializeField]
	private Vector3 openDoorRotation;

	void Start () {
		DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
	}
	public void Action ()
	{
		theDoor.DORotate(openDoorRotation,1);
	}

	public void GoingOut()
	{}
}
