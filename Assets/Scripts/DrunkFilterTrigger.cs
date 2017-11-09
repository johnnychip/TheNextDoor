using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkFilterTrigger : MonoBehaviour, IInspectObjects {

	[SerializeField]
	private GameObject playerObject;

	[SerializeField]
	private float timeOfHangover;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Action(GameObject player, GameObject aimObject)
	{
		playerObject = player;
		playerObject.GetComponentInChildren<CameraFilterPack_FX_Drunk>().enabled = true;
		StartCoroutine(Hangover());
	}


	public	void GoingOut(GameObject player, GameObject aimObject)
	{

	}

	private IEnumerator Hangover()
	{
		yield return new WaitForSeconds(timeOfHangover);
		playerObject.GetComponentInChildren<CameraFilterPack_FX_Drunk>().enabled = false;
	}

}
