using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectActionator : MonoBehaviour, IInspectObjects {

	[SerializeField]
	private	ParticlesEffect myEffect;

	public void Action(GameObject player, GameObject aimObject)
	{
		myEffect.LaunchEffect();
	}

	public void GoingOut(GameObject player, GameObject aimObject)
	{

	}

}
