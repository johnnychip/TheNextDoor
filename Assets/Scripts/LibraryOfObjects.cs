using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LibraryOfObjects : MonoBehaviour {

	[SerializeField]
	private GameObject[] myLibrary;

	[SerializeField]
	private Text textoLoco;

	public bool TryToPutObject(int indice, Transform trasnPut)
	{
		if(myLibrary[indice].GetComponent<ObjetoColecatable>().isColected)
		{
			myLibrary[indice].transform.position = trasnPut.position;
			myLibrary[indice].transform.rotation = trasnPut.rotation;
			myLibrary[indice].SetActive(true);
			return true;
		}else
		{
			textoLoco.text = "I think, I can put something here...";
			Invoke("RestartText",1.5f);
			return false;
		}
	}

	public bool ObjectWasColected(int indice)
	{
		if(myLibrary[indice].GetComponent<ObjetoColecatable>().isColected)
		{
			return true;
		}else
		{
			return false;
		}
	}

	public void ShowTextKey()
	{
		textoLoco.text = "I have to find the key...";
		Invoke("RestartText",1.5f);
	}

	void RestartText ()
	{
		textoLoco.text = "";
	}


}
