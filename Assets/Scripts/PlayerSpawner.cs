using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {

	List<GameObject> soldierQueue;
	List<GameObject> sniperQueue;
	List<GameObject> robotQueue;
	float soldierTimer = 0;
	float soldierCooldown = 3;
	float sniperTimer = 0;
	float sniperCooldown = 3;
	float robotTimer = 0;
	float robotCooldown = 3;
	// Use this for initialization
	void Start () {
		soldierQueue = new List<GameObject>();
		sniperQueue = new List<GameObject>();
		robotQueue = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		if(soldierQueue.Count > 0)
		{
			soldierTimer += Time.deltaTime;
			if(soldierTimer >= soldierCooldown)
			{
				float difference = GetComponent<Renderer>().bounds.size.y - this.gameObject.GetComponent<Renderer>().bounds.size.y;
				GameObject temp = (GameObject)Instantiate(soldierQueue[0], this.gameObject.transform.position +  Vector3.up * difference, Quaternion.identity);
				soldierTimer = 0;
				soldierQueue.Remove(soldierQueue[0]);
				soldierQueue.TrimExcess();
			}
		}

		if(sniperQueue.Count > 0)
		{
			sniperTimer += Time.deltaTime;
			if(sniperTimer >= sniperCooldown)
			{
				float difference = GetComponent<Renderer>().bounds.size.y - this.gameObject.GetComponent<Renderer>().bounds.size.y;
				GameObject temp = (GameObject)Instantiate(sniperQueue[0], this.gameObject.transform.position +  Vector3.up * difference, Quaternion.identity);
				sniperTimer = 0;
				sniperQueue.Remove(sniperQueue[0]);
				sniperQueue.TrimExcess();
			}
		}

		if(robotQueue.Count > 0)
		{
			robotTimer += Time.deltaTime;
			if(robotTimer >= robotCooldown)
			{
				float difference = GetComponent<Renderer>().bounds.size.y - this.gameObject.GetComponent<Renderer>().bounds.size.y;
				GameObject temp = (GameObject)Instantiate(robotQueue[0], this.gameObject.transform.position +  Vector3.up * difference, Quaternion.identity);
				robotTimer = 0;
				robotQueue.Remove(robotQueue[0]);
				robotQueue.TrimExcess();
			}
		}
	}

	public void QueueUpSoldier(GameObject whichPrefab)
	{
		soldierQueue.Add(whichPrefab);
		GameManager.instance.IncreaseGold(whichPrefab.GetComponent<Soldier>().cost	* -1);
	}

	public void QueueUpSniper(GameObject whichPrefab)
	{
		sniperQueue.Add(whichPrefab);
		GameManager.instance.IncreaseGold(whichPrefab.GetComponent<Sniper>().cost	* -1);
	}

	public void QueueUpRobot(GameObject whichPrefab)
	{
		robotQueue.Add(whichPrefab);
		GameManager.instance.IncreaseGold(whichPrefab.GetComponent<Robot>().cost * -1);
	}

	public void QueueUpScout(GameObject whichPrefab)
	{
		float difference = GetComponent<Renderer>().bounds.size.y - this.gameObject.GetComponent<Renderer>().bounds.size.y;
		GameObject temp = (GameObject)Instantiate(whichPrefab, this.gameObject.transform.position +  Vector3.up * difference, Quaternion.identity);
	}

}
