using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMessage : MonoBehaviour, IInspectObjects {

	[SerializeField]
	private string textShow;

	public void Action(GameObject player, GameObject aimObject)
	{
		UIManager.Instance.SetMessageScreen(textShow);
	}

	public void GoingOut(GameObject player, GameObject aimObject)
	{

	}

}
