using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	float respawnCooldown = 4;
	float respawnCounter = 0;
	GameObject enemy;
	GameObject player;
	GameObject enemyStart;
	GameObject playerStart;
	Vector3 enemySpawnLoc, playerSpawnLoc;
	// Use this for initialization
	void Start () {
		enemy = Resources.Load("Enemy") as GameObject;
		enemyStart = GameObject.Find("EnemyStart");
		enemySpawnLoc = new Vector3(enemyStart.transform.position.x, enemyStart.transform.position.y + 3, enemyStart.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		respawnCounter += Time.deltaTime;
		if(respawnCounter >= respawnCooldown)
		{
			GameObject temp = null;
			temp = (GameObject)Instantiate(enemy, enemySpawnLoc, Quaternion.identity);
			respawnCounter = 0;
		}
	}
}
