using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameText : MonoBehaviour {

	Text txt;
	// Use this for initialization
	void Start () {
		txt = gameObject.GetComponent<Text>();
		if(GameManager.instance.playerWins)
			txt.text = "Congratulations! You Won!";
		else
			txt.text = "Would you like to play again?";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
