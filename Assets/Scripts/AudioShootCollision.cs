using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioShootCollision : MonoBehaviour {

	[SerializeField]
	private AudioSource audioTrigger;

	[SerializeField]
	private bool isReapeting;

	private bool isPlayed;

	void OnTriggerEnter(Collider other)
	{
		if(isReapeting)
		{
			audioTrigger.Play();
		}else
		{
			if(!isPlayed)
			{
				audioTrigger.Play();
				isPlayed = true;
			}
		}
	}
}
