using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoSwitche : MonoBehaviour {

	[SerializeField]
	private Animator anim;

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			Debug.Log("Happening");
			anim.SetBool("IsWalking", true);
		}
	}

}
