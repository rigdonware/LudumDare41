using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour {

	public void StartGame()
	{
		SceneManager.LoadScene("GameScene");
	}

	public void Instructions()
	{
		SceneManager.LoadScene("HowTo");
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void MainMenu()
	{
		SceneManager.LoadScene("StartScreen");
	}
}
