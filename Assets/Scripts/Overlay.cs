using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Overlay : MonoBehaviour {

	public void QueueUpPlayer()
	{
		GameObject prefab = Resources.Load("Soldier") as GameObject;
		GameObject playerStart = GameObject.Find("PlayerStart");
		if(playerStart && prefab)
			playerStart.GetComponent<PlayerSpawner>().QueueUpSoldier(prefab);
	}

	public void QueueUpSoldier()
	{
		GameObject prefab = Resources.Load("Sniper") as GameObject;
		GameObject playerStart = GameObject.Find("PlayerStart");
		if(playerStart && prefab)
			playerStart.GetComponent<PlayerSpawner>().QueueUpSniper(prefab);
	}

	public void QueueUpRobot()
	{
		GameObject prefab = Resources.Load("Robot") as GameObject;
		GameObject playerStart = GameObject.Find("PlayerStart");
		if(playerStart && prefab)
			playerStart.GetComponent<PlayerSpawner>().QueueUpRobot(prefab);
	}
}
