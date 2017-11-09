using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.ImageEffects;
using DG.Tweening;

public class Inspeccionador : MonoBehaviour, IInspectObjects {

	[SerializeField]
	private float rotSpeed = 500f;

	[SerializeField]
	private string textOfTheCollectable;

	[SerializeField]
	private bool killIt;

	private Transform posToInspect;

	private bool isPlayerActive;

	private GameObject currentObject;

	private Quaternion oldRotation;
	private Vector3 oldPosition;

	private RigidbodyFirstPersonController myCharacterController;

    private static Blur blur;

    private void Awake()
    {
		DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
        if (blur != null)
            return;

        blur = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Blur>();
    }

    void Start ()
    {
		isPlayerActive = true;

		oldRotation = transform.rotation;
					
		oldPosition = transform.position;

	}

	void Update ()
	{
		if (!isPlayerActive)
		{
			OnMouseDrag();
		}
	}

	public virtual void Action(GameObject player, GameObject aimObject)
	{

		

        Debug.Log("Action");

		if (player.GetComponent<RigidbodyFirstPersonController>().isActiveAndEnabled)
        {
			player.GetComponent<Rigidbody>().velocity = Vector3.zero;
			player.GetComponent<RigidbodyFirstPersonController>().enabled = false;
			posToInspect = player.GetComponentInChildren<InspectAim>().posToInspect;
			isPlayerActive = false;
			blur.enabled = true;
			UIManager.Instance.SetMessageScreen(textOfTheCollectable);
			transform.DOMove(posToInspect.position,0.5f, false);
			
		}
        else
		{
			player.GetComponent<RigidbodyFirstPersonController>().enabled = true;
			isPlayerActive = true;
			blur.enabled = false;
			if(killIt)
			{
				transform.rotation = oldRotation;
				transform.position = oldPosition;
			}else
			{
				transform.rotation = oldRotation;
				transform.DOMove(oldPosition,0.5f, false);
			}
			
			SomethignToDoInOutBlur();
		}
	}

	public virtual void SomethignToDoInOutBlur()
	{

	}


	public void GoingOut(GameObject player, GameObject aimObject)
	{
        Debug.Log("GoingOut");

        isPlayerActive = true;
		transform.rotation = oldRotation;

        blur.enabled = false;
    }

	void OnMouseDrag()
	{
        Debug.Log("OnMouseDrag");

        float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;
	
		gameObject.transform.Rotate(Vector3.up, -rotX);
		gameObject.transform.Rotate(Vector3.right, rotY);

        /*if (rotX != 0 && rotY != 0)
            blur.enabled = true;
        else
            blur.enabled = false;*/
    }
}
