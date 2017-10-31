using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TriggerSonidoAnimacion : MonoBehaviour {

	[SerializeField]
	private AudioSource myAudioSource;

	[SerializeField]
	private Animator animator;

	[SerializeField]
	private Transform objectToTrigger;

	[SerializeField]
	private bool isLoop;

	[SerializeField]
	private bool isTriggered;

	[SerializeField]
	private Vector3 rotionTo;


	void Start ()
	{
		DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
	}

	public void PlayAnimation()
	{
		objectToTrigger.DORotate(rotionTo,0.2f).SetLoops(6);
		myAudioSource.Play();
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			if(isLoop)
			{
				PlayAnimation();
			}else
			{
				if(!isTriggered)
				{
					PlayAnimation();
					isTriggered = true;
				}
			}
		}
	}

}
