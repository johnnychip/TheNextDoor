using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowNotesScript : MonoBehaviour, IInspectObjects {

	[SerializeField]
	private string stringNote;

	[SerializeField]
	private GameObject objNote;

	[SerializeField]
	private Text textNote; 

	public void Action()
	{
		if(!objNote.activeSelf)
		{
			objNote.SetActive(true);
			textNote.text = stringNote;
		}else
		{
			objNote.SetActive(false);
		}
	}

	public void GoingOut()
	{
		objNote.SetActive(false);
	}
}
