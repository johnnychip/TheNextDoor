using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Habitacion_0");
        }
        if(Input.GetMouseButtonDown(1))
        {
            SceneManager.LoadScene("Habitacion_0");
        }
    }
	
}
