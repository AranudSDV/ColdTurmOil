using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public GameObject menu;

	public GameObject Menu1;
	public GameObject Menu2;
	public GameObject Menu3;
	public GameObject Menu4;
	public GameObject Menu5;

	public GameObject Menu6;
	public GameObject Menu7;
	public GameObject Menu8;


	void start()
	{
		Menu1.SetActive(false);
		Menu2.SetActive(false);
		Menu3.SetActive(false);
		Menu4.SetActive(false);
		Menu5.SetActive(false);
	}

	public void PlayBrief()
	{
		StartCoroutine(PlayBrieff());
	}

	public void PlayGame()
	{
		SceneManager.LoadSceneAsync("Playground");
		
	}

	public void QuitGame()
	{
		Application.Quit();
	}


	IEnumerator PlayBrieff()
    {
        Menu7.SetActive(false);
		Menu6.SetActive(false);
		Menu8.SetActive(false);
		AudioManager.instance.PlayOneShot(FMODEvent.instance.Briefing, this.transform.position);
        yield return new WaitForSeconds(2);
		Menu1.SetActive(true);
		Menu2.SetActive(true);
		Menu3.SetActive(true);
		Menu4.SetActive(true);
		Menu5.SetActive(true);
         
    }


}
