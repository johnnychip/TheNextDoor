using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwichActivateObjects : MonoBehaviour, IInspectObjects {

	[SerializeField]
	private GameObject[] objectToDeactivate;

	[SerializeField]
	private bool isSwitch;

	[SerializeField]
	private AudioSource audioSwitchOn;

	[SerializeField]
	private AudioSource audioSwitchOff;

	private bool isEnd;

	private int counter;

	private bool isOn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Action(GameObject player)
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
		DoAudio();
	}

	void DoAudio()
	{
		if(audioSwitchOn!=null)
		{
			if(isOn)
			{
				audioSwitchOff.Play();
				isOn = false;
			}else
			{
				audioSwitchOn.Play();
				isOn = true;
			}
		}
	}
	
	public void GoingOut(GameObject player)
	{

	}

}
