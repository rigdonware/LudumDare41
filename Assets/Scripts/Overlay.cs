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
			Debug.Log("Not enough gold!");
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
			Debug.Log("Not enough gold!");
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
			Debug.Log("Not enough gold!");
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
			Debug.Log("Not enough gold!");
			return;
		}
		GameObject playerStart = GameObject.Find("PlayerStart");
		if(playerStart && prefab)
			playerStart.GetComponent<PlayerSpawner>().QueueUpScout(prefab);
	}
}
