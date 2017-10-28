using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAudio : MonoBehaviour {

	[SerializeField]
	private int audioToPlay;

	[SerializeField]
	private bool isLoop;

	[SerializeField]
	private bool isTriggered;

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			if(isLoop)
			{
				AudioManager.Instance.PlaySoundIndex(audioToPlay);
			}else
			{
				if(!isTriggered)
				{	
					isTriggered=true;
					AudioManager.Instance.PlaySoundIndex(audioToPlay);
				}
			}

			
		}
	}

}
