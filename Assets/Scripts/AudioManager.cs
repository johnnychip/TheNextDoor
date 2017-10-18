using System.Collections;
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
		Debug.Log("It is playing");
		myAudioSoure.clip = myAudios[0];
		myAudioSoure.Play();
	}

}
