using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesEffect : MonoBehaviour {

	[Range(0.1f,2f)]
	public float velocityEffect;

	[Range(0.1f,2f)]
	public float sizeEffect;

	[SerializeField]
	private ParticleSystem myParticleSystem;

	[SerializeField]
	private AudioSource myAudioSource;

	[SerializeField]
	private Light myLight;

	[SerializeField]
	private AnimationCurve fadeInCurve;

	[SerializeField]
	private AnimationCurve fadeOutCurve;

	[SerializeField]
	private Gradient colorGradientlight;

	[SerializeField]
	private GameObject myEffector;

	[SerializeField]
	private float state1Percent, state2Percent, state3Percent;


	private float timeOfEffect;


	private float state1Lenght, state2Lenght, state3Lenght;

	private float state1Time, state2Time, state3Time;

	private float elapsedTime;

	private int state;

	// Use this for initialization
	void Start () {
		timeOfEffect = 1f;
	}	
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LaunchEffect()
	{	
		SetUpVelocity();
		SetUpTime();
		myEffector.SetActive(true);
		state = 1;
		myParticleSystem.Play();
		myAudioSource.Play();
		StartCoroutine(TheEffect());

		
	}

	private void SetUpVelocity()
	{
		var main = myParticleSystem.main;
		main.duration = timeOfEffect;

		float changeDuration = timeOfEffect*velocityEffect;

		myAudioSource.pitch -=(-velocityEffect+1);
	}

	private	void SetUpLight()
	{
		myLight.intensity = 0f;
	}

	private void SetUpTime ()
	{
		state1Lenght = timeOfEffect * state1Percent;
		state2Lenght = timeOfEffect * state2Percent;
		state3Lenght = timeOfEffect * state3Percent;

		state1Time = 0f;
		state2Time = 0f;
		state3Time = 0f;
		elapsedTime = 0f;

	}

	private void IncreaseTime()
	{
	

		switch(state)
		{
			case 1:
			state1Time += Time.deltaTime;
			break;

			case 2:
			state2Time += Time.deltaTime;
			break;

			case 3:
			state3Time += Time.deltaTime;
			break;

			default:
			break;


		}
	}

	void KillEffect()
	{
		myLight.intensity = 0f;
		myEffector.SetActive(false);
	}

	void State1()
	{
		myLight.intensity = 5*fadeInCurve.Evaluate(state1Time/state1Lenght);
		myEffector.transform.localScale = Vector3.one *(sizeEffect*fadeInCurve.Evaluate(state1Time/state1Lenght));
		myLight.color = colorGradientlight.Evaluate(state1Time/state1Lenght);
		myAudioSource.volume = fadeInCurve.Evaluate(state1Time/state1Lenght);
		IncreaseTime();
	}

	void State2()
	{
		IncreaseTime();
	}

	void State3()
	{
		myLight.intensity = fadeOutCurve.Evaluate(state3Time/state3Lenght);
		myEffector.transform.localScale = Vector3.one *(sizeEffect*fadeOutCurve.Evaluate(state3Time/state3Lenght));
		myAudioSource.volume = fadeOutCurve.Evaluate(state3Time/state3Lenght);
		Debug.Log("Its Working " +state3Time/state3Lenght);
		IncreaseTime();
	}

	IEnumerator TheEffect()
	{
		
		while(state == 1)
		{
			State1();

			if(state1Time/state1Lenght >= 1)
				state = 2;

			yield return null;
		}

		while(state == 2)
		{
			State2();

			if(state2Time/state2Lenght >= 1)
				state = 3;

			yield return null;
		}

		while(state == 3)
		{
			
			State3();

			if(state3Time/state3Lenght >= 1)
			{
				state = 0;
				KillEffect();
			}
				

			yield return null;
		}
		
	}
	
		
	
}
