using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {

	List<GameObject> armyQueue;
	float armyTimer = 0;
	float armyCooldown = 3;
	// Use this for initialization
	void Start () {
		armyQueue = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		if(armyQueue.Count > 0)
		{
			foreach(GameObject army in armyQueue.ToArray())
			{
				armyTimer += Time.deltaTime;
				if(armyTimer >= armyCooldown)
				{
					GameObject temp = (GameObject)Instantiate(army, this.gameObject.transform.position, Quaternion.identity);
					armyTimer = 0;
					armyQueue.Remove(army);
				}
			}
		}
	}

	public void QueueUpArmy(GameObject whichPrefab)
	{
		armyQueue.Add(whichPrefab);
	}
}
