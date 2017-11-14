using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepyMelodyTrigger : MonoBehaviour {

	[SerializeField]
	private AudioSource myAudioSource;

	[SerializeField]
	private AudioClip[] myScareClips;

	[SerializeField]
	private int theSoundToTrigger;

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			if(!myAudioSource.isPlaying)
			{
				myAudioSource.clip = myScareClips[theSoundToTrigger];
				myAudioSource.Play();
			}
		}
	}

}
