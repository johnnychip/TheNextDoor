using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamerIntermitente : MonoBehaviour, IInspectObjects {

	[SerializeField]
	private Transform[] posEnemy;

	[SerializeField]
	private float timeOfTransitions;

	[SerializeField]
	private GameObject objectToMove;

	[SerializeField]
	private AudioSource myAudioSource;


	public void Action(GameObject player, GameObject aimObject)
	{
		myAudioSource.Play();
		StartCoroutine(TimeToMove());
	}


	public	void GoingOut(GameObject player, GameObject aimObject)
	{

	}

	private IEnumerator TimeToMove()
	{
		for(int i = 0; i < posEnemy.Length; i++)
		{
			objectToMove.transform.position = posEnemy[i].position;
			yield return new WaitForSeconds(timeOfTransitions);
		}
	}
}
