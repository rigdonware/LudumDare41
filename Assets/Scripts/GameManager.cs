using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public int gold = 20;
	public int brick = 0;
	public int steel = 20;
	GameObject playerTower, enemyTower;
	bool gameOver;

	Text goldText, brickText, steelText;
	public bool playerWins;
	// Use this for initialization
	void Start () {
		gold = 20;
		steel = 50;
		goldText = GameObject.Find("Canvas").transform.Find("Gold").GetComponent<Text>();
		brickText = GameObject.Find("Canvas").transform.Find("Brick").GetComponent<Text>();
		steelText = GameObject.Find("Canvas").transform.Find("Steel").GetComponent<Text>();

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


}
