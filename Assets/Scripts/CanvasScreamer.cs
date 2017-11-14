using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CanvasScreamer : MonoBehaviour {

	[SerializeField]
	Image myImage;

	[SerializeField]
	private Color initialColor,EndColor;

	[SerializeField]
	private float timeOfFade;

	[SerializeField]
	private Sprite[] mySprites;

	[SerializeField]
	private int soundToPlay;

	private bool isActionated;

	// Use this for initialization
	void Start () {
		DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if(isActionated)
			return;

		SetScreamer();
	}

	private void SetScreamer()
	{
		isActionated = true;
		myImage.sprite = mySprites[Random.Range(0,mySprites.Length)];
		myImage.color = initialColor;
		if(soundToPlay!=0)
			AudioManager.Instance.PlaySoundIndex(soundToPlay);
		else
			AudioManager.Instance.PlaySoundIndex(3);

		myImage.DOColor(EndColor,timeOfFade);
	}
}
