using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Inspeccionador : MonoBehaviour, IInspectObjects {

	[SerializeField]
	private float rotSpeed = 500f;

	private bool isPlayerActive;

	private GameObject currentObject;

	private Quaternion oldRotation;

	private RigidbodyFirstPersonController myCharacterController;

	// Use this for initialization
	void Start () {
		isPlayerActive = true;
	}

	void Update ()
	{
		if(!isPlayerActive)
		{
			OnMouseDrag();
		}
	}

	public void Action(GameObject player, GameObject aimObject)
	{
		if(player.GetComponent<RigidbodyFirstPersonController>().isActiveAndEnabled){
			player.GetComponent<RigidbodyFirstPersonController>().enabled = false;
			isPlayerActive = false;
			oldRotation = transform.rotation;
		}else
		{
			player.GetComponent<RigidbodyFirstPersonController>().enabled = true;
			isPlayerActive = true;
			transform.rotation = oldRotation;
		}

	
	}


	public void GoingOut(GameObject player, GameObject aimObject)
	{
			isPlayerActive = true;
			transform.rotation = oldRotation;
	}

	void OnMouseDrag()
	{
		float rotX = Input.GetAxis("Mouse X")*rotSpeed*Mathf.Deg2Rad;
		float rotY = Input.GetAxis("Mouse Y")*rotSpeed*Mathf.Deg2Rad;
	
		gameObject.transform.Rotate(Vector3.up, -rotX);
		gameObject.transform.Rotate(Vector3.right, rotY);
		
	}

}
