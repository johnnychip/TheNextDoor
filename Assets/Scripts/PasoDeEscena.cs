using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasoDeEscena : MonoBehaviour {


	[SerializeField]
	private int sceneTo;	
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			SceneManager.LoadScene(sceneTo);
		}
	}

}
