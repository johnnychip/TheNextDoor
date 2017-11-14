using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

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
		playerObject.GetComponent<RigidbodyFirstPersonController>().enabled = false;
		playerObject.GetComponentInChildren<CameraFilterPack_FX_Drunk>().enabled = true;
		playerObject.GetComponentInChildren<Animator>().SetTrigger("scream");
		StartCoroutine(Hangover());
	}


	public	void GoingOut(GameObject player, GameObject aimObject)
	{

	}

	private IEnumerator Hangover()
	{
		yield return new WaitForSeconds(timeOfHangover);
		playerObject.GetComponent<RigidbodyFirstPersonController>().enabled = true;
		playerObject.GetComponentInChildren<CameraFilterPack_FX_Drunk>().enabled = false;
	}

}
