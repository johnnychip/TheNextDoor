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

	void Start () {
		DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
	}
	public void Action (GameObject player, GameObject aimObject)
	{
		theDoor.DORotate(openDoorRotation,timeToOpen);
		audioPuerta.Play();
	}

	public void GoingOut(GameObject player, GameObject aimObject)
	{}
}
