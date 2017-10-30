using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.ImageEffects;

public class Inspeccionador : MonoBehaviour, IInspectObjects {

	[SerializeField]
	private float rotSpeed = 500f;

	private bool isPlayerActive;

	private GameObject currentObject;

	private Quaternion oldRotation;

	private RigidbodyFirstPersonController myCharacterController;

    private static Blur blur;

    private void Awake()
    {
        if (blur != null)
            return;

        blur = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Blur>();
    }

    void Start ()
    {
		isPlayerActive = true;
	}

	void Update ()
	{
		if (!isPlayerActive)
		{
			OnMouseDrag();
		}
	}

	public void Action(GameObject player, GameObject aimObject)
	{
        Debug.Log("Action");

		if (player.GetComponent<RigidbodyFirstPersonController>().isActiveAndEnabled)
        {
			player.GetComponent<RigidbodyFirstPersonController>().enabled = false;
			isPlayerActive = false;
			oldRotation = transform.rotation;
		}
        else
		{
			player.GetComponent<RigidbodyFirstPersonController>().enabled = true;
			isPlayerActive = true;
			transform.rotation = oldRotation;
		}
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

        if (rotX != 0 && rotY != 0)
            blur.enabled = true;
        else
            blur.enabled = false;
    }
}
