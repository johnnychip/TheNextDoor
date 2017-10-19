using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TriggerToSimpleMove : MonoBehaviour {

	[SerializeField]
	private Transform positionTo;

	[SerializeField]
	private float duration;

	[SerializeField]
	private Transform objectToMove;

	// Use this for initialization
	void Start () 
	{
		DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			MoveObject();
		}
	}

	public void MoveObject ()
	{
		objectToMove.DOMove(positionTo.position, duration, false);
		gameObject.SetActive(false);
	}


}
