using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

	public void Play1vs1Game ()
	{
		Shared.mode = "1vs1";
		SceneManager.LoadScene(1);
	}
	
	public void PlayBotGame ()
	{
		Shared.mode = "bot";
		SceneManager.LoadScene(1);
	}

	public void ExitGame ()
	{
		Application.Quit();
	}

	public void GoToGetPoints ()
	{
		Application.OpenURL("https://telegra.ph/we-need-points-10-17");
	}
}
