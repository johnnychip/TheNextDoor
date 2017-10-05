using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LibraryOfObjects : MonoBehaviour {

	[SerializeField]
	private GameObject[] myLibrary;

	[SerializeField]
	private Text textoLoco;

	public void TryToPutObject(int indice, Transform trasnPut)
	{
		if(myLibrary[indice].GetComponent<ObjetoColecatable>().isColected)
		{
			myLibrary[indice].transform.position = trasnPut.position;
			myLibrary[indice].transform.rotation = trasnPut.rotation;
			myLibrary[indice].SetActive(true);
		}else
		{
			textoLoco.text = "I think, I can put something here...";
			Invoke("RestartText",1.5f);
		}
	}

	void RestartText ()
	{
		textoLoco.text = "";
	}


}
