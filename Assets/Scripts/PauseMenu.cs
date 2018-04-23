using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	public static bool isPaused = false;
	public GameObject pauseMenu;
	public GameObject mainOverlay;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Pause();
		}
	}

	void Pause()
	{
		Time.timeScale = 0.0f;
		pauseMenu.SetActive(true);
		mainOverlay.SetActive(false);
	}

	public void Resume()
	{
		Time.timeScale = 1f;
		pauseMenu.SetActive(false);
		mainOverlay.SetActive(true);
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void MainMenu()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("StartScreen");
	}
}
