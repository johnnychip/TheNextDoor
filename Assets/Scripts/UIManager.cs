using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {


	[SerializeField]
	private Text mesajeText;

	public static UIManager Instance
	{
		get;
		private set;
	}

	void Awake ()
	{
		
		if(Instance != null)
			Destroy(gameObject);
		else
			Instance = this;
	}

	public void SetMessageScreen(string texto)
	{
		mesajeText.text = texto;
		StartCoroutine("RestartText");
	}

	IEnumerator RestartText ()
	{
		for (float f = 1f; f >= 0; f -= 0.1f) 
		{
			yield return new WaitForSeconds(0.25f);
		}
		mesajeText.text = "";

	}

	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
