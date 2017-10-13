using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TriggerLuzIntermitente : MonoBehaviour, IInspectObjects {

	[SerializeField]
	private Light myLight;

	[SerializeField]
	private float endValueIntensity;

	[SerializeField]
	private float duration;

	void Start ()
	{
		DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
	}

	public void Action(GameObject player, GameObject aimObject)
	{
		myLight.DOIntensity(endValueIntensity,duration).SetLoops(8);
	}

	public void GoingOut(GameObject player, GameObject aimObject)
	{

	}

}
