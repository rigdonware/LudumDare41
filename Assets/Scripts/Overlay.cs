using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Overlay : MonoBehaviour {

	public void QueueUpPlayer()
	{
		GameObject prefab = Resources.Load("Soldier") as GameObject;
		GameObject playerTower = GameObject.Find("PlayerTower");
		if(playerTower && prefab)
			playerTower.GetComponent<PlayerSpawner>().QueueUpArmy(prefab);
	}

	public void QueueUpSoldier()
	{
		GameObject prefab = Resources.Load("Sniper") as GameObject;
		GameObject playerTower = GameObject.Find("PlayerTower");
		if(playerTower && prefab)
			playerTower.GetComponent<PlayerSpawner>().QueueUpArmy(prefab);
	}
}
