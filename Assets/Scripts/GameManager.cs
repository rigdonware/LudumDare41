using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public int gold = 20;
	public int brick = 0;
	public int steel = 0;
	GameObject playerTower, enemyTower;
	bool gameOver;

	Text goldText;
	// Use this for initialization
	void Start () {
		gold = 20;
		goldText = GameObject.Find("Canvas").transform.Find("Gold").GetComponent<Text>();
		if(goldText)
			goldText.text = "Gold: " + gold.ToString();
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


		if(gameOver)
			ProcessGameOver();
	}

	public void IncreaseGold(int amount)
	{
		gold += amount;
		goldText.text = "Gold: " + gold.ToString();
	}

	void ProcessGameOver()
	{
		SceneManager.LoadScene("EndGame");
	}


}
