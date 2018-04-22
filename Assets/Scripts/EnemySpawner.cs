using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	float respawnCooldown = 4;
	float respawnCounter = 0;
	GameObject[] monsters;
	GameObject RockMonster;
	GameObject LeafMonster;
	GameObject IceMonster;
	GameObject enemyStart;
	Vector3 enemySpawnLoc;
	// Use this for initialization
	void Start () {
		monsters = new GameObject[3];
		monsters[0] = Resources.Load("LeafMonster") as GameObject;
		monsters[1] = Resources.Load("RockMonster") as GameObject;
		IceMonster = monsters[2] = Resources.Load("IceMonster") as GameObject;

		enemyStart = GameObject.Find("EnemyStart");
		enemySpawnLoc = new Vector3(enemyStart.transform.position.x, enemyStart.transform.position.y, enemyStart.transform.position.z);
	}

	// Update is called once per frame
	void Update () {
		respawnCounter += Time.deltaTime;
		if(respawnCounter >= respawnCooldown)
		{
			GameObject temp = (GameObject)Instantiate(monsters[Random.Range(0, monsters.Length)], enemySpawnLoc, Quaternion.identity);
			respawnCounter = 0;
		}
	}
}
