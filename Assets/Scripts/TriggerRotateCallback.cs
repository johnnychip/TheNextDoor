using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TriggerRotateCallback : MonoBehaviour {

	[SerializeField]
	private Vector3 initialRotation, endRotation;

	[SerializeField]
	private Transform objectToRotate;

	[SerializeField]
	private float duration;

	[SerializeField]
	private AudioSource myAudioSoruce;

	[SerializeField]
	private string objectTagActivator;

	[SerializeField]
	private GameObject[] objectToActionate;

	[SerializeField]
	private TriggerSonidoAnimacion myTriggerSonido;

	private bool isActivated;


	void Start () {	
		DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag(objectTagActivator)&&!isActivated)
		{	
			AudioManager.Instance.PlayDoorClose();
			isActivated = true;
			RotateObject();
		}
	}

	private void RotateObject()
	{
		objectToRotate.DORotate(endRotation,duration).OnComplete(ShootAudio);
	}

	private void ShootAudio()
	{
		myTriggerSonido.PlayAnimation();
		myAudioSoruce.Play();
		StartCoroutine(CallBackAudio(myAudioSoruce.clip.length)) ;
		
	}

	private IEnumerator CallBackAudio(float clipLenght)
	{
		yield return new WaitForSeconds(clipLenght);
		SetRotationToInitialValue();

	}

	private void SetRotationToInitialValue()
	{
		AudioManager.Instance.PlayDoorSound();
		objectToRotate.DORotate(initialRotation,duration);

		if(objectToActionate.Length>0)
		{
			foreach(GameObject temp in objectToActionate)
			{
				temp.GetComponent<IInspectObjects>().Action(gameObject, gameObject);
			}
		}
	}


	// Use this for initialization
	
	
	
}
