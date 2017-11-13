using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspeccionableStatico : MonoBehaviour, IInspectObjects {

	[SerializeField]
	private string textToShow;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public virtual void Action(GameObject player, GameObject aimObject)
	{
		UIManager.Instance.SetMessageScreen(textToShow);
	}

	public void GoingOut(GameObject player, GameObject aimObject)
	{
	}

}
