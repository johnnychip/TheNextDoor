using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectToCollectDependenceTriggerAction : MonoBehaviour {

	[SerializeField]
	private GameObject[] objectsToCollect;

	[SerializeField]
	private int sceneToLoad;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CheckObjectsAreDeactive()
	{
		foreach(GameObject temp in objectsToCollect)
		{
			if(!temp.activeSelf)
			{	
				return;
			}
		}

		SceneManager.LoadScene(sceneToLoad);

	}
}
