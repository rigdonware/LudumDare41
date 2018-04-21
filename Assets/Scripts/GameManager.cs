using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public int gold;

	Text goldText;
	// Use this for initialization
	void Start () {
		goldText = GameObject.Find("Canvas").transform.Find("Gold").GetComponent<Text>();
		if(goldText)
			goldText.text = "Gold: 0";
	}
	
	// Update is called once per frame
	void Update () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);
	}

	public void IncreaseGold(int amount)
	{
		gold += amount;
		goldText.text = "Gold: " + gold.ToString();
	}




}
