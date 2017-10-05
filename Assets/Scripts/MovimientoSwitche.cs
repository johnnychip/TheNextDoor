using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoSwitche : MonoBehaviour,IInspectObjects {

	[SerializeField]
	private Animator anim;

	[SerializeField]
	private bool isReapeating;

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			Action(other.gameObject,gameObject);
		}
	}

	public void Action(GameObject player, GameObject aimObject)
	{
		if(isReapeating)
		anim.SetTrigger("isTime");
		else
		anim.SetBool("IsWalking", true);
	}

	public void GoingOut(GameObject player, GameObject aimObject)
	{

	}

}
