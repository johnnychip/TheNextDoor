using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwichActivateObjects : MonoBehaviour, IInspectObjects {

	[SerializeField]
	private GameObject[] objectToDeactivate;

	[SerializeField]
	private bool isSwitch;

	private bool isEnd;

	private int counter;

	private

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Action()
	{	
		if(isSwitch)
		{
			SwitchTheObject();
		}else
		{
			if(!isEnd)
			{
				isEnd = true;
				SwitchTheObject();
			}
		}

	}
		
	void SwitchTheObject()
	{	foreach(GameObject temp in objectToDeactivate)
		{
			if(temp.activeSelf)
			{
				temp.SetActive(false);
			}else
			{
				temp.SetActive(true);
			}
		}
	}
	
	public void GoingOut()
	{}
}
