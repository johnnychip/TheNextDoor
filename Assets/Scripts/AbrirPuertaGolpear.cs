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
	
	[SerializeField]
	private float timeToOpen;

	[SerializeField]
	private GameObject[] thigsToActivate;

	private int nocksCounter;

	void Start () {
		DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
	}
	public void Action (GameObject player)
	{
		if(nocksCounter<nocksToOpen)
		{
			nocksCounter++;
		}
		else
		{
			theDoor.DORotate(openDoorRotation,timeToOpen);
			if(thigsToActivate!=null){
				foreach(GameObject temp in thigsToActivate)
				temp.GetComponent<IInspectObjects>().Action(player);
			}
		}
	}

	public void GoingOut(GameObject player)
	{}

}
