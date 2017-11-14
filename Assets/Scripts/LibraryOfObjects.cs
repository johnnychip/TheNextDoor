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
			textoLoco.text = "Creo que puedo poner algo aqui, tengo que seguir buscando...";
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
		textoLoco.text = "Tengo que encontrar la llave o el objeto que abre esta puerta...";
		Invoke("RestartText",1.5f);
	}

	void RestartText ()
	{
		textoLoco.text = "";
	}


}
