using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public GameObject menu;

	public void PlayGame()
	{
		StartCoroutine(Play());
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	IEnumerator Play()
    {
        menu.SetActive(false);
		AudioManager.instance.PlayOneShot(FMODEvent.instance.Briefing, this.transform.position);
        yield return new WaitForSeconds(6);
         SceneManager.LoadSceneAsync("Playground");
    }




}
