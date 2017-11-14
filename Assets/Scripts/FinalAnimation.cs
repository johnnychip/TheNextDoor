using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalAnimation : MonoBehaviour {

	[SerializeField]
	private AudioSource myAudioSource;

	[SerializeField]
	private int sceneToLoad;

	public void SetBlackScreen()
	{
		UIManager.Instance.SetBlackScreen();
	}

	public void ShootPigScream()
	{
		myAudioSource.Play();
		StartCoroutine(CallBackAudio(myAudioSource.clip.length));
	}

	public void ShootHorrorSound()
	{
		AudioManager.Instance.PlaySoundIndex(7);
	}

	private IEnumerator CallBackAudio(float clipLenght)
	{
		yield return new WaitForSeconds(clipLenght);
		SceneManager.LoadScene(sceneToLoad);

	}

}
