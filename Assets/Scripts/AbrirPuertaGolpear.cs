using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AbrirPuertaGolpear : MonoBehaviour, IInspectObjects {

	[SerializeField]
	private Transform theDoor;

	[SerializeField]
	private Vector3 openDoorRotation;

	[SerializeField]
	private int nocksToOpen;

	private int nocksCounter;

	void Start () {
		DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
	}
	public void Action ()
	{
		if(nocksCounter<nocksToOpen)
		{
			nocksCounter++;
		}
		else
		{
			theDoor.DORotate(openDoorRotation,1.5f);
		}
	}

	public void GoingOut()
	{}

}
