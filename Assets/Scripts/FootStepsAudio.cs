using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepsAudio : MonoBehaviour {

	[SerializeField]
	private AudioSource myAudioSource;

	[SerializeField]
	private Rigidbody rb;



	// Use this for initialization
	void Start () {
		myAudioSource.Pause();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.S)||Input.GetKeyDown(KeyCode.D)||Input.GetKeyDown(KeyCode.W))
		{
			if(Vector3.Magnitude(rb.velocity) > 0 && !myAudioSource.isPlaying)
			{
				myAudioSource.Play();
			}
		}

		if(Vector3.Magnitude(rb.velocity)<=0.001f)
		{
			myAudioSource.Pause();
		}else
		{
			if(!myAudioSource.isPlaying)
			{
				myAudioSource.Play();	
			}
		}

		
	}
}
