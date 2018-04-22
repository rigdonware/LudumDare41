using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Overlay : MonoBehaviour {

	public void QueueUpPlayer()
	{
		GameObject prefab = Resources.Load("Soldier") as GameObject;
		if(GameManager.instance.gold < prefab.GetComponent<Soldier>().cost)
		{
			GameManager.instance.DisplayWarning("Not enough gold");
			return;
		}
		GameObject playerStart = GameObject.Find("PlayerStart");
		if(playerStart && prefab)
			playerStart.GetComponent<PlayerSpawner>().QueueUpSoldier(prefab);
	}

	public void QueueUpSoldier()
	{
		GameObject prefab = Resources.Load("Sniper") as GameObject;
		if(GameManager.instance.gold < prefab.GetComponent<Sniper>().cost)
		{
			GameManager.instance.DisplayWarning("Not enough gold");
			return;
		}
		GameObject playerStart = GameObject.Find("PlayerStart");
		if(playerStart && prefab)
			playerStart.GetComponent<PlayerSpawner>().QueueUpSniper(prefab);
	}

	public void QueueUpRobot()
	{
		GameObject prefab = Resources.Load("Robot") as GameObject;
		if(GameManager.instance.gold < prefab.GetComponent<Robot>().cost)
		{
			GameManager.instance.DisplayWarning("Not enough gold");
			return;
		}
		GameObject playerStart = GameObject.Find("PlayerStart");
		if(playerStart && prefab)
			playerStart.GetComponent<PlayerSpawner>().QueueUpRobot(prefab);
	}

	public void QueueUpScout()
	{
		GameObject prefab = Resources.Load("Scout") as GameObject;
		if(GameManager.instance.gold < prefab.GetComponent<Scout>().cost)
		{
			GameManager.instance.DisplayWarning("Not enough gold");
			return;
		}
		GameObject playerStart = GameObject.Find("PlayerStart");
		if(playerStart && prefab)
			playerStart.GetComponent<PlayerSpawner>().QueueUpScout(prefab);
	}

	public void SwitchGameMode()
	{
		if(GameManager.instance.gameType == GameManager.RTS)
		{
			GameManager.instance.gameType = GameManager.TOWER_DEFENSE;
		}
		else
		{
			GameManager.instance.gameType = GameManager.RTS;
		}
	}

	public void HealTower()
	{
		GameObject playerTower = GameObject.Find("PlayerTower");

		if(!playerTower)
			return;

		if(GameManager.instance.brick >= 20)
		{
			playerTower.GetComponent<Tower>().health += 10;
			if(playerTower.GetComponent<Tower>().health >= 100)
				playerTower.GetComponent<Tower>().health  = 100;
			GameManager.instance.IncreaseBrick(20 * -1);
		}
		else
		{
			GameManager.instance.DisplayWarning("Not enough brick");
		}
	}
}
