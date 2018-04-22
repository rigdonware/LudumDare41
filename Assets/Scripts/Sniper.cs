using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : BaseCharacter {
	public int 	cost = 20;
	// Use this for initialization
	public override void Start () {
		base.Start();
		tower = GameObject.Find("EnemyTower");
		attackRadius = 10.0f;
		attackPower = 25;
		attackCooldown = 3;
		speed = 7;
		health = 75;
		if(GameManager.instance.gameType == GameManager.RTS)
			roundUp = GameObject.Find("SniperRoundup");
	}
	
	// Update is called once per frame
	public override void Update () {
		base.Update();
		
		if(!targetEnemy)
		{
			GetComponent<Animator>().Play("Walking");
		}
	}

	public override void AttackEnemy()
	{
		base.AttackEnemy();
		GetComponent<Animator>().Play("Sniping");
		Vector3 spawnPos = transform.Find("BulletSpawnPos").position;
		GameObject temp = (GameObject)Instantiate(bullet, spawnPos, Quaternion.identity);
		temp.layer = LayerMask.NameToLayer(gameObject.tag);
		temp.GetComponent<Bullet>().damage = this.attackPower;
		temp.GetComponent<Bullet>().destination = targetEnemy.transform.position;
	}
}
