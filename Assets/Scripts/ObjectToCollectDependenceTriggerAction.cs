using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectToCollectDependenceTriggerAction : MonoBehaviour, IInspectObjects {

	[SerializeField]
	private GameObject[] objectsToCollect;

	[SerializeField]
	private int sceneToLoad;

	public void Action(GameObject player, GameObject aimObject)
	{
		CheckObjectsAreDeactive();
	}

	public void GoingOut(GameObject player, GameObject aimObject)
	{
		
	}

	public void CheckObjectsAreDeactive()
	{
		foreach(GameObject temp in objectsToCollect)
		{
			if(temp.activeSelf)
			{	
				return;
			}
		}

		SceneManager.LoadScene(sceneToLoad);

	}
}
