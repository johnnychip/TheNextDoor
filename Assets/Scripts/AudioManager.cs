﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	[SerializeField]
	private AudioSource myAudioSoure;

	[SerializeField]
	private AudioClip[] myAudios;


	public static AudioManager Instance
	{
		get;
		private set;
	}

	void Awake ()
	{
		if(Instance != null)
			Destroy(gameObject);
		else
			Instance = this;
	}

	public void PlayTakeSound()
	{
		myAudioSoure.clip = myAudios[0];
		myAudioSoure.Play();
	}

	public void PlayDoorSound()
	{
		myAudioSoure.clip = myAudios[1];
		myAudioSoure.Play();
	}

}
