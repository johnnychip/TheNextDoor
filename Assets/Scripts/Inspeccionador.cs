using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Inspeccionador : MonoBehaviour {

	[SerializeField]
	private float rotSpeed = 500f;

	private bool isObjectNear;

	private bool isPlayerActive;

	private GameObject currentObject;

	private Quaternion oldRotation;

	private RigidbodyFirstPersonController myCharacterController;

	// Use this for initialization
	void Start () {
		myCharacterController = GetComponent<RigidbodyFirstPersonController>();
		isPlayerActive = true;
	}

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag == "inspect")
		{
			isObjectNear = true;
			currentObject = other.gameObject;
			Debug.Log("Are you touching me?");
		}
	}

	void OnTriggerExit (Collider other)
	{
		if(other.gameObject.tag == "inspect")
		{	
			isObjectNear = false;
			currentObject = null;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.E) && isObjectNear)
		{	
			if(myCharacterController.isActiveAndEnabled){
				myCharacterController.enabled = false;
				isPlayerActive = false;
				oldRotation = currentObject.transform.rotation;

				Vector3 lookDirection = (currentObject.transform.position - transform.position).normalized;

				transform.rotation = Quaternion.LookRotation(lookDirection);
			}else
			{
				myCharacterController.enabled = true;
				isPlayerActive = true;
				currentObject.transform.rotation = oldRotation;
			}

		
		}

		if(!isPlayerActive)
		{
			OnMouseDrag();
		}
	}

	void OnMouseDrag()
	{
		float rotX = Input.GetAxis("Mouse X")*rotSpeed*Mathf.Deg2Rad;
		float rotY = Input.GetAxis("Mouse Y")*rotSpeed*Mathf.Deg2Rad;
	
		currentObject.transform.Rotate(Vector3.up, -rotX);
		currentObject.transform.Rotate(Vector3.right, rotY);
		
	}

}
