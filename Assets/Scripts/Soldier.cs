using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : BaseCharacter {

	public int cost = 10;
	// Use this for initialization
	public override void Start () {
		base.Start();
		tower = GameObject.Find("EnemyTower");
		attackRadius = 5.0f;
		attackPower = 1;
		attackCooldown = .1f;
		speed = 10;
		health = 75;
		if(GameManager.instance.gameType == GameManager.RTS)
			roundUp = GameObject.Find("SoldierRoundup");
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
		GetComponent<Animator>().Play("Shooting");
		Vector3 spawnPos = transform.Find("BulletSpawnPos").position;
		GameObject temp = (GameObject)Instantiate(bullet, spawnPos, Quaternion.identity);
		temp.layer = LayerMask.NameToLayer(gameObject.tag);
		temp.GetComponent<Bullet>().damage = this.attackPower;
		temp.GetComponent<Bullet>().destination = targetEnemy.transform.position;
	}
}
