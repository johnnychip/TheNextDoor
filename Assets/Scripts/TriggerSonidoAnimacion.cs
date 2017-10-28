using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSonidoAnimacion : MonoBehaviour {

	[SerializeField]
	private AudioSource myAudioSource;

	[SerializeField]
	private Animator animator;

	[SerializeField]
	private bool isLoop;

	[SerializeField]
	private bool isTriggered;


	public void PlayAnimation()
	{
		animator.SetTrigger("move");
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
