using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public int gold = 0;
	GameObject playerTower, enemyTower;
	bool gameOver;

	Text goldText;
	// Use this for initialization
	void Start () {
		goldText = GameObject.Find("Canvas").transform.Find("Gold").GetComponent<Text>();
		if(goldText)
			goldText.text = "Gold: 0";
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
