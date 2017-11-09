using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScreamer : MonoBehaviour {

	[SerializeField]
	private GameObject[] objectsToActionate;

	private bool isTriggered;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other)
	{	
		if(isTriggered)
			return;

		if(other.gameObject.CompareTag("Player"))
		{
			isTriggered = true;
			foreach(GameObject temp in objectsToActionate)
			{
				temp.GetComponent<IInspectObjects>().Action(other.gameObject,other.gameObject);
			}
		}
	}

}
