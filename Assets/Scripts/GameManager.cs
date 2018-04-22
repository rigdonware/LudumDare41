using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public int gold = 0;
	public int brick = 0;
	public int steel = 0;
	float warningTimer = 3;
	float warningCounter = 0;
	bool displayWarning;
	GameObject playerTower, enemyTower;
	bool gameOver;
	public float GameDurationInSeconds = 0;
	public int gameType;
	public const int RTS = 1;
	public const int TOWER_DEFENSE = 2;

	public Slider towerHealth;

	Text goldText, brickText, steelText, warningText;
	public bool playerWins;
	// Use this for initialization
	void Start () {
		gameType = RTS;
		gold = 20;
		goldText = GameObject.Find("Canvas").transform.Find("Gold").GetComponent<Text>();
		brickText = GameObject.Find("Canvas").transform.Find("Brick").GetComponent<Text>();
		steelText = GameObject.Find("Canvas").transform.Find("Steel").GetComponent<Text>();
		warningText = GameObject.Find("Canvas").transform.Find("WarningText").GetComponent<Text>();

		displayWarning = false;

		if(goldText)
			goldText.text = "Gold: " + gold.ToString();
		if(brickText)
			brickText.text = "Brick: " + brick.ToString();
		if(steelText)
			steelText.text = "Steel: " + steel.ToString();
		
		gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);

		playerTower = GameObject.Find("PlayerTower");
		enemyTower = GameObject.Find("EnemyTower");

		if(!playerTower || !enemyTower)
			gameOver = true;


		if(gameOver && SceneManager.GetActiveScene() != SceneManager.GetSceneByName("EndGame"))
		{
			if(!playerTower)
				playerWins = false;
			else
				playerWins = true;
			ProcessGameOver();
			Destroy(gameObject);
		}

		if(towerHealth && playerTower)
			towerHealth.value = playerTower.GetComponent<Tower>().health / 100;


		if(displayWarning)
			warningCounter += Time.deltaTime;

		if(warningCounter >= warningTimer)
		{
			warningText.text = "";
			displayWarning = false;
		}

		
		GameDurationInSeconds += Time.deltaTime;
	}

	public void IncreaseGold(int amount)
	{
		gold += amount;
		goldText.text = "Gold: " + gold.ToString();
	}

	public void IncreaseBrick(int amount)
	{
		brick += amount;
		brickText.text = "Brick: " + brick.ToString();
	}

	public void IncreaseSteel(int amount)
	{
		steel += amount;
		steelText.text = "Steel: " + steel.ToString();
	}

	void ProcessGameOver()
	{
		SceneManager.LoadScene("EndGame");
	}

	public void DisplayWarning(string text)
	{
		warningText.text = text;
		warningCounter = 0;
		displayWarning = true;
	}
}
